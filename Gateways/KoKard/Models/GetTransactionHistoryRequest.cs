﻿// Generated by Xamasoft JSON Class Generator
// http://www.xamasoft.com/json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Embily.Gateways.KoKard.Models
{

    public class GetTransactionHistoryRequest : BaseRequest
    {
        [JsonProperty("CardReferenceID")]
        public string CardReferenceID { get; set; }

        [JsonProperty("DateFrom")]
        public string DateFrom { get; set; }

        [JsonProperty("DateTo")]
        public string DateTo { get; set; }
    }

}
