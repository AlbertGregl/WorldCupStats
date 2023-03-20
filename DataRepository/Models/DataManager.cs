using DataRepository.Dal;
using DataRepository.Properties;

namespace DataRepository.Models
{
    public class DataManager
    {
        private readonly IDataRepository dataRepo;

        private ISet<Results>? results;
        private ISet<Matches>? matches;

        public DataManager()
        {
            // get data from api or file based on settings
            if (Settings.Default.DataSource == "api")
            {
                dataRepo = RepositoryFactory.GetApiDataRepo();
            }
            else
            {
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
    }
}
