using DataRepository.Dal;
using DataRepository.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopWinForms
{
    public partial class SettingsForm : Form
    {
        public MainForm MainForm { get; set; }

        private const string cro = "cro";
        private const string eng = "eng";
        private const string women = "women";
        private const string men = "men";
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
            if (name != "Početne Postavke")
            {
                SetLanguage();
                SetChampionship();
            }
        }

        public void SetLanguage()
        {

            if (MainForm.AppSettings.Language == eng)
            {
                // change current lozalizable language to english
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");

                // change radio button state
                radioButtonEng.Checked = true;
                // change all labels and buttons to english in Settings Form
                lblSettingsHeading.Text = "Settings";
                lblLanguage.Text = "Language";
                lblChampionship.Text = "Championship";
                radioButtonCro.Text = "HRVATSKI";
                radioButtonEng.Text = "English";
                radioButtonWomen.Text = "Womenn";
                radioButtonMen.Text = "Men";
                btnSettingsAccept.Text = "Accept";
                btnSettingsCancel.Text = "Cancel";
            }
            else
            {
                // change current lozalizable language to croatian
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("hr-HR");

                // change radio button state
                radioButtonCro.Checked = true;
                // change all labels and buttons to croatian in Settings Form
                lblSettingsHeading.Text = "Postavke";
                lblLanguage.Text = "Jezik";
                lblChampionship.Text = "Prvenstvo";
                radioButtonCro.Text = "Hrvatski";
                radioButtonEng.Text = "ENGLISH";
                radioButtonWomen.Text = "Žene";
                radioButtonMen.Text = "Muškarci";
                btnSettingsAccept.Text = "Prihvati";
                btnSettingsCancel.Text = "Odustani";
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
