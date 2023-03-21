using DataRepository.Models;

namespace DataRepository.Dal
{
    public interface IDataRepository
    {

        // get all metches
        ISet<Matches> GetAllMetches(string championship);
        // get all teams
        ISet<Results> GetAllResults(string championship);
    }
}
