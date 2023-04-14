using System.Reflection;
using System.Resources;

namespace DesktopWinForms
{
    public partial class SettingsForm : Form
    {
        public MainForm MainForm { get; set; }

        private const string cro = "cro";
        private const string eng = "eng";
        private const string women = "women";
        private const string men = "men";
        private const string startupSettings = "Početne Postavk";
        private string name = "";

        public SettingsForm()
        {
            MainForm = new MainForm();
            InitializeComponent();
        }

        public SettingsForm(string name)
        {
            MainForm = new MainForm();
            InitializeComponent();
            this.name = name;
            // change form background color
            Color whiteBackground = Color.FromArgb(247, 247, 247);
            this.BackColor = whiteBackground;
            groupBoxLang.BackColor = whiteBackground;
            groupBoxChamp.BackColor = whiteBackground;
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            if (name != startupSettings)
            {
                SetLanguage();
                SetChampionship();
            }
        }

        public void SetLanguage()
        {
            try
            {
                ResourceManager resourceManager = new ResourceManager("DesktopWinForms.Resources.croatian", Assembly.GetExecutingAssembly());
                // change current lozalizable language to english
                if (MainForm.AppSettings.Language == eng)
                {
                    radioButtonEng.Checked = true;
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
                    resourceManager = new ResourceManager("DesktopWinForms.Resources.english", Assembly.GetExecutingAssembly());
                }
                // change current lozalizable language to croatian
                else if (MainForm.AppSettings.Language == cro)
                {
                    radioButtonCro.Checked = true;
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("hr-HR");
                    resourceManager = new ResourceManager("DesktopWinForms.Resources.croatian", Assembly.GetExecutingAssembly());
                }
                // change all labels and buttons to english in Settings Form
                lblSettingsHeading.Text = resourceManager.GetString("Set_lblSettingsHeading");
                lblLanguage.Text = resourceManager.GetString("Set_lblLanguage");
                lblChampionship.Text = resourceManager.GetString("Set_lblChampionship");
                radioButtonCro.Text = resourceManager.GetString("Set_radioButtonCro");
                radioButtonEng.Text = resourceManager.GetString("Set_radioButtonEng");
                radioButtonWomen.Text = resourceManager.GetString("Set_radioButtonWomen");
                radioButtonMen.Text = resourceManager.GetString("Set_radioButtonMen");
                btnSettingsAccept.Text = resourceManager.GetString("Set_btnSettingsAccept");
                btnSettingsCancel.Text = resourceManager.GetString("Set_btnSettingsCancel");
            }
            catch (Exception)
            {
                // something went wrong
            }

        }

        public void SetChampionship()
        {
            if (MainForm.AppSettings.Championship == men)
            {
                // change radio button state
                radioButtonMen.Checked = true;
            }
            else
            {
                // change radio button state
                radioButtonWomen.Checked = true;
            }
        }

        private void btnSettingsCancel_Click(object sender, EventArgs e)
        {
            // close only if MainForm.AppSettings data is not null
            if (MainForm.AppSettings.Language != null && MainForm.AppSettings.Championship != null)
            {
                this.Close();
            }
            else
            {
                // prompt user if user would like to exit the app
                DialogResult dialogResult = new CloseForm().ShowDialog();
                if (dialogResult == DialogResult.Cancel)
                {
                    // if cancel, set default settings for the user
                    MessageBox.Show("Jezik: Hrvatski\nPrvenstvo: Žene", "Zadane postavke");
                    MainForm.AppSettings.Language = cro;
                    MainForm.AppSettings.Championship = women;
                    MainForm.SaveSettings();
                    // subscribe main form back to on close event for initial settings
                    if (name != string.Empty)
                    {
                        MainForm.SubscribeEventMainForm_FormClosing();
                    }
                }
                else
                {
                    Application.Exit();
                }
            }
        }

        private void btnSettingsAccept_Click(object sender, EventArgs e)
        {
            MainForm.AppSettings.Language = radioButtonEng.Checked ? eng : cro;
            MainForm.AppSettings.Championship = radioButtonWomen.Checked ? women : men;
            SetLanguage();
            SetChampionship();

            // save settings to file
            MainForm.SaveSettings();

            //raise an event
            OnSettingsAccepted(EventArgs.Empty);

            // close form
            this.Close();
        }

        //raise an event when the from button accept is pressed
        public event EventHandler? SettingsAccepted;
        protected virtual void OnSettingsAccepted(EventArgs e)
        {
            EventHandler? handler = SettingsAccepted;
            if (handler != null)
            {
                handler(this, e);
            }
        }


    }
}
