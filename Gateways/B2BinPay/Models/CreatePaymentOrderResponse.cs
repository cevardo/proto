﻿// Generated by Xamasoft JSON Class Generator
// http://www.xamasoft.com/json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Embily.Gateways.B2BinPay.Models
{

    public class Currency
    {

        [JsonProperty("iso")]
        public int Iso { get; set; }

        [JsonProperty("alpha")]
        public string Alpha { get; set; }
    }

    public class Data
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("created")]
        public string Created { get; set; }

        [JsonProperty("expired")]
        public string Expired { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("tracking_id")]
        public object TrackingId { get; set; }

        [JsonProperty("callback_url")]
        public string CallbackUrl { get; set; }

        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("actual_amount")]
        public string ActualAmount { get; set; }

        [JsonProperty("pow")]
        public int Pow { get; set; }

        [JsonProperty("transactions")]
        public object[] Transactions { get; set; }

        [JsonProperty("currency")]
        public Currency Currency { get; set; }

        [JsonProperty("message")]
        public object Message { get; set; }
    }

    public class CreatePaymentOrderResponse
    {

        [JsonProperty("data")]
        public Data Data { get; set; }
    }

}
