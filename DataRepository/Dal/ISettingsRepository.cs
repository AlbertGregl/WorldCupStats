using DataRepository.Models;

namespace DataRepository.Dal
{
    public interface ISettingsRepository
    {
        // save settings
        void SaveSettings(SettingsLocal settings);
        // load settings
        SettingsLocal LoadSettings();

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
