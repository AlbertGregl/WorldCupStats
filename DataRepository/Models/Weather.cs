using DataRepository.ConverterJson;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository.Models
{
    public class Weather
    {

        [JsonProperty("humidity", NullValueHandling = NullValueHandling.Ignore)]
        public int? Humidity { get; set; }

        [JsonProperty("temp_celsius", NullValueHandling = NullValueHandling.Ignore)]
        public int? TempCelsius { get; set; }

        [JsonProperty("temp_farenheit", NullValueHandling = NullValueHandling.Ignore)]
        public int? TempFarenheit { get; set; }

        [JsonProperty("wind_speed", NullValueHandling = NullValueHandling.Ignore)]
        public int? WindSpeed { get; set; }

        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string? Description { get; set; }
    }
}
