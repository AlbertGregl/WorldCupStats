
namespace DataRepository.Models

{
    public class Settings
    {
        private const char DELIMIT = '|';

        public string? Championship { get; set; }
        public string? Language { get; set; }

        // prepare for file writing
        internal string FormatForFileLine() => $"{Championship}{DELIMIT}{Language}";

        // parse from file line
        internal static Settings ParseFromFileLine(string line)
        {
            string[] parts = line.Split(DELIMIT);
            return new Settings
            {
                Championship = parts[0],
                Language = parts.Length > 1 ? parts[1] : string.Empty
            };
        }
    }
}
