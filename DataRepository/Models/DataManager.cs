﻿using DataRepository.Dal;

namespace DataRepository.Models
{
    public class DataManager
    {
        private readonly IDataRepository dataRepo;

        private ISet<Results>? results;
        private ISet<Matches>? matches;

        public DataManager()
        {
            dataRepo = RepositoryFactory.GetDataRepo();
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