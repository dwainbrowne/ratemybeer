using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Application
{
    public class ErrorResponse : ApplicationResponse
    {
        [JsonProperty("message")]
        public string? Message { get; set; }

        [JsonProperty("details")]
        public string? Details { get; set; }

        public ErrorResponse()
        {
        }

        public ErrorResponse(string message, Exception e)
        {
            this.Message = message;

#if DEBUG
            this.Details = e.Message;
#endif
        }

    }
}
