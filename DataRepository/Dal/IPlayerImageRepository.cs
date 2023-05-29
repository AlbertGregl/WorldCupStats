using DataRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository.Dal
{
    public interface IPlayerImageRepository
    {
        // get all player images
        ISet<PlayerImage> GetAllPlayerImages();

        // get player image by name and shirt number
        PlayerImage GetPlayerImage(string name, int shirtNumber);

        // save player image
        void SavePlayerImage(PlayerImage playerImage);

    }
}
