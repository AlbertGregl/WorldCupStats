using DataRepository.Models;
using System;
using System.Reflection;
using System.Threading;
using System.Windows;
using System.Resources;


namespace DesktopWPF
{
    /// <summary>
    /// Interaction logic for TeamOverviewWindow.xaml
    /// </summary>
    public partial class TeamOverviewWindow : Window
    {
        private Results result = new Results();
        private int windowWidth;
        private int windowHeight;
        private string language;

        public TeamOverviewWindow(Results result, int windowWidth, int windowHeight, string language)
        {
            InitializeComponent();
            this.result = result;
            this.windowWidth = windowWidth;                
            this.windowHeight = windowHeight;
            this.language = language;

            // setup window size
            this.Width = windowWidth;
            this.Height = windowHeight;

            SetLanguage();

            FillInResultData();
        }

        private void FillInResultData()
        {
            lblCountry.Content = result.Country;
            lblFifaCode.Content = result.FifaCode;
            lblWins.Content = result.Wins;
            lblDraws.Content = result.Draws;
            lblLosses.Content = result.Losses;
            lblGamesPlayed.Content = result.GamesPlayed;
            lblGoalsFor.Content = result.GoalsFor;
            lblGoalsAgainst.Content = result.GoalsAgainst;
            lblGoalDifferential.Content = result.GoalDifferential;
        }

        private void SetLanguage()
        {
            try
            {
                ResourceManager resourceManager = new ResourceManager("DesktopWPF.Resources.croatian", Assembly.GetExecutingAssembly());
                // change current lozalizable language to english
                if (language == "eng")
                {
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
                    resourceManager = new ResourceManager("DesktopWPF.Resources.english", Assembly.GetExecutingAssembly());
                }
                // change current lozalizable language to croatian
                else if (language == "cro")
                {
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("hr-HR");
                    resourceManager = new ResourceManager("DesktopWPF.Resources.croatian", Assembly.GetExecutingAssembly());
                }
                TranslateMainForm(resourceManager);
            }
            catch (Exception ex)
            {
                //dataManager.ErrorLog(ex.Message + ", " + ex.StackTrace);
            }
        }

        private void TranslateMainForm(ResourceManager resourceManager)
        {
            this.Title = $"{resourceManager.GetString("TeamOverview")} ({result.FifaCode})";
            lblCountryRowTitle.Content = resourceManager.GetString("lblCountryRowTitle");
            lblFifaCodeRowTitle.Content = resourceManager.GetString("lblFifaCodeRowTitle");
            lblWinsRowTitle.Content = resourceManager.GetString("lblWinsRowTitle");
            lblDrawsRowTitle.Content = resourceManager.GetString("lblDrawsRowTitle");
            lblLossesRowTitle.Content = resourceManager.GetString("lblLossesRowTitle");
            lblGamesPlayedRowTitle.Content = resourceManager.GetString("lblGamesPlayedRowTitle");
            lblGoalsForRowTitle.Content = resourceManager.GetString("lblGoalsForRowTitle");
            lblGoalsAgainstRowTitle.Content = resourceManager.GetString("lblGoalsAgainstRowTitle");
            lblGoalDifferentialRowTitle.Content = resourceManager.GetString("lblGoalDifferentialRowTitle");
        }
    }
}
