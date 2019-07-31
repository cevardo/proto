﻿// Generated by Xamasoft JSON Class Generator
// http://www.xamasoft.com/json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Embily.Gateways.KoKard.Models
{
    public class GetProgramInfoTableItem
    {

        [JsonProperty("Program Category")]
        public string ProgramCategory { get; set; }

        [JsonProperty("Program Type")]
        public string ProgramType { get; set; }

        [JsonProperty("Max Card Load Limit")]
        public string MaxCardLoadLimit { get; set; }

        [JsonProperty("Minimum Load Limit")]
        public string MinimumLoadLimit { get; set; }

        [JsonProperty("Max Debit Funds Limit")]
        public string MaxDebitFundsLimit { get; set; }

        [JsonProperty("Min Debit Funds Limit")]
        public string MinDebitFundsLimit { get; set; }

        [JsonProperty("Max Share Funds Limit")]
        public string MaxShareFundsLimit { get; set; }

        [JsonProperty("Min Share Funds Limit")]
        public string MinShareFundsLimit { get; set; }

        [JsonProperty("Max Withdrawal Limit")]
        public string MaxWithdrawalLimit { get; set; }

        [JsonProperty("Client Webhook")]
        public string ClientWebhook { get; set; }

        [JsonProperty("Flat fee for card issuance")]
        public string FlatFeeForCardIssuance { get; set; }

        [JsonProperty("Percentage fee for card issuance")]
        public string PercentageFeeForCardIssuance { get; set; }

        [JsonProperty("Flat fee for card loading")]
        public string FlatFeeForCardLoading { get; set; }

        [JsonProperty("Percentage fee for card loading")]
        public string PercentageFeeForCardLoading { get; set; }

        [JsonProperty("Flat fee for card delivery")]
        public string FlatFeeForCardDelivery { get; set; }

        [JsonProperty("Percentage fee for card delivery")]
        public string PercentageFeeForCardDelivery { get; set; }

        [JsonProperty("Flat fee for card reissuance")]
        public string FlatFeeForCardReissuance { get; set; }

        [JsonProperty("Percentage fee for card reissuance")]
        public string PercentageFeeForCardReissuance { get; set; }

        [JsonProperty("Program BIN Currency")]
        public string ProgramBINCurrency { get; set; }

        [JsonProperty("Flat fee for card debit")]
        public string FlatFeeForCardDebit { get; set; }

        [JsonProperty("Percent fee for card debit")]
        public string PercentFeeForCardDebit { get; set; }

        [JsonProperty("Flat fee for sharing of funds(Card to Card)")]
        public string FlatFeeForSharingOfFundsCardToCard { get; set; }

        [JsonProperty("Percent Fee for sharing of funds(Card to Card)")]
        public string PercentFeeForSharingOfFundsCardToCard { get; set; }

        [JsonProperty("Flat fee for purse loading")]
        public string FlatFeeForPurseLoading { get; set; }

        [JsonProperty("Percentage fee for purse loading")]
        public string PercentageFeeForPurseLoading { get; set; }

        [JsonProperty("Minimum Withdrawal Limit")]
        public string MinimumWithdrawalLimit { get; set; }
    }

    public class GetProgramInfoTableResult
    {
        [JsonProperty("ProgramTable")]
        public GetProgramInfoTableItem[] ProgramTable { get; set; }
    }

    public class GetProgramInfoResponse : BaseResponse
    {
        [JsonProperty("AdditionalInfo")]
        public AdditionalInfo AdditionalInfo { get; set; }

        [JsonProperty("TableResult")]
        public GetProgramInfoTableResult TableResult { get; set; }
    }

}
