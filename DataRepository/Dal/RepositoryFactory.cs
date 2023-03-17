namespace DataRepository.Dal
{
    public static class RepositoryFactory
    {
        public static ISettingsRepository GetSettingsRepo() => new SettingsFileRepo();
        public static IDataRepository GetDataRepo() => new JsonFileRepo();
    }
}
