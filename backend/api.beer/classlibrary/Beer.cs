using Newtonsoft.Json;

namespace ClassLibrary
{
 

    public class Beer
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("tagline")]
        public string Tagline { get; set; }

        [JsonProperty("first_brewed")]
        public string FirstBrewed { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }

        [JsonProperty("abv")]
        public double Abv { get; set; }

        [JsonProperty("ibu")]
        public int Ibu { get; set; }

        [JsonProperty("target_fg")]
        public int TargetFg { get; set; }

        [JsonProperty("target_og")]
        public int TargetOg { get; set; }

        [JsonProperty("ebc")]
        public int Ebc { get; set; }

        [JsonProperty("srm")]
        public int Srm { get; set; }

        [JsonProperty("ph")]
        public double Ph { get; set; }

        [JsonProperty("attenuation_level")]
        public int AttenuationLevel { get; set; }

        [JsonProperty("volume")]
        public Volume Volume { get; set; }

        [JsonProperty("boil_volume")]
        public BoilVolume BoilVolume { get; set; }

        [JsonProperty("method")]
        public Method Method { get; set; }

        [JsonProperty("ingredients")]
        public Ingredients Ingredients { get; set; }

        [JsonProperty("food_pairing")]
        public List<string> FoodPairing { get; set; }

        [JsonProperty("brewers_tips")]
        public string BrewersTips { get; set; }

        [JsonProperty("contributed_by")]
        public string ContributedBy { get; set; }
    }

}