﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Embily.Gateways;
using Embily.Messages;
using Embily.Models;
using Embily.Services;
using EmbilyServices.Hubs;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;

namespace EmbilyServices.Controllers
{
    public class CallbackProcessor
    {
        readonly IHostingEnvironment _env;
        readonly IConfiguration _configuration;
        readonly IEmailQueueSender _emailSender;
        readonly ILogger<Controller> _logger;
        readonly EmbilyDbContext _ctx;
        readonly IRefGen _refGen;
        readonly IHubContext<BlockchainHub> _hubContext;

        public CallbackProcessor(
            IHostingEnvironment env,
            IConfiguration configuration,
            EmbilyDbContext ctx,
            IEmailQueueSender emailSender,
            ILogger<Controller> logger,
            IRefGen refGen,
            IHubContext<BlockchainHub> hubContext
        )
        {
            _env = env;
            _configuration = configuration;
            _ctx = ctx;
            _emailSender = emailSender;
            _logger = logger;
            _refGen = refGen;
            _hubContext = hubContext;
        }

        public async Task<Transaction> Process(string address, string transactionHash, double value)
        {
            var cryptoAddress = _ctx.CryptoAddresses.FirstOrDefault(a => a.Address == address);

            if (cryptoAddress == null)
            {
                // unknown address --
                throw new ApplicationException($"ProcessCallback: no match found for Crypto Address in CryptoAddresses. Address: [{address}]");
            }

            var account = await _ctx.Accounts.FindAsync(cryptoAddress.AccountId);
            var user = await _ctx.Users.FindAsync(account.UserId);

            var txn = _ctx.Transactions.FirstOrDefault(t => t.CryptoTxnId == transactionHash);
            TxnStatus status = (txn == null) ? TxnStatus.Unconfirmed : TxnStatus.Duplicate;

            var normalizeValue = GetValue(cryptoAddress.CurrencyCode, value);

            Transaction transaction = await CreateTransactionDB(transactionHash, normalizeValue, cryptoAddress, account, status);

            // generate references --
            long num = Convert.ToInt64(transaction.TransactionNumber);
            transaction.Reference = _refGen.GenTxnRef(num);
            transaction.TxnGroupRef = _refGen.GenTxnGroupRef(num);

            await _ctx.SaveChangesAsync();

            if (status == TxnStatus.Unconfirmed)
            {
                // notify web client 
                await _hubContext.Clients.All.SendAsync("TransactionDetected", cryptoAddress.CurrencyCode, address, transaction.OriginalAmount);

                // send to queue 
                await SendToDetectTransferQueue(transaction);

                // send notification email --
                await _emailSender.TopupTransferAsync(transaction, user, account);
            }

            if (status == TxnStatus.Duplicate)
            {
                _logger.LogError($"ProcessCallback: a duplicate transaction. Investigate! transactionID [{txn.TransactionId}]");
            }

            return transaction;
        }

        private double GetValue(CurrencyCodes currencyCode, double value)
        {
            switch (currencyCode)
            {
                case CurrencyCodes.BTC:
                case CurrencyCodes.LTC:
                    return Math.Round(value / 100000000, 8);
                case CurrencyCodes.ETH:
                    return Math.Round(value / 1000000040000000000, 8);
                default:
                    throw new ApplicationException($"unsupported currency code ${currencyCode}");
            }
        }

        private async Task<Transaction> CreateTransactionDB(string transactionHash, double value, CryptoAddress address, Account account, TxnStatus status)
        {
            Transaction transaction = new Transaction
            {
                TransactionId = Guid.NewGuid().ToString(),
                //TransactionNumber = // generated by the database via sequence 
                TxnType = TxnTypes.CREDIT,
                TxnCode = TxnCodes.TRANSFER,
                CryptoAddress = address.Address,
                CryptoTxnId = transactionHash,
                CryptoProvider = CryptoProviders.Bitfinex,
                OriginalCurrencyCode = address.CurrencyCode,
                OriginalAmount = value,
                DestinationCurrencyCode = account.CurrencyCode,
                IsAmountKnown = true,
                Status = status,
                AccountId = account.AccountId,
            };

            await _ctx.Transactions.AddAsync(transaction);
            await _ctx.SaveChangesAsync();

            return transaction;
        }

        private async Task SendToDetectTransferQueue(Transaction txn)
        {
            var message = new DetectTransfer
            {
                TxnId = txn.TransactionId,
                TransactionNumber = txn.TransactionNumber,
                CryptoTxnId = txn.CryptoTxnId,
                OriginalCurrencyCode = txn.OriginalCurrencyCode.ToString(),
                DestinationCurrencyCode = txn.DestinationCurrencyCode.ToString(),

                AprxTxnDatetime = DateTimeOffset.UtcNow,
            };

            CloudQueue queue = await GetQueue("detect-transfer");
            var msg = new CloudQueueMessage(JsonConvert.SerializeObject(message));

            // this is a delay messages for BTC, ETH and also LTC, no need to check earlier than 10min
            var delay = TimeSpan.FromMinutes(25);
            //var delay = TimeSpan.FromSeconds(1);

            await queue.AddMessageAsync(msg, null, delay, null, null);
        }

        async Task<CloudQueue> GetQueue(string name)
        {
            var queueConnectionString = _configuration.GetConnectionString("AzureWebJobsStorage");
            _logger.LogDebug($"Queue connection string: {queueConnectionString}");

            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(queueConnectionString);

            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
            CloudQueue queue = queueClient.GetQueueReference(name);
            await queue.CreateIfNotExistsAsync();
            return queue;
        }

    }
}
