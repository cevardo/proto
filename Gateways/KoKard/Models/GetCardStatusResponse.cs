﻿// Generated by Xamasoft JSON Class Generator
// http://www.xamasoft.com/json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Embily.Gateways.KoKard.Models
{
    /*
        A ISSUED INACTIVE Card has been issued but not yet activated
        B OPEN All Transactions Allowed
        C LOST CARD Lost Card
        D STOLEN CARD Stolen Card
        E NO WITHDRAWALS No withdrawals are allowed to be made on card. (Restricted)
        F CLOSED Card account has been closed
        G LOST NOT CAP Lost card not captured
        H STOLEN NOT CAP Stolen card not captured
        I INACTIVE Card is inactive or blocked
        R CARD REISSUE Card reissue
        S Fraud Block Card blocked due to fraud
    */

    public class CardStatusTableItem
    {
        [JsonProperty("StatusCode")]
        public string StatusCode { get; set; }

        [JsonProperty("StatusDescription")]
        public string StatusDescription { get; set; }
    }

    public class CardStatusTableResult
    {
        [JsonProperty("CardStatusTable")]
        public CardStatusTableItem[] CardStatusTable { get; set; }
    }

    public class GetCardStatusResponse : BaseResponse
    {
        [JsonProperty("AdditionalInfo")]
        public AdditionalInfo AdditionalInfo { get; set; }

        [JsonProperty("TableResult")]
        public CardStatusTableResult TableResult { get; set; }
    }
}
