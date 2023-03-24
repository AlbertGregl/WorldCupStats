using DataRepository.Dal;
using DataRepository.Exceptions;
using DataRepository.Properties;
using System.Security.Cryptography.X509Certificates;

namespace DataRepository.Models
{
    public class DataManager
    {
        // readonly removed to implement automatic switch to file data repository
        private IDataRepository dataRepo;

        private ISet<Results>? results;
        private ISet<Matches>? matches;

        public DataManager()
        {
            try
            {
                // Try to get data from API first
                dataRepo = RepositoryFactory.GetApiDataRepo();
            }
            catch (ApiGetException ex)
            {
                // save log message;
                ErrorLog(ex.Message);
                // if API call failed, get data from file
                dataRepo = RepositoryFactory.GetFileDataRepo();
            }

        }

        public ISet<Results> GetResultsByChampionship (string championship)
        {
            // get results men or women
            results = dataRepo.GetAllResults(championship);
            return new HashSet<Results>(results);
        }

        public ISet<Matches> GetMatchesByChampionship (string championship) 
        {
            // get results men or women
            matches = dataRepo.GetAllMetches(championship);
            return new HashSet<Matches>(matches);
        }

        // set data repository if API call failed
        public void SetFileDataRepo() => dataRepo = RepositoryFactory.GetFileDataRepo();

        // log error with Logger
        public void ErrorLog(string error)
        {
            // prepare log object
            Log log = new Log
            {
                dateTime = DateTime.Now,
                errorMessage = error
            };
            Logger.SaveLog(log);
        } 

    }
}
