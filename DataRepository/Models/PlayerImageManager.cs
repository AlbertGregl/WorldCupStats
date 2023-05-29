using DataRepository.Dal;
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
        private readonly IPlayerImageRepository imgManager;

        public PlayerImageManager()
        {
            imgManager = RepositoryFactory.GetPlayerImageFileRepo();
        }

        // directory path
        private static string _filePath = Settings.Default.ResourcesDir + @"playerImages\";
        // relative path to default image
        private const string IMAGE_PATH = "player_default.png";


        // get default image from path
        public Image GetDefaultImage() => Image.FromFile(_filePath + IMAGE_PATH);

        // get directory path
        public string GetImageDirectoryPath() => Application.UserAppDataPath + _filePath;

        // get image from path
        public Image GetImage(string path) => Image.FromFile(path);

        // save image for player
        public void SavePlayerImage(Player player)
        {
            PlayerImage playerImage = new PlayerImage
            {
                Name = player.Name,
                ShirtNumber = player.ShirtNumber,
                ImagePath = player.ImagePath
            };
            imgManager.SavePlayerImage(playerImage);
        }

        // load all saved images
        public ISet<PlayerImage> LoadAllPlayerImages() => imgManager.GetAllPlayerImages();

        // get image for player from file
        public Player LoadPlayerImage(Player player)
        {
            PlayerImage playerImage = imgManager.GetPlayerImage(player.Name, player.ShirtNumber);
            if (playerImage != null)
            {
                player.ImagePath = playerImage.ImagePath;
                player.Image = GetImageFromPath(player.ImagePath);
                return player;
            }
            // default image
            player.ImagePath = null;
            player.Image = GetDefaultImage();
            return player;
        }

        private Image? GetImageFromPath(string imagePath)
        {
            if (imagePath == null)
            {
                return null;
            }
            else
            {
                return Image.FromFile(imagePath);
            }
        }

        public string? GetRelativeImagePath(string fileName)
        {
            // from file name use substring of image name only
            if (fileName == null)
            {
                return null;
            }
            else
            {
                return _filePath + fileName;
            }
        }
    }
}
