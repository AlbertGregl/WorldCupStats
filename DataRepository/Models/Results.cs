using Newtonsoft.Json;
using DataRepository.ConverterJson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Metrics;

namespace DataRepository.Models
{
    public class Results : IComparable<Results>
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public int Id { get; set; }

        [JsonProperty("country", NullValueHandling = NullValueHandling.Ignore)]
        public string? Country { get; set; }

        [JsonProperty("alternate_name", NullValueHandling = NullValueHandling.Ignore)]
        public string? AlternateName { get; set; }

        [JsonProperty("fifa_code", NullValueHandling = NullValueHandling.Ignore)]
        public string? FifaCode { get; set; }

        [JsonProperty("group_id", NullValueHandling = NullValueHandling.Ignore)]
        public int GroupId { get; set; }

        [JsonProperty("group_letter", NullValueHandling = NullValueHandling.Ignore)]
        public char GroupLetter { get; set; }

        [JsonProperty("wins", NullValueHandling = NullValueHandling.Ignore)]
        public int Wins { get; set; }

        [JsonProperty("draws", NullValueHandling = NullValueHandling.Ignore)]
        public int Draws { get; set; }

        [JsonProperty("losses", NullValueHandling = NullValueHandling.Ignore)]
        public int Losses { get; set; }

        [JsonProperty("games_played", NullValueHandling = NullValueHandling.Ignore)]
        public int GamesPlayed { get; set; }

        [JsonProperty("points", NullValueHandling = NullValueHandling.Ignore)]
        public int Points { get; set; }

        [JsonProperty("goals_for", NullValueHandling = NullValueHandling.Ignore)]
        public int GoalsAgainst { get; set; }

        [JsonProperty("goals_against", NullValueHandling = NullValueHandling.Ignore)]
        public int GoalDifferential { get; set; }

        // implemetn IComparable with ID, FifaCode and GroupId
        public int CompareTo(Results? other)
        {
            if (other is null) return 1;
            if (Id > other.Id) return 1;
            if (Id < other.Id) return -1;
            if (FifaCode is null) return 1;
            if (other.FifaCode is null) return -1;
            if (FifaCode.CompareTo(other.FifaCode) > 0) return 1;
            if (FifaCode.CompareTo(other.FifaCode) < 0) return -1;
            if (GroupId > other.GroupId) return 1;
            if (GroupId < other.GroupId) return -1;
            return 0;
        }

        public override bool Equals(object? obj)
            => obj is Results results && Id == results.Id && FifaCode == results.FifaCode;

        public override int GetHashCode() => HashCode.Combine(Id, FifaCode);
        
        public override string ToString() => 
            $"{Id}, {Country}, {AlternateName}, {FifaCode}, {GroupId}, {GroupLetter}, " +
            $"{Wins}, {Draws}, {Losses}, {GamesPlayed}, {Points}, {GoalsAgainst}, {GoalDifferential}.";

    }
}
