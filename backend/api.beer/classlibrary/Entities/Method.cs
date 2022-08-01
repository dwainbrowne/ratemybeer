using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Method
    {
        [JsonProperty("mash_temp")]
        public List<MashTemp> MashTemp { get; set; }

        [JsonProperty("fermentation")]
        public Fermentation Fermentation { get; set; }

        [JsonProperty("twist")]
        public object Twist { get; set; }
    }


    public class MashTemp
    {
        [JsonProperty("temp")]
        public Temp Temp { get; set; }

        [JsonProperty("duration")]
        public int Duration { get; set; }
    }


    public class Fermentation
    {
        [JsonProperty("temp")]
        public Temp Temp { get; set; }
    }

}
