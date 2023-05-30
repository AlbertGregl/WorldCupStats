using DataRepository.Models;
using System;
using System.Windows.Media.Imaging;
using System.IO;

namespace DesktopWPF.WPFUtilities
{
    public class WPFUtilities
    {
        public static BitmapImage SetPlayerImageWPF(Player player)
        {
            string sourceImagePath = player.ImagePath;
            string destinationFolderPath = "/Resources/playerImg/";
            string fileName = Path.GetFileName(sourceImagePath);
            string destinationImagePath = Path.Combine(destinationFolderPath, fileName);
            // Set the data context for the control
            return new BitmapImage(new Uri(destinationImagePath, UriKind.Relative));
        }
    }
}
