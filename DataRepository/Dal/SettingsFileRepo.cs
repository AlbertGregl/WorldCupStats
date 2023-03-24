using DataRepository.Models;
using DataRepository.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository.Dal
{
    internal class SettingsFileRepo : ISettingsRepository
    {
        // relative path to "settings.txt" file in the project
        private string FILE_PATH_SET = Settings.Default.ResourcesDir + @"settings\settings.txt";
        // relative path to "settings_favorite.txt" file in the project
        private string FILE_PATH_SET_FAV = Settings.Default.ResourcesDir + @"settings\settings_favorite.txt";
        
        public bool SettingsFileCreated()
        {
            if (File.Exists(FILE_PATH_SET))
            {
                return true;
            }
            return false;
        }

        public SettingsLocal LoadSettings()
            => SettingsLocal.ParseFromFileLine(File.ReadAllText(FILE_PATH_SET));

        public void SaveSettings(SettingsLocal settings) 
            => File.WriteAllText(FILE_PATH_SET, settings.FormatForFileLine());


        public bool SettingsFavoriteFileCreated()
        {
            if (File.Exists(FILE_PATH_SET_FAV))
            {
                return true;
            }
            return false;
        }

        public SettingsFavorite LoadSettingsFavorite()
            => SettingsFavorite.ParseFromFileLine(File.ReadAllText(FILE_PATH_SET_FAV));

        public void SaveSettingsFavorite(SettingsFavorite settingsFavorite)
            => File.WriteAllText(FILE_PATH_SET_FAV, settingsFavorite.FormatForFileLine());
    }
}
