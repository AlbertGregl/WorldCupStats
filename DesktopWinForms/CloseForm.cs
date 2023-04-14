using System.Reflection;
using System.Resources;

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
            SetLanguage(language);
        }

        private void SetLanguage(string language)
        {
            ResourceManager resourceManager = new ResourceManager("DesktopWinForms.Resources.croatian", Assembly.GetExecutingAssembly());
            // change current lozalizable language to english
            if (language == "eng")
            {
                resourceManager = new ResourceManager("DesktopWinForms.Resources.english", Assembly.GetExecutingAssembly());
            }
            // change current lozalizable language to croatian
            else if (language == "cro")
            {
                resourceManager = new ResourceManager("DesktopWinForms.Resources.croatian", Assembly.GetExecutingAssembly());
            }
            this.Text = resourceManager.GetString("Close_Form");
            btnYes.Text = resourceManager.GetString("Close_btnYes");
            btnNo.Text = resourceManager.GetString("Close_btnNo");
            lblClose.Text = resourceManager.GetString("Close_lblClose");
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
