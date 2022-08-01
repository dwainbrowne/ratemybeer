using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Ratings : BaseData
    {
        [JsonProperty("username")]
        public string? UserName { get; set; }

        [JsonProperty("rating")]
        public int? Rating { get; set; }

        [JsonProperty("comments")]
        public string? Comments { get; set; }

        [JsonProperty("parentId")]
        public string? ParentId { get; set; }
    }
}
