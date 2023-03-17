using DataRepository.Models;

namespace DataRepository.Dal
{
    public interface ISettingsRepository
    {
        // save settings
        void SaveSettings(Settings settings);
        // load settings
        Settings LoadSettings();
        // create settings file
        bool SettingsFileCreated();
        // save favorite settings
        void SaveSettingsFavorite(SettingsFavorite settings);
        // load favorite settings
        SettingsFavorite LoadSettingsFavorite();
        // create favorite settings file
        bool SettingsFavoriteFileCreated();
    }
}
