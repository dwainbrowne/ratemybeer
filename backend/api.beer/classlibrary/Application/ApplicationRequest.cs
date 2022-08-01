using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Application
{
    public class ApplicationRequest
    {
       
        [JsonProperty("type")]
        public string? Type { get; set; }
        
    }
}
