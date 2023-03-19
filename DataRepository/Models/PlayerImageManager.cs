using DataRepository.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository.Models
{
    public class PlayerImageManager
    {
        // directory path
        private static string _filePath = Settings.Default.ResourcesDir + @"playerImages\";
        // relative path to default image
        private const string IMAGE_PATH = "player_default.png";


        // get default image from path
        public Image GetDefaultImage() => Image.FromFile(_filePath + IMAGE_PATH);

        // get directory path
        public string GetImageDirectoryPath() => Application.UserAppDataPath + _filePath;

    }
}
