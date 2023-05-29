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

        // image props
        public Image? Image { get; set; }
        public string? ImagePath { get; set; }

        // rang list props
        public int Goals { get; set; }
        public int YellowCards { get; set; }
        public int GamesPlayed { get; set; }

        public Player()
        {
            // default values
            Goals = 0;
            YellowCards = 0;
            GamesPlayed = 0;            
        }

        // compare by shirt number or Goal or YellowCard
        public int CompareTo(Player? other)
        {
            if (other == null)
            {
                return 1;
            }
            if (ShirtNumber != other.ShirtNumber)
            {
                return ShirtNumber.CompareTo(other.ShirtNumber);
            }
            if (Goals != other.Goals)
            {
                return Goals.CompareTo(other.Goals);
            }
            return YellowCards.CompareTo(other.YellowCards);
        }

        public override bool Equals(object? obj)
        {
            return obj is Player player &&
                   ShirtNumber == player.ShirtNumber;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ShirtNumber);
        }
    }
}
