namespace DesktopWinForms
{
    partial class CloseForm
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
            lblClose = new Label();
            btnNo = new Button();
            btnYes = new Button();
            SuspendLayout();
            // 
            // lblClose
            // 
            lblClose.AutoSize = true;
            lblClose.Font = new Font("Consolas", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            lblClose.Location = new Point(53, 37);
            lblClose.Name = "lblClose";
            lblClose.Size = new Size(180, 20);
            lblClose.TabIndex = 0;
            lblClose.Text = "Zatvori Aplikaciju?";
            // 
            // btnNo
            // 
            btnNo.BackColor = Color.FromArgb(255, 192, 192);
            btnNo.Cursor = Cursors.Hand;
            btnNo.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnNo.ImeMode = ImeMode.NoControl;
            btnNo.Location = new Point(151, 85);
            btnNo.Name = "btnNo";
            btnNo.Size = new Size(73, 29);
            btnNo.TabIndex = 12;
            btnNo.Text = "Ne";
            btnNo.UseVisualStyleBackColor = false;
            btnNo.Click += btnNo_Click;
            // 
            // btnYes
            // 
            btnYes.BackColor = SystemColors.Info;
            btnYes.Cursor = Cursors.Hand;
            btnYes.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnYes.ImeMode = ImeMode.NoControl;
            btnYes.Location = new Point(53, 85);
            btnYes.Name = "btnYes";
            btnYes.Size = new Size(73, 29);
            btnYes.TabIndex = 11;
            btnYes.Text = "Da";
            btnYes.UseVisualStyleBackColor = false;
            btnYes.Click += btnYes_Click;
            // 
            // CloseForm
            // 
            AcceptButton = btnYes;
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gold;
            CancelButton = btnNo;
            ClientSize = new Size(278, 151);
            ControlBox = false;
            Controls.Add(btnNo);
            Controls.Add(btnYes);
            Controls.Add(lblClose);
            Font = new Font("Consolas", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "CloseForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Izlaz";
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblClose;
        private Button btnNo;
        private Button btnYes;
    }
}