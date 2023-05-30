using System;
using System.Reflection;
using System.Threading;
using System.Windows;
using System.Resources;

namespace DesktopWPF
{
    /// <summary>
    /// Interaction logic for CloseWondow.xaml
    /// </summary>
    public partial class CloseWindow : Window
    {
        public bool CloseApp { get; internal set; }

        public CloseWindow()
        {
            InitializeComponent();

            SetLanguage();
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
                TranslateCloseWindow(resourceManager);
            }
            catch (Exception ex)
            {
                //dataManager.ErrorLog(ex.Message + ", " + ex.StackTrace);
            }
        }

        private void TranslateCloseWindow(ResourceManager resourceManager)
        {
            this.Title = resourceManager.GetString("FormClosingName");
            msgTextBlock.Text = resourceManager.GetString("FormClosingText");
            btnYesCloseWindow.Content = resourceManager.GetString("btnYesCloseWindow");
            btnNoCloseWindow.Content = resourceManager.GetString("btnNoCloseWindow");
        }

        private void btnYesCloseWindow_Click(object sender, RoutedEventArgs e)
        {
            CloseApplication();
        }

        private void CloseApplication()
        {
            // set bool to true
            CloseApp = true;
            // close window
            this.Close();
        }

        private void btnNoCloseWindow_Click(object sender, RoutedEventArgs e)
        {
            Cancel();
        }

        private void Cancel()
        {
            // set bool to false
            CloseApp = false;
            // close window
            this.Close();
        }

        private void closeWindow_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            // if user press enter
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                CloseApplication();
            }
            // if user press escape
            else if (e.Key == System.Windows.Input.Key.Escape)
            {
                Cancel();
            }
        }
    }
}
