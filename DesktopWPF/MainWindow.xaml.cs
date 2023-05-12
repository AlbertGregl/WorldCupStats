using DataRepository.Dal;
using DataRepository.Models;
using System;
using System.Reflection;
using System.Threading;
using System.Windows;
using System.Resources;

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
        private string MSGBoxText = "";
        private string MSGBoxTitle = "";

        private readonly ISettingsRepository settingsRepo;
        public SettingsLocal AppSettings { get; set; }
        private SettingsFavorite settingsFavorite;

        public MainWindow()
        {
            InitializeComponent();

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
            MSGBoxTitle = resourceManager.GetString("FormClosingName");
            MSGBoxText = resourceManager.GetString("FormClosingText");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
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
                if(AppSettings.Language == cro)
                {
                    rbCroatian.IsChecked = true;                    
                }
                else
                {
                    rbEnglish.IsChecked = true;
                }
                if(AppSettings.Championship == men) 
                {
                    rbMen.IsChecked = true;
                }
                else
                {
                    rbWomen.IsChecked = true;
                }
                // display and open world cup tab
                TabWorldCup.Visibility = Visibility.Visible;
                TabWorldCup.IsSelected = true;
            }
        }

        private void SaveAppSettings()
        {
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
            // save settings
            settingsRepo.SaveSettings(AppSettings);
            // change current lozalizable language
            SetLanguage();
        }

        private void TabControl_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            SaveAppSettings();
        }

        private void MainWindowForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // prompt use if he realy wants to close the app
            MessageBoxResult result = MessageBox.Show(MSGBoxText, MSGBoxTitle, MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                // save settings
                SaveAppSettings();
            }
            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
