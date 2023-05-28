namespace DesktopWinForms
{
    partial class LoadingForm
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
            progressBar = new ProgressBar();
            SuspendLayout();
            // 
            // progressBar
            // 
            progressBar.BackColor = SystemColors.ControlLight;
            progressBar.ForeColor = Color.DarkGoldenrod;
            progressBar.Location = new Point(2, 1);
            progressBar.Margin = new Padding(3, 2, 3, 2);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(650, 21);
            progressBar.Style = ProgressBarStyle.Marquee;
            progressBar.TabIndex = 0;
            // 
            // LoadingForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(654, 23);
            ControlBox = false;
            Controls.Add(progressBar);
            Margin = new Padding(3, 2, 3, 2);
            Name = "LoadingForm";
            StartPosition = FormStartPosition.CenterScreen;
            TopMost = true;
            Load += LoadingForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private ProgressBar progressBar;
    }
}