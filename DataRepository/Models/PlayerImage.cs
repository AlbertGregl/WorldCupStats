using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataRepository.Models
{
    public class PlayerImage
    {
        private const char DELIMIT = '|';

        public string Name { get; set; }
        public int ShirtNumber { get; set; }
        public string ImagePath { get; set; }

        // prepare for file writing
        internal string FormatForFileLine()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Name);
            sb.Append(DELIMIT);
            sb.Append(ShirtNumber);
            sb.Append(DELIMIT);
            sb.Append(ImagePath);
            return sb.ToString();
        }

        // parse from file line
        internal static PlayerImage ParseFromFileLine(string line)
        {
            string[] parts = line.Split(DELIMIT);
            return new PlayerImage
            {
                Name = parts[0],
                ShirtNumber = int.Parse(parts[1]),
                ImagePath = parts[2]
            };
        }

        public override bool Equals(object? obj)
        {
            return obj is Player player &&
                   Name == player.Name &&
                   ShirtNumber == player.ShirtNumber;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, ShirtNumber);
        }
    }
}
