using DataRepository.Models;
using RestSharp;
using Newtonsoft.Json;
using DataRepository.ConverterJson;


namespace DataRepository.Dal
{
    internal class JsonApiRepo : IDataRepository
    {

        private const string BASE_URL = "https://worldcup-vua.nullbit.hr/";
        private const string RESULTS_URL = "/teams/results";
        private const string MATCHES_URL = "/matches";



        public ISet<Matches> GetAllMetches(string championship)
        {
            string url = BASE_URL + championship + MATCHES_URL;

            // code from 'web.postman.co'
            var client = new RestClient();
            var request = new RestRequest(url, Method.Get);
            var response = client.Execute(request);

            // serialize json
            return JsonConvert.DeserializeObject<ISet<Matches>?>(response.Content, Converter.JsonSettings);
        }


        public ISet<Results> GetAllResults(string championship)
        {
            string url = BASE_URL + championship + RESULTS_URL;

            // code from 'web.postman.co'
            var client = new RestClient();
            var request = new RestRequest(url, Method.Get);
            var response = client.Execute(request);

            // serialize json
            return JsonConvert.DeserializeObject<ISet<Results>?>(response.Content, Converter.JsonSettings);

        }


    }
}
