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
    public partial class CloseForm : Form
    {
        public CloseForm()
        {
            // form created with default language
            InitializeComponent();
        }

        public CloseForm(string language)
        {
            InitializeComponent();

            //set up buttons and labes based on language
            if (language == "eng")
            {
                this.Text = "Exit";
                btnYes.Text = "Yes";
                btnNo.Text = "No";
                lblClose.Text = "Do you want to exit?";
            }
            else
            {
                this.Text = "Izlaz";
                btnYes.Text = "Da";
                btnNo.Text = "Ne";
                lblClose.Text = "Zatvori Aplikaciju?";
            }
        }

        private void CloseForm_Load(object sender, EventArgs e)
        {

        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            // return dialog results as yes
            this.DialogResult = DialogResult.Yes;
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            // close the form
            this.Close();
        }
    }
}
