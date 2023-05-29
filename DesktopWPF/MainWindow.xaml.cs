using DataRepository.Dal;
using DataRepository.Models;
using System;
using System.Reflection;
using System.Threading;
using System.Windows;
using System.Resources;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media.Animation;

namespace DesktopWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static DataManager dataManager = new DataManager();
        private ISet<Results> results = new HashSet<Results>();
        private ISet<Matches> matches = new HashSet<Matches>();

        private static PlayerImageManager playerImageManager = new PlayerImageManager();

        private ISet<Player> playersFavorite = new HashSet<Player>();
        private ISet<Player> playersRival = new HashSet<Player>();

        private const string cro = "cro";
        private const string eng = "eng";
        private const string women = "women";
        private const string men = "men";
        private string MSGBoxExitText = "";
        private string MSGBoxExitTitle = "";
        private string MSGBoxRestartText = "";
        private string MSGBoxRestartTitle = "";
        private string MSGBoxFavTeamText = "";

        private readonly ISettingsRepository settingsRepo;
        public SettingsLocal AppSettings { get; set; }
        private SettingsFavorite settingsFavorite;

        public MainWindow()
        {
            InitializeComponent();

            // screen settings
            string screenResolution = Properties.SettingsWPF.Default.ScreenResolution;
            ApplySelectedScreenResolution(screenResolution);

            // initialize settings
            settingsRepo = RepositoryFactory.GetSettingsRepo();
            // create favorite settings file with default values
            settingsFavorite = new SettingsFavorite();
            // set default settings
            AppSettings = new SettingsLocal();
            // check if settings file exists
            CheckIfSettingsFileExists();
            // if settings favorite file does not exist set default values
            CheckIfSettingsFavoriteFileExists();
            // change current lozalizable language
            SetLanguage();

            // hide button for setting favorite team
            btnSetFavTeam.Visibility = Visibility.Hidden;
        }

        private void CheckIfSettingsFavoriteFileExists()
        {
            if (!settingsRepo.SettingsFavoriteFileCreated())
            {
                settingsFavorite.FavoriteTeam = "Croatia";
                settingsFavorite.FavoritePlayerShirtNums = new HashSet<int>() { 0 };
            }
            else
            {
                // load settings favorite from file
                settingsFavorite = settingsRepo.LoadSettingsFavorite();
            }
        }

        private void SetLanguage()
        {
            try
            {
                ResourceManager resourceManager = new ResourceManager("DesktopWPF.Resources.croatian", Assembly.GetExecutingAssembly());
                // change current lozalizable language to english
                if (AppSettings.Language == "eng")
                {
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
                    resourceManager = new ResourceManager("DesktopWPF.Resources.english", Assembly.GetExecutingAssembly());
                }
                // change current lozalizable language to croatian
                else if (AppSettings.Language == "cro")
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
            this.Title = resourceManager.GetString("MainWindowForm");
            TabSettings.Header = resourceManager.GetString("TabSettings");
            TabWorldCup.Header = resourceManager.GetString("TabWorldCup");
            lbLanguage.Content = resourceManager.GetString("lbLanguage");
            rbCroatian.Content = resourceManager.GetString("rbCroatian");
            rbEnglish.Content = resourceManager.GetString("rbEnglish");
            lbWorldCup.Content = resourceManager.GetString("lbWorldCup");
            rbMen.Content = resourceManager.GetString("rbMen");
            rbWomen.Content = resourceManager.GetString("rbWomen");
            MSGBoxExitTitle = resourceManager.GetString("FormClosingName");
            MSGBoxExitText = resourceManager.GetString("FormClosingText");
            MSGBoxRestartTitle = resourceManager.GetString("FormRestartName");
            MSGBoxRestartText = resourceManager.GetString("FormRestartText");
            MSGBoxFavTeamText = resourceManager.GetString("MSGBoxFavTeamText");
            lblScreenResolution.Content = resourceManager.GetString("lblScreenResolution");
            rbSmallScreen.Content = resourceManager.GetString("rbSmallScreen");
            rbMediumScreen.Content = resourceManager.GetString("rbMediumScreen");
            rbFullScreen.Content = resourceManager.GetString("rbFullScreen");
            btnSaveSettings.Content = resourceManager.GetString("btnSaveSettings");
            lblFavoriteTeam.Content = resourceManager.GetString("lblFavoriteTeam");
            lblRivalTeam.Content = resourceManager.GetString("lblRivalTeam");
            btnSetFavTeam.Content = resourceManager.GetString("btnSetFavTeam");
            lblResultDisplay.Content = resourceManager.GetString("lblResultDisplay");
            btnTeamOvrwFavorite.Content = resourceManager.GetString("TeamOverview");
            btnTeamOvrwRival.Content = resourceManager.GetString("TeamOverview");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {           
            // load results & matches and display them
            using (LoadingWindow loadingWindow = new LoadingWindow(LoadResultsAndMetches))
            {
                //show loading form if operation takes longer than expected
                loadingWindow.ShowDialog();
            }

            // fill up favorite team combo box with data
            FillUpFavoriteTeamComboBox();
            // fill up rival team combo box with data
            FillUpRivalTeamComboBox();

        }

        private void FillUpRivalTeamComboBox()
        {
            // serch for rival team in matches
            foreach (var match in matches)
            {
                if (settingsFavorite.FavoriteTeam == match.HomeTeamCountry)
                {
                    cmbRivalTeam.Items.Add($"{match.AwayTeamCountry} ({match.AwayTeam.Code})");
                }
                else if (settingsFavorite.FavoriteTeam == match.AwayTeamCountry)
                {
                    cmbRivalTeam.Items.Add($"{match.HomeTeamCountry} ({match.HomeTeam.Code})");
                }
            }
        }

        private void FillUpFavoriteTeamComboBox()
        {
            // sort the resluts by GroupId
            results.OrderBy(x => x.GroupId).ToHashSet();

            // display Country and FifaCode in comboBox
            foreach (var result in results)
            {
                cmbFavoriteTeam.Items.Add($"{result.Country} ({result.FifaCode})");

                // record fav team fifa code in tag from fav settings
                if (result.Country == settingsFavorite.FavoriteTeam)
                {
                    cmbFavoriteTeam.Tag = result.FifaCode;
                }
            }
            // sort cmbFavoriteTeam
            cmbFavoriteTeam.Items.SortDescriptions.Add(new System.ComponentModel.SortDescription("", System.ComponentModel.ListSortDirection.Ascending));

            // display fav team in cmbFavoriteTeam
            cmbFavoriteTeam.SelectedItem = $"{settingsFavorite.FavoriteTeam} ({cmbFavoriteTeam.Tag})";

            // hide button for setting favorite team
            btnSetFavTeam.Visibility = Visibility.Hidden;
        }

        private void LoadResultsAndMetches()
        {
            try
            {
                results = dataManager.GetResultsByChampionship(AppSettings.Championship);
                matches = dataManager.GetMatchesByChampionship(AppSettings.Championship);
            }
            catch (Exception ex)
            {
                // save log message;
                dataManager.ErrorLog(ex.Message);
                // load results from file
                dataManager.SetFileDataRepo();
                // load results based on settings
                results = dataManager.GetResultsByChampionship(AppSettings.Championship);
                matches = dataManager.GetMatchesByChampionship(AppSettings.Championship);
                // display that data is loaded from file (lblConnection = offline)
                lblConnection.Content = "Offline";
            }


        }

        private void ApplySelectedScreenResolution(string screenResolution)
        {
            if (screenResolution == "Full")
            {
                WindowState = WindowState.Maximized;
            }
            else if (screenResolution == "Medium")
            {
                Width = 1024;
                Height = 768;
            }
            else if (screenResolution == "Small")
            {
                Width = 800;
                Height = 600;
            }           
            
        }

        private void CheckIfSettingsFileExists()
        {
            if(!settingsRepo.SettingsFileCreated())
            {
                // hide <TabItem Header="World Cup">
                TabWorldCup.Visibility = Visibility.Hidden;
                SaveAppSettings();
                // hide <TabItem Header="World Cup">
                TabWorldCup.Visibility = Visibility.Visible;
            }
            else
            {
                // load settings
                AppSettings = settingsRepo.LoadSettings();
                // check radio buttons based on settings
                SetupAppSettingsRadioButtons();
                // display and open world cup tab
                TabWorldCup.Visibility = Visibility.Visible;
                TabWorldCup.IsSelected = true;
            }
        }

        private void SetupAppSettingsRadioButtons()
        {
            if (AppSettings.Language == cro)
            {
                rbCroatian.IsChecked = true;
            }
            else
            {
                rbEnglish.IsChecked = true;
            }
            if (AppSettings.Championship == men)
            {
                rbMen.IsChecked = true;
            }
            else
            {
                rbWomen.IsChecked = true;
            }
            if (Properties.SettingsWPF.Default.ScreenResolution == "Full")
            {                
                rbFullScreen.IsChecked = true;
            }
            else if (Properties.SettingsWPF.Default.ScreenResolution == "Medium")
            {                
                rbMediumScreen.IsChecked = true;
            }
            else if (Properties.SettingsWPF.Default.ScreenResolution == "Small")
            {                
                rbSmallScreen.IsChecked = true;
            }
        }

        private void SaveAppSettings()
        {
            string initialResolution = Properties.SettingsWPF.Default.ScreenResolution;

            // set settings based on choice of radio buttons
            if (rbCroatian.IsChecked == true)
            {
                AppSettings.Language = cro;
            }
            else
            {
                AppSettings.Language = eng;
            }
            if (rbMen.IsChecked == true)
            {
                AppSettings.Championship = men;
            }
            else
            {
                AppSettings.Championship = women;
            }

            if (rbFullScreen.IsChecked == true)
            {
                Properties.SettingsWPF.Default.ScreenResolution = "Full";
            }                
            else if (rbMediumScreen.IsChecked == true)
            {
                Properties.SettingsWPF.Default.ScreenResolution = "Medium";
            }
            else if (rbSmallScreen.IsChecked == true)
            {
                Properties.SettingsWPF.Default.ScreenResolution = "Small";
            }

            if (initialResolution != Properties.SettingsWPF.Default.ScreenResolution)
            {
                // prompt user that for changing the resolution application will have to be reloaded
                MessageBoxResult result = MessageBox.Show(MSGBoxRestartText, MSGBoxRestartTitle, MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    // save settings
                    SaveSettingsUtil();

                    // unsubscribe from events to prevent multiple event firing
                    this.Closing -= MainWindowForm_Closing;
                    // restart the application
                    System.Windows.Forms.Application.Restart();
                    Application.Current.Shutdown();
                }
            }

            // save settings
            SaveSettingsUtil();
            // open world cup tab
            TabWorldCup.IsSelected = true;
        }

        private void SaveSettingsUtil()
        {
            Properties.SettingsWPF.Default.Save();
            settingsRepo.SaveSettings(AppSettings);
            // change current lozalizable language
            SetLanguage();
        }

        private void TabControl_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            SetupAppSettingsRadioButtons();
        }

        private void MainWindowForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // prompt use if he realy wants to close the app
            MessageBoxResult result = MessageBox.Show(MSGBoxExitText, MSGBoxExitTitle, MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                // before exit store favorite settings
                settingsRepo.SaveSettingsFavorite(settingsFavorite);
            }
            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btnSaveSettings_Click(object sender, RoutedEventArgs e)
        {
            SaveAppSettings();
        }

        private void btnSetFavTeam_Click(object sender, RoutedEventArgs e)
        {
            // set favorite team in settingsFavorite only name is needed "Croatia (CRO)"
            settingsFavorite.FavoriteTeam = cmbFavoriteTeam.Text.Substring(0, cmbFavoriteTeam.Text.IndexOf("(") - 1);
            // store favorite settings
            settingsRepo.SaveSettingsFavorite(settingsFavorite);

            // clear combo boxes
            cmbFavoriteTeam.Items.Clear();
            cmbRivalTeam.Items.Clear();

            // fill up favorite team combo box with data
            FillUpFavoriteTeamComboBox();
            // fill up rival team combo box with data
            FillUpRivalTeamComboBox();

            // prompt descrete success message
            MessageBox.Show(MSGBoxFavTeamText);
            
        }

        private void cmbFavoriteTeam_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // if selections changes unhide btnSetFavTeam
            btnSetFavTeam.Visibility = Visibility.Visible;
        }

        private void cmbRivalTeam_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // check if cmbRivalTeam is not empty and cmbRivalTeam.SelectedItem is not null
            if (cmbRivalTeam.Items.Count > 0 && cmbRivalTeam.SelectedItem != null)
            {
                //set selected item trimed for name only
                string rivalTeam = cmbRivalTeam.SelectedItem.ToString().Substring(0, cmbRivalTeam.SelectedItem.ToString().IndexOf("(") - 1);

                string favoriteTeam = settingsFavorite.FavoriteTeam;
                // search for rival team and favorite team metch in matches
                DisplayGameStats(rivalTeam, favoriteTeam);
            }

        }

        private void DisplayGameStats(string rivalTeam, string favoriteTeam)
        {
            // clear playersFavorite and playersRival sets
            playersFavorite.Clear();
            playersRival.Clear();

            foreach (var match in matches)
            {
                if (favoriteTeam == match.HomeTeamCountry && rivalTeam == match.AwayTeamCountry)
                {
                    lblMatchResult.Content = match.HomeTeam.Goals + " : " + match.AwayTeam.Goals;
                    try
                    {
                        playersFavorite = GetHomeTeamData(match);
                        playersRival = GetAwayTeamData(match);
                    }
                    catch (Exception ex)
                    {
                        //dataManager.ErrorLog(ex.Message + ", " + ex.StackTrace);
                    }
                }
                else if (rivalTeam == match.HomeTeamCountry && favoriteTeam == match.AwayTeamCountry)
                {
                    lblMatchResult.Content = match.AwayTeam.Goals + " : " + match.HomeTeam.Goals;
                    try
                    {
                        playersFavorite = GetAwayTeamData(match);
                        playersRival = GetHomeTeamData(match);
                    }
                    catch (Exception ex)
                    {
                        //dataManager.ErrorLog(ex.Message + ", " + ex.StackTrace);
                    }
                }
            }
        }

        private ISet<Player> GetHomeTeamData(Matches match)
        {
            ISet<Player> pSet = new HashSet<Player>();
            // add players from starting eleven and substitutes
            match.HomeTeamStatistics.StartingEleven.ForEach(x =>
            {
                pSet.Add(x);
                x = playerImageManager.LoadPlayerImage(x);
            });

            // add goal and yellow cards to player
            match.HomeTeamEvents.ForEach(x =>
            {
                if (x.TypeOfEvent == "goal" || x.TypeOfEvent == "goal-penalty")
                {
                    //pSet.Where(y => y.Name == x.Player).FirstOrDefault().Goals++;
                    Player player = pSet.First(y => y.Name == x.Player);
                    player.Goals++;
                }
                else if (x.TypeOfEvent == "yellow-card")
                {
                    //pSet.Where(y => y.Name == x.Player).FirstOrDefault().YellowCards++;
                    Player player = pSet.First(y => y.Name == x.Player);
                    player.YellowCards++;
                }
            });

            return pSet;
        }

        private ISet<Player> GetAwayTeamData(Matches match)
        {
            ISet<Player> pSet = new HashSet<Player>();
            // add players from starting eleven and substitutes
            match.AwayTeamStatistics.StartingEleven.ForEach(x =>
            {
                pSet.Add(x);
                x = playerImageManager.LoadPlayerImage(x);
            });

            // add goal and yellow cards to player
            match.AwayTeamEvents.ForEach(x =>
            {
                if (x.TypeOfEvent == "goal" || x.TypeOfEvent == "goal-penalty")
                {
                    //pSet.Where(y => y.Name == x.Player).FirstOrDefault().Goals++;
                    Player player = pSet.First(y => y.Name == x.Player);
                    player.Goals++;
                }
                else if (x.TypeOfEvent == "yellow-card")
                {
                    //pSet.Where(y => y.Name == x.Player).FirstOrDefault().YellowCards++;
                    Player player = pSet.First(y => y.Name == x.Player);
                    player.YellowCards++;
                }
            });

            return pSet;
        }

        private void btnTeamOvrwFavorite_Click(object sender, RoutedEventArgs e)
        {
            // check if cmbFavoriteTeam is not empty and cmbFavoriteTeam.SelectedItem is not null
            if (cmbFavoriteTeam.Items.Count > 0 && cmbFavoriteTeam.SelectedItem != null)
            {
                string favoriteTeam = cmbFavoriteTeam.SelectedItem.ToString().Substring(0, cmbFavoriteTeam.SelectedItem.ToString().IndexOf("(") - 1);
                int windowWidth = (int)this.ActualWidth;
                int windowHeight = (int)this.ActualHeight;
                string language = AppSettings.Language;

                // find selected team in results
                foreach (var result in results)
                {
                    if (result.Country == favoriteTeam)
                    {
                        // display team overview with selected team and with an animation lasting 0.5 seconds
                        TeamOverviewWindow teamOverview = new TeamOverviewWindow(result, windowWidth, windowHeight, language);
                        teamOverview.Show();
                        DoubleAnimation animation = new DoubleAnimation(0, 1, TimeSpan.FromSeconds(0.5));
                        teamOverview.BeginAnimation(OpacityProperty, animation);
                    }
                }
            }
        }

        private void btnTeamOvrwRival_Click(object sender, RoutedEventArgs e)
        {
            // check if cmbRivalTeam is not empty and cmbRivalTeam.SelectedItem is not null
            if (cmbRivalTeam.Items.Count > 0 && cmbRivalTeam.SelectedItem != null)
            {
                string rivalTeam = cmbRivalTeam.SelectedItem.ToString().Substring(0, cmbRivalTeam.SelectedItem.ToString().IndexOf("(") - 1);
                int windowWidth = (int)this.ActualWidth;
                int windowHeight = (int)this.ActualHeight;
                string language = AppSettings.Language;
                // find selected team in results
                foreach (var result in results)
                {
                    if (result.Country == rivalTeam)
                    {
                        // display team overview with selected team and with an animation lasting 0.5 seconds
                        TeamOverviewWindow teamOverview = new TeamOverviewWindow(result, windowWidth, windowHeight, language);
                        teamOverview.Show();
                        DoubleAnimation animation = new DoubleAnimation(0, 1, TimeSpan.FromSeconds(0.5));
                        teamOverview.BeginAnimation(OpacityProperty, animation);
                    }
                }
            }
        }
    }
}
