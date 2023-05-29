using DataRepository.Models;
using DataRepository.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository.Dal
{
    internal class PlayerImageFileRepo : IPlayerImageRepository
    {
        // relative path to "playerImage.txt" file in the project
        private string FILE_PATH_SET = Settings.Default.ResourcesDir + @"settings\playerImage.txt";

        public PlayerImageFileRepo()
        {
            CreateFile();
        }

        // if file not exist, create it
        public void CreateFile()
        {
            if (!File.Exists(FILE_PATH_SET))
            {
                File.Create(FILE_PATH_SET).Close();
            }
        }

        public ISet<PlayerImage> GetAllPlayerImages()
        {
            // read all lines from file
            string[] lines = File.ReadAllLines(FILE_PATH_SET);
            // create empty set
            ISet<PlayerImage> playerImages = new HashSet<PlayerImage>();
            // for each line in file
            foreach (string line in lines)
            {
                // parse line to PlayerImage object
                PlayerImage playerImage = PlayerImage.ParseFromFileLine(line);
                // add PlayerImage object to set
                playerImages.Add(playerImage);
            }
            // return set
            return playerImages;
        }

        public PlayerImage GetPlayerImage(string name, int shirtNumber)
        {
            // read all lines from file
            string[] lines = File.ReadAllLines(FILE_PATH_SET);
            // for each line in file
            foreach (string line in lines)
            {
                // parse line to PlayerImage object
                PlayerImage playerImage = PlayerImage.ParseFromFileLine(line);
                // if name and shirtNumber match
                if (playerImage.Name == name && playerImage.ShirtNumber == shirtNumber)
                {
                    // return PlayerImage object
                    return playerImage;
                }
            }
            // if not found, return null
            return null;
        }

        public void SavePlayerImage(PlayerImage playerImage)
        {
            // save PlayerImage object to file
            File.AppendAllText(FILE_PATH_SET, playerImage.FormatForFileLine() + Environment.NewLine);
        }
    }
}
