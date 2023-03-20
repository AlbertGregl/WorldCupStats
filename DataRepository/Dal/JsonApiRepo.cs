using DataRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace DataRepository.Dal
{
    internal class JsonApiRepo : IDataRepository
    {

        private const string BASE_URL = "https://worldcup-vua.nullbit.hr/";
        private const string RESULTS_URL = "/teams/results";
        private const string MATCHES_URL = "/matches";



        public ISet<Matches> GetAllMetches(string championship)
        {
            var options = new RestClientOptions("")
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest("https://worldcup-vua.nullbit.hr/men/matches", Method.Get);
            //RestResponse response = await client.ExecuteAsync(request);
            
            //Console.WriteLine(response.Content);

            throw new NotImplementedException();
        }
        public ISet<Results> GetAllResults(string championship)
        {
            throw new NotImplementedException();
        }


    }
}
