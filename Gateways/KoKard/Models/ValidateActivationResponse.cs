﻿// Generated by Xamasoft JSON Class Generator
// http://www.xamasoft.com/json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Embily.Gateways.KoKard.Models
{
    public class ValidateActivationTableItem 
    {
        [JsonProperty("ActivationStatus")]
        public string ActivationStatus { get; set; }
    }

    public class ValidateActivationTableResult
    {

        [JsonProperty("ValidateActivationTable")]
        public ValidateActivationTableItem[] ValidateActivationTable { get; set; }
    }

    public class ValidateActivationResponse : BaseResponse
    {
        [JsonProperty("AdditionalInfo")]
        public AdditionalInfo AdditionalInfo { get; set; }

        [JsonProperty("TableResult")]
        public ValidateActivationTableResult TableResult { get; set; }
    }

}
