namespace DataRepository.Dal
{
    public static class RepositoryFactory
    {
        public static ISettingsRepository GetSettingsRepo() => new SettingsFileRepo();

        // two ways to get data
        public static IDataRepository GetFileDataRepo() => new JsonFileRepo();
        public static IDataRepository GetApiDataRepo() => new JsonApiRepo();
    }
}
