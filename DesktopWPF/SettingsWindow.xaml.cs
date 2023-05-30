using System;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows;
using System.Resources;
using DataRepository.Models;
using DataRepository.Dal;

namespace DesktopWPF
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public SettingsLocal AppSettings { get; set; }
        private readonly ISettingsRepository settingsRepo;

        public bool RestartAppRequired { get; internal set; }

        public SettingsWindow()
        {
            InitializeComponent();

            // set default settings
            AppSettings = new SettingsLocal();

            // initialize settings
            settingsRepo = RepositoryFactory.GetSettingsRepo();

            CheckIfSettingsFileExists();

            SetupAppSettingsRadioButtons();

            SetLanguage();
        }

        private void CheckIfSettingsFileExists()
        {
            if (settingsRepo.SettingsFileCreated())
            {
                // load settings
                AppSettings = settingsRepo.LoadSettings();
                LocalWPFSettings();
            }
            else
            {
                // set default values
                AppSettings.Language = "cro";
                AppSettings.Championship = "men";
                LocalWPFSettings();
            }
        }

        private void LocalWPFSettings()
        {
            Properties.SettingsWPF.Default.AppLanguage = AppSettings.Language;
            Properties.SettingsWPF.Default.AppChampionship = AppSettings.Championship;
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
                TranslateSettingsWindow(resourceManager);
            }
            catch (Exception ex)
            {
                //dataManager.ErrorLog(ex.Message + ", " + ex.StackTrace);
            }
        }

        private void TranslateSettingsWindow(ResourceManager resourceManager)
        {
            this.Title = resourceManager.GetString("TabSettings");
            lbLanguage.Content = resourceManager.GetString("lbLanguage");
            rbCroatian.Content = resourceManager.GetString("rbCroatian");
            rbEnglish.Content = resourceManager.GetString("rbEnglish");
            lbWorldCup.Content = resourceManager.GetString("lbWorldCup");
            rbMen.Content = resourceManager.GetString("rbMen");
            rbWomen.Content = resourceManager.GetString("rbWomen");
            //MSGBoxRestartTitle = resourceManager.GetString("FormRestartName");
            //MSGBoxRestartText = resourceManager.GetString("FormRestartText");
            lblScreenResolution.Content = resourceManager.GetString("lblScreenResolution");
            rbSmallScreen.Content = resourceManager.GetString("rbSmallScreen");
            rbMediumScreen.Content = resourceManager.GetString("rbMediumScreen");
            rbFullScreen.Content = resourceManager.GetString("rbFullScreen");
            btnSaveSettings.Content = resourceManager.GetString("btnSaveSettings");
            btnCancelSettings.Content = resourceManager.GetString("");
        }

        private void btnSaveSettings_Click(object sender, RoutedEventArgs e)
        {
            SaveAppSettings();
            // close the window
            this.Close();
        }

        private void SaveSettingsUtil()
        {
            Properties.SettingsWPF.Default.Save();
            settingsRepo.SaveSettings(AppSettings);
            // change current lozalizable language
            SetLanguage();
        }

        // check radio buttons based on settings
        private void SetupAppSettingsRadioButtons()
        {
            if (AppSettings.Language == "cro")
            {
                rbCroatian.IsChecked = true;
            }
            else
            {
                rbEnglish.IsChecked = true;
            }
            if (AppSettings.Championship == "men")
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
                AppSettings.Language = "cro";
                Properties.SettingsWPF.Default.AppLanguage = "cro";
            }
            else
            {
                AppSettings.Language = "eng";
                Properties.SettingsWPF.Default.AppLanguage = "eng";
            }
            if (rbMen.IsChecked == true)
            {
                AppSettings.Championship = "men";
            }
            else
            {
                AppSettings.Championship = "women";
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
                // save settings
                RestartAppRequired = true;
            }

            // save settings
            SaveSettingsUtil();
        }

        private void settingsWindow_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            // if user press enter
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                SaveAppSettings();
                // close the window
                this.Close();
            }
            // if user press escape
            else if (e.Key == System.Windows.Input.Key.Escape)
            {
                RestartAppRequired = false;
                this.Close();
            }
        }

        private void btnCancelSettings_Click(object sender, RoutedEventArgs e)
        {
            RestartAppRequired = false;
            this.Close();
        }
    }
}
