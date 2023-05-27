using DataRepository.Dal;
using DataRepository.Models;
using System;
using System.Reflection;
using System.Threading;
using System.Windows;
using System.Resources;
using System.Net.Security;

namespace DesktopWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string cro = "cro";
        private const string eng = "eng";
        private const string women = "women";
        private const string men = "men";
        private string MSGBoxExitText = "";
        private string MSGBoxExitTitle = "";
        private string MSGBoxRestartText = "";
        private string MSGBoxRestartTitle = "";

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
            // change current lozalizable language
            SetLanguage();
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
            lblScreenResolution.Content = resourceManager.GetString("lblScreenResolution");
            rbSmallScreen.Content = resourceManager.GetString("rbSmallScreen");
            rbMediumScreen.Content = resourceManager.GetString("rbMediumScreen");
            rbFullScreen.Content = resourceManager.GetString("rbFullScreen");
            btnSaveSettings.Content = resourceManager.GetString("btnSaveSettings");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

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
                // save settings
                
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

    }
}
