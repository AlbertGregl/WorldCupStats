using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataRepository.Models.Player;

namespace DataRepository.Models
{
    public class Player : IComparable<Player>
    {
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string? Name { get; set; }

        [JsonProperty("captain", NullValueHandling = NullValueHandling.Ignore)]
        public bool Captain { get; set; }

        [JsonProperty("shirt_number", NullValueHandling = NullValueHandling.Ignore)]
        public int ShirtNumber { get; set; }

        [JsonProperty("position", NullValueHandling = NullValueHandling.Ignore)]
        public string? Position { get; set; }


        public bool Favorite { get; set; }

        // compare by shirt number
        public int CompareTo(Player? other)
        {
            if (other == null) return 1;
            return ShirtNumber.CompareTo(other.ShirtNumber);
        }

        public override bool Equals(object? obj)
            => obj is Player player && ShirtNumber == player.ShirtNumber;

        public override int GetHashCode() => HashCode.Combine(ShirtNumber);
    }
}
