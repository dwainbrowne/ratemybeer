using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Application
{
    public class SearchQuery : BaseData
    {
        [JsonProperty("keyword")]
        public string? Keyword { get; set; }

        //Returns all beers with ABV greater than the supplied number
        [JsonProperty("greaterThan")]
        public int? GreaterThan { get; set; }

        //Returns all beers with ABV less than the supplied number
        [JsonProperty("greaterThan")]
        public int? LessThan { get; set; }

        //Returns all beers brewed before this date, the date format is mm-yyyy e.g 10-2011
        [JsonProperty("before")]
        public string? Before { get; set; }

        //Returns all beers brewed after this date, the date format is mm-yyyy e.g 10-2011
        [JsonProperty("after")]
        public string? After { get; set; }
    }
}
