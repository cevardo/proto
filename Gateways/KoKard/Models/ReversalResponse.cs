﻿// Generated by Xamasoft JSON Class Generator
// http://www.xamasoft.com/json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Embily.Gateways.KoKard.Models
{

    public class ReversalResponse : BaseResponse
    {
        [JsonProperty("AdditionalInfo")]
        public AdditionalInfoFinancial AdditionalInfo { get; set; }

        /// <summary>
        /// always null - commented out ---
        /// </summary>
        //[JsonProperty("TableResult")]
        //public object TableResult { get; set; }
    }

}
