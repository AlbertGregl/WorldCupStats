using DataRepository.Models;
using System;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Media;

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

            // Set the data context for the control
            imgPlayerControl.Source = WPFUtilities.WPFUtilities.SetPlayerImageWPF(player);
            lblPlayerControlText.Text = $"{player.Name} [{player.ShirtNumber}]";
        }
        public PlayerControl()
        {
            InitializeComponent();
        }

        private void controlPlayer_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // open the player details window with player
            PlayerWindow playerDetailsWindow = new PlayerWindow(player);
            playerDetailsWindow.Show();
            DoubleAnimation rotateAnimation = new DoubleAnimation(0, 360, TimeSpan.FromSeconds(0.3));
            RotateTransform rotateTransform = new RotateTransform();
            playerDetailsWindow.RenderTransform = rotateTransform;
            // Animate the rotation
            rotateTransform.BeginAnimation(RotateTransform.AngleProperty, rotateAnimation);

        }
    }
}
