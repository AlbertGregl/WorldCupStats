using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository.Models
{
    public class Log
    {
        private const char DELIMIT = '|';

        public DateTime? dateTime { get; set; }
        public string? errorMessage { get; set; }

        // prepare for file writing
        internal string FormatForFileLine()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(dateTime);
            sb.Append(DELIMIT);
            sb.Append(errorMessage);
            return sb.ToString();
        }
    }
}
