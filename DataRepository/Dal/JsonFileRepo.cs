using DataRepository.ConverterJson;
using DataRepository.Models;
using Newtonsoft.Json;

namespace DataRepository.Dal
{
    internal class JsonFileRepo : IDataRepository
    {
        // directory path to "women"
        private const string DIR_PATH = @"..\..\..\..\Resources\worldcup.sfg.io\";
        // relative path to "group_results.json"
        private const string GROUP_RESULTS_FILE_PATH = @"\group_results.json";
        // relative path to "matches.json"
        private const string MATCHES_FILE_PATH = @"\matches.json";
        // relative path to "results.json"
        private const string RESULTS_FILE_PATH = @"\results.json";
        // relative path to "teams.json"
        private const string TEAMS_FILE_PATH = @"\teams.json";


        public ISet<Matches> GetAllMetches(string championship)
        {
            string json = File.ReadAllText(DIR_PATH + championship + MATCHES_FILE_PATH);
            return JsonConvert.DeserializeObject<ISet<Matches>?>(json, Converter.JsonSettings);
        }

        public ISet<Results> GetAllResults(string championship)
        {
            string json = File.ReadAllText(DIR_PATH + championship + RESULTS_FILE_PATH);
            return JsonConvert.DeserializeObject<ISet<Results>?>(json, Converter.JsonSettings);
        }

    }
}
