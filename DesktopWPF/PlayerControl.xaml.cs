using DataRepository.Models;
using System;
using System.IO;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace DesktopWPF
{
    /// <summary>
    /// Interaction logic for PlayerControl.xaml
    /// </summary>
    public partial class PlayerControl : UserControl
    {
        private Player player = new Player();

        public PlayerControl(Player player)
        {
            InitializeComponent();

            this.player = player;

            string sourceImagePath = player.ImagePath;
            string destinationFolderPath = "/Resources/playerImg/";
            string fileName = Path.GetFileName(sourceImagePath);
            string destinationImagePath = Path.Combine(destinationFolderPath, fileName);

            // Set the data context for the control
            imgPlayerControl.Source = new BitmapImage(new Uri(destinationImagePath, UriKind.Relative));
            lblPlayerControlText.Text = $"{player.Name} [{player.ShirtNumber}]";
        }
        public PlayerControl()
        {
            InitializeComponent();
        }
    }
}
