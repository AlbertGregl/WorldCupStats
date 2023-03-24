using DataRepository.Models;
using DataRepository.Properties;

namespace DataRepository.Dal
{
    internal class Logger
    {
        // relative path to "error_log.txt" file in the project
        private static string ERROR_FILE_PATH = Settings.Default.ResourcesDir + @"errorLog\error_log.txt";

        //  save log to file
        public static void SaveLog(Log log)
            => File.AppendAllText(ERROR_FILE_PATH, log.FormatForFileLine() + Environment.NewLine);
    }
}
