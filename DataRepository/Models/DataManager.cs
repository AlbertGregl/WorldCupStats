using DataRepository.Dal;
using DataRepository.Properties;

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
            catch (Exception ex)
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

        // set data repository if API call failed
        public void SetFileDataRepo() => dataRepo = RepositoryFactory.GetFileDataRepo();

    }
}
