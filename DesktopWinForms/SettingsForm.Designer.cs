namespace DesktopWinForms
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            lblLanguage = new Label();
            radioButtonEng = new RadioButton();
            radioButtonCro = new RadioButton();
            radioButtonWomen = new RadioButton();
            radioButtonMen = new RadioButton();
            lblChampionship = new Label();
            lblSettingsHeading = new Label();
            btnSettingsAccept = new Button();
            groupBoxLang = new GroupBox();
            groupBoxChamp = new GroupBox();
            btnSettingsCancel = new Button();
            groupBoxLang.SuspendLayout();
            groupBoxChamp.SuspendLayout();
            SuspendLayout();
            // 
            // lblLanguage
            // 
            resources.ApplyResources(lblLanguage, "lblLanguage");
            lblLanguage.Name = "lblLanguage";
            // 
            // radioButtonEng
            // 
            resources.ApplyResources(radioButtonEng, "radioButtonEng");
            radioButtonEng.Name = "radioButtonEng";
            radioButtonEng.UseVisualStyleBackColor = true;
            // 
            // radioButtonCro
            // 
            resources.ApplyResources(radioButtonCro, "radioButtonCro");
            radioButtonCro.Checked = true;
            radioButtonCro.Name = "radioButtonCro";
            radioButtonCro.TabStop = true;
            radioButtonCro.UseVisualStyleBackColor = true;
            // 
            // radioButtonWomen
            // 
            resources.ApplyResources(radioButtonWomen, "radioButtonWomen");
            radioButtonWomen.Checked = true;
            radioButtonWomen.Name = "radioButtonWomen";
            radioButtonWomen.TabStop = true;
            radioButtonWomen.UseVisualStyleBackColor = true;
            // 
            // radioButtonMen
            // 
            resources.ApplyResources(radioButtonMen, "radioButtonMen");
            radioButtonMen.Name = "radioButtonMen";
            radioButtonMen.UseVisualStyleBackColor = true;
            // 
            // lblChampionship
            // 
            resources.ApplyResources(lblChampionship, "lblChampionship");
            lblChampionship.Name = "lblChampionship";
            // 
            // lblSettingsHeading
            // 
            resources.ApplyResources(lblSettingsHeading, "lblSettingsHeading");
            lblSettingsHeading.Name = "lblSettingsHeading";
            // 
            // btnSettingsAccept
            // 
            btnSettingsAccept.BackColor = SystemColors.Info;
            btnSettingsAccept.Cursor = Cursors.Hand;
            resources.ApplyResources(btnSettingsAccept, "btnSettingsAccept");
            btnSettingsAccept.Name = "btnSettingsAccept";
            btnSettingsAccept.UseVisualStyleBackColor = false;
            btnSettingsAccept.Click += btnSettingsAccept_Click;
            // 
            // groupBoxLang
            // 
            groupBoxLang.BackColor = Color.Goldenrod;
            groupBoxLang.Controls.Add(lblLanguage);
            groupBoxLang.Controls.Add(radioButtonEng);
            groupBoxLang.Controls.Add(radioButtonCro);
            groupBoxLang.Cursor = Cursors.Hand;
            groupBoxLang.FlatStyle = FlatStyle.Flat;
            resources.ApplyResources(groupBoxLang, "groupBoxLang");
            groupBoxLang.Name = "groupBoxLang";
            groupBoxLang.TabStop = false;
            // 
            // groupBoxChamp
            // 
            groupBoxChamp.BackColor = Color.Goldenrod;
            groupBoxChamp.Controls.Add(lblChampionship);
            groupBoxChamp.Controls.Add(radioButtonMen);
            groupBoxChamp.Controls.Add(radioButtonWomen);
            groupBoxChamp.Cursor = Cursors.Hand;
            groupBoxChamp.FlatStyle = FlatStyle.Flat;
            resources.ApplyResources(groupBoxChamp, "groupBoxChamp");
            groupBoxChamp.Name = "groupBoxChamp";
            groupBoxChamp.TabStop = false;
            // 
            // btnSettingsCancel
            // 
            btnSettingsCancel.BackColor = Color.FromArgb(255, 192, 192);
            btnSettingsCancel.Cursor = Cursors.Hand;
            resources.ApplyResources(btnSettingsCancel, "btnSettingsCancel");
            btnSettingsCancel.Name = "btnSettingsCancel";
            btnSettingsCancel.UseVisualStyleBackColor = false;
            btnSettingsCancel.Click += btnSettingsCancel_Click;
            // 
            // SettingsForm
            // 
            AcceptButton = btnSettingsAccept;
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Goldenrod;
            CancelButton = btnSettingsCancel;
            ControlBox = false;
            Controls.Add(btnSettingsCancel);
            Controls.Add(groupBoxChamp);
            Controls.Add(groupBoxLang);
            Controls.Add(btnSettingsAccept);
            Controls.Add(lblSettingsHeading);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "SettingsForm";
            TopMost = true;
            Load += SettingsForm_Load;
            groupBoxLang.ResumeLayout(false);
            groupBoxLang.PerformLayout();
            groupBoxChamp.ResumeLayout(false);
            groupBoxChamp.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblLanguage;
        private RadioButton radioButtonEng;
        private RadioButton radioButtonCro;
        private RadioButton radioButtonWomen;
        private RadioButton radioButtonMen;
        private Label lblChampionship;
        private Label lblSettingsHeading;
        private Button btnSettingsAccept;
        private GroupBox groupBoxLang;
        private GroupBox groupBoxChamp;
        private Button btnSettingsCancel;
    }
}