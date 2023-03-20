using DataRepository.Models;

namespace DataRepository.Dal
{
    public interface IDataRepository
    {
        // get all metches from File
        ISet<Matches> GetAllMetches(string championship);
        // get all teams from File
        ISet<Results> GetAllResults(string championship);
    }
}
