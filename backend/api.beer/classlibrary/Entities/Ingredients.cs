using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Ingredients
    {
        [JsonProperty("malt")]
        public List<Malt> Malt { get; set; }

        [JsonProperty("hops")]
        public List<Hop> Hops { get; set; }

        [JsonProperty("yeast")]
        public string Yeast { get; set; }
    }

    public class Malt
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("amount")]
        public Amount Amount { get; set; }
    }

    public class Hop
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("amount")]
        public Amount Amount { get; set; }

        [JsonProperty("add")]
        public string Add { get; set; }

        [JsonProperty("attribute")]
        public string Attribute { get; set; }
    }
}
