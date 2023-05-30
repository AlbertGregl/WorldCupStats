using DataRepository.Models;
using System;
using System.Reflection;
using System.Threading;
using System.Windows;
using System.Resources;

namespace DesktopWPF
{
    /// <summary>
    /// Interaction logic for PlayerWindow.xaml
    /// </summary>
    public partial class PlayerWindow : Window
    {
        private Player player = new Player();

        public PlayerWindow(Player player)
        {
            InitializeComponent();
            this.player = player;

            SetLanguage();

            FillPlayerData(player);

        }

        private void SetLanguage()
        {
            try
            {
                ResourceManager resourceManager = new ResourceManager("DesktopWPF.Resources.croatian", Assembly.GetExecutingAssembly());
                // change current lozalizable language to english
                if (Properties.SettingsWPF.Default.AppLanguage == "eng")
                {
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
                    resourceManager = new ResourceManager("DesktopWPF.Resources.english", Assembly.GetExecutingAssembly());
                }
                // change current lozalizable language to croatian
                else if (Properties.SettingsWPF.Default.AppLanguage == "cro")
                {
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("hr-HR");
                    resourceManager = new ResourceManager("DesktopWPF.Resources.croatian", Assembly.GetExecutingAssembly());
                }
                TranslatePlayerForm(resourceManager);
            }
            catch (Exception ex)
            {
                //dataManager.ErrorLog(ex.Message + ", " + ex.StackTrace);
            }
        }

        private void TranslatePlayerForm(ResourceManager resourceManager)
        {
            lblPlayerWindowName.Content = resourceManager.GetString("lblPlayerWindowName");
            lblPlayerWindowShirt.Content = resourceManager.GetString("lblPlayerWindowShirt");
            lblPlayerWindowPosition.Content = resourceManager.GetString("lblPlayerWindowPosition");
            lblPlayerWindowGoals.Content = resourceManager.GetString("lblPlayerWindowGoals");
            lblPlayerWindowYellowCards.Content = resourceManager.GetString("lblPlayerWindowYellowCards");
            lblPlayerWindowCaptain.Content = resourceManager.GetString("lblPlayerWindowCaptain");
        }

        private void FillPlayerData(Player player)
        {
            // set form title to players name but substring of name only last part
            this.Title = player.Name.Substring(player.Name.IndexOf(" ") + 1);
            // Set the data for the window            
            lblPlayerWindowName.Content = lblPlayerWindowName.Content + ": " + player.Name;
            lblPlayerWindowShirt.Content = lblPlayerWindowShirt.Content + ": " + player.ShirtNumber.ToString();
            lblPlayerWindowPosition.Content = lblPlayerWindowPosition.Content + ": " + player.Position;
            // if the player is captain add emoji to the label lblPlayerWindowCaptain
            if (player.Captain)
            {
                lblPlayerWindowCaptain.Content = lblPlayerWindowCaptain.Content + " ⚽";
                lblPlayerWindowName.FontWeight = FontWeights.Bold;
            }
            else
            {
                lblPlayerWindowCaptain.Content = " ";
            }
            lblPlayerWindowGoals.Content = lblPlayerWindowGoals.Content + ": " + player.Goals.ToString();
            lblPlayerWindowYellowCards.Content = lblPlayerWindowYellowCards.Content + ": " + player.YellowCards.ToString();

            imgPlayerWindow.Source = WPFUtilities.WPFUtilities.SetPlayerImageWPF(player);
        }
    }
}
