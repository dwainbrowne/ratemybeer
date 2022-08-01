using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Application
{
    public class ApplicationResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("message")]
        public string? Message { get; set; }

        [JsonProperty("total")]
        public int? Total { get; set; }

        [JsonProperty("data")]
        public dynamic? Data { get; set; }        
    }
}
