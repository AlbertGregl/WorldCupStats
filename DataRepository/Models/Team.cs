using Newtonsoft.Json;

namespace DataRepository.Models
{
    public class Team
    {
        [JsonProperty("country", NullValueHandling = NullValueHandling.Ignore)]
        public string? Country { get; set; }

        [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
        public string? Code { get; set; }

        [JsonProperty("goals", NullValueHandling = NullValueHandling.Ignore)]
        public int? Goals { get; set; }

        [JsonProperty("penalties", NullValueHandling = NullValueHandling.Ignore)]
        public int? Penalties { get; set; }
    }
}
