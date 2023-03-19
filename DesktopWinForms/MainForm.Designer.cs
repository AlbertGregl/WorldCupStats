namespace DesktopWinForms
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lblDebug01 = new Label();
            lblFavPlayers = new Label();
            dataGridAllPlayers = new DataGridView();
            nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            shirtNumberDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            positionDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            captainDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            playerBindingSource3 = new BindingSource(components);
            dataGridFavPlayers = new DataGridView();
            nameDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            shirtNumberDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            positionDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            captainDataGridViewCheckBoxColumn1 = new DataGridViewCheckBoxColumn();
            menuStripMain = new MenuStrip();
            menuStripFile = new ToolStripMenuItem();
            menuStripFilePrintStats = new ToolStripMenuItem();
            menuStripSettings = new ToolStripMenuItem();
            menuStripFavTeamComboBox = new ToolStripComboBox();
            cntxMenuStrip = new ContextMenuStrip(components);
            cntxMenuStripFavPlayer = new ToolStripMenuItem();
            pnlflwTeamImages = new FlowLayoutPanel();
            dataGridPlayerRangList = new DataGridView();
            lblRangList = new Label();
            rbSortYellowCards = new RadioButton();
            rbSortGoals = new RadioButton();
            CellImage = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            Goals = new DataGridViewTextBoxColumn();
            YellowCards = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridAllPlayers).BeginInit();
            ((System.ComponentModel.ISupportInitialize)playerBindingSource3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridFavPlayers).BeginInit();
            menuStripMain.SuspendLayout();
            cntxMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridPlayerRangList).BeginInit();
            SuspendLayout();
            // 
            // lblDebug01
            // 
            lblDebug01.AutoSize = true;
            lblDebug01.Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblDebug01.Location = new Point(23, 40);
            lblDebug01.Name = "lblDebug01";
            lblDebug01.Size = new Size(120, 23);
            lblDebug01.TabIndex = 0;
            lblDebug01.Text = "<<select>>";
            // 
            // lblFavPlayers
            // 
            lblFavPlayers.AutoSize = true;
            lblFavPlayers.Font = new Font("Consolas", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            lblFavPlayers.Location = new Point(23, 769);
            lblFavPlayers.Name = "lblFavPlayers";
            lblFavPlayers.Size = new Size(306, 20);
            lblFavPlayers.TabIndex = 7;
            lblFavPlayers.Text = "Omiljeni Igrači, obaberi tri (3):";
            // 
            // dataGridAllPlayers
            // 
            dataGridAllPlayers.AllowDrop = true;
            dataGridAllPlayers.AllowUserToResizeColumns = false;
            dataGridAllPlayers.AllowUserToResizeRows = false;
            dataGridAllPlayers.AutoGenerateColumns = false;
            dataGridAllPlayers.BackgroundColor = Color.LightGoldenrodYellow;
            dataGridAllPlayers.CellBorderStyle = DataGridViewCellBorderStyle.Sunken;
            dataGridAllPlayers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridAllPlayers.Columns.AddRange(new DataGridViewColumn[] { nameDataGridViewTextBoxColumn, shirtNumberDataGridViewTextBoxColumn, positionDataGridViewTextBoxColumn, captainDataGridViewCheckBoxColumn });
            dataGridAllPlayers.DataSource = playerBindingSource3;
            dataGridAllPlayers.GridColor = Color.DarkGoldenrod;
            dataGridAllPlayers.Location = new Point(23, 66);
            dataGridAllPlayers.Name = "dataGridAllPlayers";
            dataGridAllPlayers.ReadOnly = true;
            dataGridAllPlayers.RowHeadersWidth = 51;
            dataGridAllPlayers.RowTemplate.Height = 29;
            dataGridAllPlayers.Size = new Size(556, 700);
            dataGridAllPlayers.TabIndex = 0;
            dataGridAllPlayers.CellMouseClick += dataGridAllPlayers_CellMouseClick;
            dataGridAllPlayers.DragDrop += dataGridAllPlayers_DragDrop;
            dataGridAllPlayers.DragEnter += dataGridPlayers_DragEnter;
            dataGridAllPlayers.MouseDown += dataGridAllPlayers_MouseDown;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            nameDataGridViewTextBoxColumn.HeaderText = "Ime";
            nameDataGridViewTextBoxColumn.MinimumWidth = 6;
            nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            nameDataGridViewTextBoxColumn.ReadOnly = true;
            nameDataGridViewTextBoxColumn.Width = 125;
            // 
            // shirtNumberDataGridViewTextBoxColumn
            // 
            shirtNumberDataGridViewTextBoxColumn.DataPropertyName = "ShirtNumber";
            shirtNumberDataGridViewTextBoxColumn.HeaderText = "Broj";
            shirtNumberDataGridViewTextBoxColumn.MinimumWidth = 6;
            shirtNumberDataGridViewTextBoxColumn.Name = "shirtNumberDataGridViewTextBoxColumn";
            shirtNumberDataGridViewTextBoxColumn.ReadOnly = true;
            shirtNumberDataGridViewTextBoxColumn.Width = 125;
            // 
            // positionDataGridViewTextBoxColumn
            // 
            positionDataGridViewTextBoxColumn.DataPropertyName = "Position";
            positionDataGridViewTextBoxColumn.HeaderText = "Pozicija";
            positionDataGridViewTextBoxColumn.MinimumWidth = 6;
            positionDataGridViewTextBoxColumn.Name = "positionDataGridViewTextBoxColumn";
            positionDataGridViewTextBoxColumn.ReadOnly = true;
            positionDataGridViewTextBoxColumn.Width = 125;
            // 
            // captainDataGridViewCheckBoxColumn
            // 
            captainDataGridViewCheckBoxColumn.DataPropertyName = "Captain";
            captainDataGridViewCheckBoxColumn.HeaderText = "Kapetan";
            captainDataGridViewCheckBoxColumn.MinimumWidth = 6;
            captainDataGridViewCheckBoxColumn.Name = "captainDataGridViewCheckBoxColumn";
            captainDataGridViewCheckBoxColumn.ReadOnly = true;
            captainDataGridViewCheckBoxColumn.Width = 125;
            // 
            // playerBindingSource3
            // 
            playerBindingSource3.DataSource = typeof(DataRepository.Models.Player);
            // 
            // dataGridFavPlayers
            // 
            dataGridFavPlayers.AllowDrop = true;
            dataGridFavPlayers.AllowUserToResizeColumns = false;
            dataGridFavPlayers.AllowUserToResizeRows = false;
            dataGridFavPlayers.AutoGenerateColumns = false;
            dataGridFavPlayers.BackgroundColor = Color.LightGoldenrodYellow;
            dataGridFavPlayers.CellBorderStyle = DataGridViewCellBorderStyle.Sunken;
            dataGridFavPlayers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridFavPlayers.Columns.AddRange(new DataGridViewColumn[] { nameDataGridViewTextBoxColumn1, shirtNumberDataGridViewTextBoxColumn1, positionDataGridViewTextBoxColumn1, captainDataGridViewCheckBoxColumn1 });
            dataGridFavPlayers.DataSource = playerBindingSource3;
            dataGridFavPlayers.GridColor = Color.DarkGoldenrod;
            dataGridFavPlayers.Location = new Point(23, 792);
            dataGridFavPlayers.Name = "dataGridFavPlayers";
            dataGridFavPlayers.ReadOnly = true;
            dataGridFavPlayers.RowHeadersWidth = 51;
            dataGridFavPlayers.RowTemplate.Height = 29;
            dataGridFavPlayers.Size = new Size(556, 164);
            dataGridFavPlayers.TabIndex = 8;
            dataGridFavPlayers.CellMouseClick += dataGridFavPlayers_CellMouseClick;
            dataGridFavPlayers.DragDrop += dataGridFavPlayers_DragDrop;
            dataGridFavPlayers.DragEnter += dataGridPlayers_DragEnter;
            dataGridFavPlayers.MouseDown += dataGridFavPlayers_MouseDown;
            // 
            // nameDataGridViewTextBoxColumn1
            // 
            nameDataGridViewTextBoxColumn1.DataPropertyName = "Name";
            nameDataGridViewTextBoxColumn1.HeaderText = "Ime";
            nameDataGridViewTextBoxColumn1.MinimumWidth = 6;
            nameDataGridViewTextBoxColumn1.Name = "nameDataGridViewTextBoxColumn1";
            nameDataGridViewTextBoxColumn1.ReadOnly = true;
            nameDataGridViewTextBoxColumn1.Width = 125;
            // 
            // shirtNumberDataGridViewTextBoxColumn1
            // 
            shirtNumberDataGridViewTextBoxColumn1.DataPropertyName = "ShirtNumber";
            shirtNumberDataGridViewTextBoxColumn1.HeaderText = "Broj";
            shirtNumberDataGridViewTextBoxColumn1.MinimumWidth = 6;
            shirtNumberDataGridViewTextBoxColumn1.Name = "shirtNumberDataGridViewTextBoxColumn1";
            shirtNumberDataGridViewTextBoxColumn1.ReadOnly = true;
            shirtNumberDataGridViewTextBoxColumn1.Width = 125;
            // 
            // positionDataGridViewTextBoxColumn1
            // 
            positionDataGridViewTextBoxColumn1.DataPropertyName = "Position";
            positionDataGridViewTextBoxColumn1.HeaderText = "Pozicija";
            positionDataGridViewTextBoxColumn1.MinimumWidth = 6;
            positionDataGridViewTextBoxColumn1.Name = "positionDataGridViewTextBoxColumn1";
            positionDataGridViewTextBoxColumn1.ReadOnly = true;
            positionDataGridViewTextBoxColumn1.Width = 125;
            // 
            // captainDataGridViewCheckBoxColumn1
            // 
            captainDataGridViewCheckBoxColumn1.DataPropertyName = "Captain";
            captainDataGridViewCheckBoxColumn1.HeaderText = "Kapetan";
            captainDataGridViewCheckBoxColumn1.MinimumWidth = 6;
            captainDataGridViewCheckBoxColumn1.Name = "captainDataGridViewCheckBoxColumn1";
            captainDataGridViewCheckBoxColumn1.ReadOnly = true;
            captainDataGridViewCheckBoxColumn1.Width = 125;
            // 
            // menuStripMain
            // 
            menuStripMain.BackColor = Color.Goldenrod;
            menuStripMain.ImageScalingSize = new Size(20, 20);
            menuStripMain.Items.AddRange(new ToolStripItem[] { menuStripFile, menuStripSettings, menuStripFavTeamComboBox });
            menuStripMain.Location = new Point(0, 0);
            menuStripMain.Name = "menuStripMain";
            menuStripMain.Padding = new Padding(6, 6, 0, 6);
            menuStripMain.Size = new Size(1918, 40);
            menuStripMain.TabIndex = 9;
            menuStripMain.Text = "menuStrip1";
            // 
            // menuStripFile
            // 
            menuStripFile.DropDownItems.AddRange(new ToolStripItem[] { menuStripFilePrintStats });
            menuStripFile.Font = new Font("Consolas", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            menuStripFile.Name = "menuStripFile";
            menuStripFile.Size = new Size(95, 28);
            menuStripFile.Text = "Datoteka";
            // 
            // menuStripFilePrintStats
            // 
            menuStripFilePrintStats.Name = "menuStripFilePrintStats";
            menuStripFilePrintStats.Size = new Size(236, 26);
            menuStripFilePrintStats.Text = "Ispis rang liste";
            // 
            // menuStripSettings
            // 
            menuStripSettings.CheckOnClick = true;
            menuStripSettings.Font = new Font("Consolas", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            menuStripSettings.Name = "menuStripSettings";
            menuStripSettings.Size = new Size(95, 28);
            menuStripSettings.Text = "Postavke";
            menuStripSettings.Click += menuStripSettings_Click;
            // 
            // menuStripFavTeamComboBox
            // 
            menuStripFavTeamComboBox.Font = new Font("Consolas", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            menuStripFavTeamComboBox.Name = "menuStripFavTeamComboBox";
            menuStripFavTeamComboBox.Size = new Size(350, 28);
            menuStripFavTeamComboBox.Text = "Omiljena reprezentacija <odaberi>";
            menuStripFavTeamComboBox.SelectedIndexChanged += cmbFavRep_SelectedIndexChanged;
            // 
            // cntxMenuStrip
            // 
            cntxMenuStrip.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point);
            cntxMenuStrip.ImageScalingSize = new Size(20, 20);
            cntxMenuStrip.Items.AddRange(new ToolStripItem[] { cntxMenuStripFavPlayer });
            cntxMenuStrip.Name = "cntxMenuStrip";
            cntxMenuStrip.Size = new Size(189, 26);
            // 
            // cntxMenuStripFavPlayer
            // 
            cntxMenuStripFavPlayer.Name = "cntxMenuStripFavPlayer";
            cntxMenuStripFavPlayer.Size = new Size(188, 22);
            cntxMenuStripFavPlayer.Text = "Odaberi Igrača";
            // 
            // pnlflwTeamImages
            // 
            pnlflwTeamImages.Location = new Point(1324, 66);
            pnlflwTeamImages.Name = "pnlflwTeamImages";
            pnlflwTeamImages.Size = new Size(363, 890);
            pnlflwTeamImages.TabIndex = 10;
            // 
            // dataGridPlayerRangList
            // 
            dataGridPlayerRangList.AllowDrop = true;
            dataGridPlayerRangList.AllowUserToAddRows = false;
            dataGridPlayerRangList.AllowUserToDeleteRows = false;
            dataGridPlayerRangList.AllowUserToResizeColumns = false;
            dataGridPlayerRangList.AllowUserToResizeRows = false;
            dataGridPlayerRangList.AutoGenerateColumns = false;
            dataGridPlayerRangList.BackgroundColor = Color.LightGoldenrodYellow;
            dataGridPlayerRangList.CellBorderStyle = DataGridViewCellBorderStyle.Sunken;
            dataGridPlayerRangList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridPlayerRangList.Columns.AddRange(new DataGridViewColumn[] { CellImage, dataGridViewTextBoxColumn1, Goals, YellowCards });
            dataGridPlayerRangList.DataSource = playerBindingSource3;
            dataGridPlayerRangList.GridColor = Color.DarkGoldenrod;
            dataGridPlayerRangList.Location = new Point(598, 66);
            dataGridPlayerRangList.Name = "dataGridPlayerRangList";
            dataGridPlayerRangList.ReadOnly = true;
            dataGridPlayerRangList.RowHeadersWidth = 51;
            dataGridPlayerRangList.RowTemplate.Height = 64;
            dataGridPlayerRangList.Size = new Size(463, 890);
            dataGridPlayerRangList.TabIndex = 11;
            // 
            // lblRangList
            // 
            lblRangList.AutoSize = true;
            lblRangList.Font = new Font("Consolas", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            lblRangList.Location = new Point(605, 43);
            lblRangList.Name = "lblRangList";
            lblRangList.Size = new Size(99, 20);
            lblRangList.TabIndex = 12;
            lblRangList.Text = "Rang lista";
            // 
            // rbSortYellowCards
            // 
            rbSortYellowCards.AutoSize = true;
            rbSortYellowCards.Location = new Point(922, 43);
            rbSortYellowCards.Name = "rbSortYellowCards";
            rbSortYellowCards.Size = new Size(125, 22);
            rbSortYellowCards.TabIndex = 13;
            rbSortYellowCards.TabStop = true;
            rbSortYellowCards.Text = "Žuti kartoni";
            rbSortYellowCards.UseVisualStyleBackColor = true;
            // 
            // rbSortGoals
            // 
            rbSortGoals.AutoSize = true;
            rbSortGoals.Location = new Point(839, 43);
            rbSortGoals.Name = "rbSortGoals";
            rbSortGoals.Size = new Size(77, 22);
            rbSortGoals.TabIndex = 14;
            rbSortGoals.TabStop = true;
            rbSortGoals.Text = "Golovi";
            rbSortGoals.UseVisualStyleBackColor = true;
            // 
            // CellImage
            // 
            CellImage.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            CellImage.DataPropertyName = "Image";
            CellImage.HeaderText = "Slika";
            CellImage.MinimumWidth = 6;
            CellImage.Name = "CellImage";
            CellImage.ReadOnly = true;
            CellImage.Resizable = DataGridViewTriState.True;
            CellImage.SortMode = DataGridViewColumnSortMode.Automatic;
            CellImage.Width = 64;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.DataPropertyName = "Name";
            dataGridViewTextBoxColumn1.HeaderText = "Ime";
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            dataGridViewTextBoxColumn1.Width = 125;
            // 
            // Goals
            // 
            Goals.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            Goals.DataPropertyName = "Goals";
            Goals.HeaderText = "Golovi";
            Goals.MinimumWidth = 6;
            Goals.Name = "Goals";
            Goals.ReadOnly = true;
            Goals.Width = 85;
            // 
            // YellowCards
            // 
            YellowCards.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            YellowCards.DataPropertyName = "YellowCards";
            YellowCards.HeaderText = "Žuti kartoni";
            YellowCards.MinimumWidth = 6;
            YellowCards.Name = "YellowCards";
            YellowCards.ReadOnly = true;
            YellowCards.Width = 133;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1918, 977);
            Controls.Add(rbSortGoals);
            Controls.Add(rbSortYellowCards);
            Controls.Add(lblRangList);
            Controls.Add(dataGridPlayerRangList);
            Controls.Add(pnlflwTeamImages);
            Controls.Add(dataGridFavPlayers);
            Controls.Add(lblDebug01);
            Controls.Add(dataGridAllPlayers);
            Controls.Add(lblFavPlayers);
            Controls.Add(menuStripMain);
            Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point);
            MainMenuStrip = menuStripMain;
            Name = "MainForm";
            Text = "World Cup Stats";
            WindowState = FormWindowState.Maximized;
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridAllPlayers).EndInit();
            ((System.ComponentModel.ISupportInitialize)playerBindingSource3).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridFavPlayers).EndInit();
            menuStripMain.ResumeLayout(false);
            menuStripMain.PerformLayout();
            cntxMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridPlayerRangList).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblDebug01;
        private Label lblFavPlayers;
        private DataGridView dataGridAllPlayers;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn isFavoriteDataGridViewCheckBoxColumn;
        private DataGridView dataGridFavPlayers;
        private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
        private MenuStrip menuStripMain;
        private ToolStripMenuItem menuStripFile;
        private ToolStripMenuItem menuStripFilePrintStats;
        private ToolStripMenuItem menuStripSettings;
        private ToolStripComboBox menuStripFavTeamComboBox;
        private ContextMenuStrip cntxMenuStrip;
        private ToolStripMenuItem cntxMenuStripFavPlayer;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn shirtNumberDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn positionDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn captainDataGridViewCheckBoxColumn;
        private BindingSource playerBindingSource3;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn shirtNumberDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn positionDataGridViewTextBoxColumn1;
        private DataGridViewCheckBoxColumn captainDataGridViewCheckBoxColumn1;
        private FlowLayoutPanel pnlflwTeamImages;
        private DataGridView dataGridPlayerRangList;
        private Label lblRangList;
        private RadioButton rbSortYellowCards;
        private RadioButton rbSortGoals;
        private DataGridViewImageColumn CellImage;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn Goals;
        private DataGridViewTextBoxColumn YellowCards;
    }
}