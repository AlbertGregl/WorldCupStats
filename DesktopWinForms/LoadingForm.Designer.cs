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
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(743, 28);
            progressBar.Style = ProgressBarStyle.Marquee;
            progressBar.TabIndex = 0;
            // 
            // LoadingForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(748, 31);
            ControlBox = false;
            Controls.Add(progressBar);
            Name = "LoadingForm";
            StartPosition = FormStartPosition.CenterScreen;
            ResumeLayout(false);
        }

        #endregion

        private ProgressBar progressBar;
    }
}