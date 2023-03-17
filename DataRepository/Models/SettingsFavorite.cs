using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository.Models
{
    public class SettingsFavorite
    {
        private const char DELIMIT = '|';

        public string? FavoriteTeam { get; set; }
        public HashSet<int>? FavoritePlayerShirtNums { get; set; }

        // prepare for file writing
        internal string FormatForFileLine()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(FavoriteTeam);
            sb.Append(DELIMIT);

            if (FavoritePlayerShirtNums != null && FavoritePlayerShirtNums.Count > 0)
            {
                sb.Append(string.Join(DELIMIT.ToString(), FavoritePlayerShirtNums));
            }

            return sb.ToString();
        }

        // parse from file line
        internal static SettingsFavorite ParseFromFileLine(string line)
        {
            string[] parts = line.Split(DELIMIT);

            var result = new SettingsFavorite
            {
                FavoriteTeam = parts[0]
            };

            if (parts.Length > 1)
            {
                result.FavoritePlayerShirtNums = parts.Skip(1).Select(int.Parse).ToHashSet();
            }

            return result;
        }
    }
}
