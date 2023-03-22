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
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle16 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle13 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle14 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle15 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle21 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle17 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle18 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle19 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle20 = new DataGridViewCellStyle();
            lblDebug01 = new Label();
            lblFavPlayers = new Label();
            dataGridAllPlayers = new DataGridView();
            DataGridAllPlayersImage = new DataGridViewImageColumn();
            nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            shirtNumberDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            positionDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            captainDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            playerBindingSource3 = new BindingSource(components);
            dataGridFavPlayers = new DataGridView();
            dataGridFavPlayersImage = new DataGridViewImageColumn();
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
            dataGridPlayerRangList = new DataGridView();
            dataGridPlayerRangListImage = new DataGridViewImageColumn();
            GamesPlayed = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            Goals = new DataGridViewTextBoxColumn();
            YellowCards = new DataGridViewTextBoxColumn();
            lblRangList = new Label();
            rbSortYellowCards = new RadioButton();
            rbSortGoals = new RadioButton();
            grpRangListButtons = new GroupBox();
            rbSortGamesPlayed = new RadioButton();
            dataGridFavTeamMatches = new DataGridView();
            locationDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            attendanceDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            homeTeamCountryDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            awayTeamCountryDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            matchesBindingSource = new BindingSource(components);
            lblFavTeamMatches = new Label();
            lblConnection = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridAllPlayers).BeginInit();
            ((System.ComponentModel.ISupportInitialize)playerBindingSource3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridFavPlayers).BeginInit();
            menuStripMain.SuspendLayout();
            cntxMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridPlayerRangList).BeginInit();
            grpRangListButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridFavTeamMatches).BeginInit();
            ((System.ComponentModel.ISupportInitialize)matchesBindingSource).BeginInit();
            SuspendLayout();
            // 
            // lblDebug01
            // 
            lblDebug01.AutoSize = true;
            lblDebug01.Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblDebug01.Location = new Point(23, 40);
            lblDebug01.Name = "lblDebug01";
            lblDebug01.Size = new Size(99, 19);
            lblDebug01.TabIndex = 0;
            lblDebug01.Text = "<<select>>";
            // 
            // lblFavPlayers
            // 
            lblFavPlayers.AutoSize = true;
            lblFavPlayers.Font = new Font("Consolas", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            lblFavPlayers.Location = new Point(597, 51);
            lblFavPlayers.Name = "lblFavPlayers";
            lblFavPlayers.Size = new Size(272, 17);
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
            dataGridAllPlayers.Columns.AddRange(new DataGridViewColumn[] { DataGridAllPlayersImage, nameDataGridViewTextBoxColumn, shirtNumberDataGridViewTextBoxColumn, positionDataGridViewTextBoxColumn, captainDataGridViewCheckBoxColumn });
            dataGridAllPlayers.DataSource = playerBindingSource3;
            dataGridAllPlayers.GridColor = Color.DarkGoldenrod;
            dataGridAllPlayers.Location = new Point(23, 66);
            dataGridAllPlayers.Name = "dataGridAllPlayers";
            dataGridAllPlayers.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.LightGoldenrodYellow;
            dataGridViewCellStyle5.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = Color.Goldenrod;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dataGridAllPlayers.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dataGridAllPlayers.RowHeadersWidth = 51;
            dataGridAllPlayers.RowTemplate.Height = 64;
            dataGridAllPlayers.Size = new Size(538, 875);
            dataGridAllPlayers.TabIndex = 0;
            dataGridAllPlayers.CellMouseClick += dataGridAllPlayers_CellMouseClick;
            dataGridAllPlayers.DragDrop += dataGridAllPlayers_DragDrop;
            dataGridAllPlayers.DragEnter += dataGridPlayers_DragEnter;
            dataGridAllPlayers.MouseDown += dataGridAllPlayers_MouseDown;
            // 
            // DataGridAllPlayersImage
            // 
            DataGridAllPlayersImage.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            DataGridAllPlayersImage.DataPropertyName = "Image";
            DataGridAllPlayersImage.HeaderText = "Image";
            DataGridAllPlayersImage.Name = "DataGridAllPlayersImage";
            DataGridAllPlayersImage.ReadOnly = true;
            DataGridAllPlayersImage.ToolTipText = "Kliknite za promjenu slike.";
            DataGridAllPlayersImage.Width = 64;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            dataGridViewCellStyle1.BackColor = Color.LightGoldenrodYellow;
            dataGridViewCellStyle1.SelectionBackColor = Color.Goldenrod;
            nameDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            nameDataGridViewTextBoxColumn.HeaderText = "Ime";
            nameDataGridViewTextBoxColumn.MinimumWidth = 6;
            nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            nameDataGridViewTextBoxColumn.ReadOnly = true;
            nameDataGridViewTextBoxColumn.Width = 125;
            // 
            // shirtNumberDataGridViewTextBoxColumn
            // 
            shirtNumberDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            shirtNumberDataGridViewTextBoxColumn.DataPropertyName = "ShirtNumber";
            dataGridViewCellStyle2.BackColor = Color.LightGoldenrodYellow;
            dataGridViewCellStyle2.SelectionBackColor = Color.Goldenrod;
            shirtNumberDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            shirtNumberDataGridViewTextBoxColumn.HeaderText = "Broj";
            shirtNumberDataGridViewTextBoxColumn.MinimumWidth = 6;
            shirtNumberDataGridViewTextBoxColumn.Name = "shirtNumberDataGridViewTextBoxColumn";
            shirtNumberDataGridViewTextBoxColumn.ReadOnly = true;
            shirtNumberDataGridViewTextBoxColumn.Width = 60;
            // 
            // positionDataGridViewTextBoxColumn
            // 
            positionDataGridViewTextBoxColumn.DataPropertyName = "Position";
            dataGridViewCellStyle3.BackColor = Color.LightGoldenrodYellow;
            dataGridViewCellStyle3.SelectionBackColor = Color.Goldenrod;
            positionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            positionDataGridViewTextBoxColumn.HeaderText = "Pozicija";
            positionDataGridViewTextBoxColumn.MinimumWidth = 6;
            positionDataGridViewTextBoxColumn.Name = "positionDataGridViewTextBoxColumn";
            positionDataGridViewTextBoxColumn.ReadOnly = true;
            positionDataGridViewTextBoxColumn.Width = 125;
            // 
            // captainDataGridViewCheckBoxColumn
            // 
            captainDataGridViewCheckBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            captainDataGridViewCheckBoxColumn.DataPropertyName = "Captain";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = Color.LightGoldenrodYellow;
            dataGridViewCellStyle4.NullValue = false;
            dataGridViewCellStyle4.SelectionBackColor = Color.Goldenrod;
            captainDataGridViewCheckBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            captainDataGridViewCheckBoxColumn.HeaderText = "Kapetan";
            captainDataGridViewCheckBoxColumn.MinimumWidth = 6;
            captainDataGridViewCheckBoxColumn.Name = "captainDataGridViewCheckBoxColumn";
            captainDataGridViewCheckBoxColumn.ReadOnly = true;
            captainDataGridViewCheckBoxColumn.Width = 62;
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
            dataGridFavPlayers.Columns.AddRange(new DataGridViewColumn[] { dataGridFavPlayersImage, nameDataGridViewTextBoxColumn1, shirtNumberDataGridViewTextBoxColumn1, positionDataGridViewTextBoxColumn1, captainDataGridViewCheckBoxColumn1 });
            dataGridFavPlayers.DataSource = playerBindingSource3;
            dataGridFavPlayers.GridColor = Color.DarkGoldenrod;
            dataGridFavPlayers.Location = new Point(597, 74);
            dataGridFavPlayers.Name = "dataGridFavPlayers";
            dataGridFavPlayers.ReadOnly = true;
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = Color.LightGoldenrodYellow;
            dataGridViewCellStyle10.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle10.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = Color.Goldenrod;
            dataGridViewCellStyle10.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = DataGridViewTriState.True;
            dataGridFavPlayers.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            dataGridFavPlayers.RowHeadersWidth = 51;
            dataGridFavPlayers.RowTemplate.Height = 64;
            dataGridFavPlayers.Size = new Size(556, 279);
            dataGridFavPlayers.TabIndex = 8;
            dataGridFavPlayers.CellMouseClick += dataGridFavPlayers_CellMouseClick;
            dataGridFavPlayers.DragDrop += dataGridFavPlayers_DragDrop;
            dataGridFavPlayers.DragEnter += dataGridPlayers_DragEnter;
            dataGridFavPlayers.MouseDown += dataGridFavPlayers_MouseDown;
            // 
            // dataGridFavPlayersImage
            // 
            dataGridFavPlayersImage.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridFavPlayersImage.DataPropertyName = "Image";
            dataGridFavPlayersImage.HeaderText = "Image";
            dataGridFavPlayersImage.Name = "dataGridFavPlayersImage";
            dataGridFavPlayersImage.ReadOnly = true;
            dataGridFavPlayersImage.ToolTipText = "Kliknite za promjenu slike.";
            dataGridFavPlayersImage.Width = 64;
            // 
            // nameDataGridViewTextBoxColumn1
            // 
            nameDataGridViewTextBoxColumn1.DataPropertyName = "Name";
            dataGridViewCellStyle6.BackColor = Color.LightGoldenrodYellow;
            dataGridViewCellStyle6.SelectionBackColor = Color.Goldenrod;
            nameDataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle6;
            nameDataGridViewTextBoxColumn1.HeaderText = "Ime";
            nameDataGridViewTextBoxColumn1.MinimumWidth = 6;
            nameDataGridViewTextBoxColumn1.Name = "nameDataGridViewTextBoxColumn1";
            nameDataGridViewTextBoxColumn1.ReadOnly = true;
            nameDataGridViewTextBoxColumn1.Width = 125;
            // 
            // shirtNumberDataGridViewTextBoxColumn1
            // 
            shirtNumberDataGridViewTextBoxColumn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            shirtNumberDataGridViewTextBoxColumn1.DataPropertyName = "ShirtNumber";
            dataGridViewCellStyle7.BackColor = Color.LightGoldenrodYellow;
            dataGridViewCellStyle7.SelectionBackColor = Color.Goldenrod;
            shirtNumberDataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle7;
            shirtNumberDataGridViewTextBoxColumn1.HeaderText = "Broj";
            shirtNumberDataGridViewTextBoxColumn1.MinimumWidth = 6;
            shirtNumberDataGridViewTextBoxColumn1.Name = "shirtNumberDataGridViewTextBoxColumn1";
            shirtNumberDataGridViewTextBoxColumn1.ReadOnly = true;
            shirtNumberDataGridViewTextBoxColumn1.Width = 60;
            // 
            // positionDataGridViewTextBoxColumn1
            // 
            positionDataGridViewTextBoxColumn1.DataPropertyName = "Position";
            dataGridViewCellStyle8.BackColor = Color.LightGoldenrodYellow;
            dataGridViewCellStyle8.SelectionBackColor = Color.Goldenrod;
            positionDataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle8;
            positionDataGridViewTextBoxColumn1.HeaderText = "Pozicija";
            positionDataGridViewTextBoxColumn1.MinimumWidth = 6;
            positionDataGridViewTextBoxColumn1.Name = "positionDataGridViewTextBoxColumn1";
            positionDataGridViewTextBoxColumn1.ReadOnly = true;
            positionDataGridViewTextBoxColumn1.Width = 125;
            // 
            // captainDataGridViewCheckBoxColumn1
            // 
            captainDataGridViewCheckBoxColumn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            captainDataGridViewCheckBoxColumn1.DataPropertyName = "Captain";
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = Color.LightGoldenrodYellow;
            dataGridViewCellStyle9.NullValue = false;
            dataGridViewCellStyle9.SelectionBackColor = Color.Goldenrod;
            captainDataGridViewCheckBoxColumn1.DefaultCellStyle = dataGridViewCellStyle9;
            captainDataGridViewCheckBoxColumn1.HeaderText = "Kapetan";
            captainDataGridViewCheckBoxColumn1.MinimumWidth = 6;
            captainDataGridViewCheckBoxColumn1.Name = "captainDataGridViewCheckBoxColumn1";
            captainDataGridViewCheckBoxColumn1.ReadOnly = true;
            captainDataGridViewCheckBoxColumn1.Width = 62;
            // 
            // menuStripMain
            // 
            menuStripMain.BackColor = Color.Goldenrod;
            menuStripMain.ImageScalingSize = new Size(20, 20);
            menuStripMain.Items.AddRange(new ToolStripItem[] { menuStripFile, menuStripSettings, menuStripFavTeamComboBox });
            menuStripMain.Location = new Point(0, 0);
            menuStripMain.Name = "menuStripMain";
            menuStripMain.Padding = new Padding(6, 6, 0, 6);
            menuStripMain.Size = new Size(1918, 37);
            menuStripMain.TabIndex = 9;
            menuStripMain.Text = "menuStrip1";
            // 
            // menuStripFile
            // 
            menuStripFile.DropDownItems.AddRange(new ToolStripItem[] { menuStripFilePrintStats });
            menuStripFile.Font = new Font("Consolas", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            menuStripFile.Name = "menuStripFile";
            menuStripFile.Size = new Size(84, 25);
            menuStripFile.Text = "Datoteka";
            // 
            // menuStripFilePrintStats
            // 
            menuStripFilePrintStats.Name = "menuStripFilePrintStats";
            menuStripFilePrintStats.Size = new Size(204, 22);
            menuStripFilePrintStats.Text = "Ispis rang lista";
            menuStripFilePrintStats.Click += menuStripFilePrintStats_Click;
            // 
            // menuStripSettings
            // 
            menuStripSettings.CheckOnClick = true;
            menuStripSettings.Font = new Font("Consolas", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            menuStripSettings.Name = "menuStripSettings";
            menuStripSettings.Size = new Size(84, 25);
            menuStripSettings.Text = "Postavke";
            menuStripSettings.Click += menuStripSettings_Click;
            // 
            // menuStripFavTeamComboBox
            // 
            menuStripFavTeamComboBox.Font = new Font("Consolas", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            menuStripFavTeamComboBox.Name = "menuStripFavTeamComboBox";
            menuStripFavTeamComboBox.Size = new Size(350, 25);
            menuStripFavTeamComboBox.Text = "Omiljena reprezentacija <odaberi>";
            menuStripFavTeamComboBox.SelectedIndexChanged += cmbFavRep_SelectedIndexChanged;
            // 
            // cntxMenuStrip
            // 
            cntxMenuStrip.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point);
            cntxMenuStrip.ImageScalingSize = new Size(20, 20);
            cntxMenuStrip.Items.AddRange(new ToolStripItem[] { cntxMenuStripFavPlayer });
            cntxMenuStrip.Name = "cntxMenuStrip";
            cntxMenuStrip.Size = new Size(173, 26);
            // 
            // cntxMenuStripFavPlayer
            // 
            cntxMenuStripFavPlayer.Name = "cntxMenuStripFavPlayer";
            cntxMenuStripFavPlayer.Size = new Size(172, 22);
            cntxMenuStripFavPlayer.Text = "Prebaci Igrača";
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
            dataGridPlayerRangList.Columns.AddRange(new DataGridViewColumn[] { dataGridPlayerRangListImage, GamesPlayed, dataGridViewTextBoxColumn1, Goals, YellowCards });
            dataGridPlayerRangList.DataSource = playerBindingSource3;
            dataGridPlayerRangList.GridColor = Color.DarkGoldenrod;
            dataGridPlayerRangList.Location = new Point(1237, 74);
            dataGridPlayerRangList.Name = "dataGridPlayerRangList";
            dataGridPlayerRangList.ReadOnly = true;
            dataGridViewCellStyle16.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = Color.LightGoldenrodYellow;
            dataGridViewCellStyle16.Font = new Font("Consolas", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle16.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle16.SelectionBackColor = Color.Goldenrod;
            dataGridViewCellStyle16.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = DataGridViewTriState.True;
            dataGridPlayerRangList.RowHeadersDefaultCellStyle = dataGridViewCellStyle16;
            dataGridPlayerRangList.RowHeadersWidth = 51;
            dataGridPlayerRangList.RowTemplate.Height = 64;
            dataGridPlayerRangList.Size = new Size(584, 867);
            dataGridPlayerRangList.TabIndex = 11;
            dataGridPlayerRangList.CellContentClick += dataGridPlayerRangList_CellContentClick;
            dataGridPlayerRangList.CellFormatting += dataGridPlayerRangList_CellFormatting;
            // 
            // dataGridPlayerRangListImage
            // 
            dataGridPlayerRangListImage.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridPlayerRangListImage.DataPropertyName = "Image";
            dataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = Color.LightGoldenrodYellow;
            dataGridViewCellStyle11.NullValue = null;
            dataGridViewCellStyle11.SelectionBackColor = Color.Goldenrod;
            dataGridPlayerRangListImage.DefaultCellStyle = dataGridViewCellStyle11;
            dataGridPlayerRangListImage.HeaderText = "Slika";
            dataGridPlayerRangListImage.MinimumWidth = 6;
            dataGridPlayerRangListImage.Name = "dataGridPlayerRangListImage";
            dataGridPlayerRangListImage.ReadOnly = true;
            dataGridPlayerRangListImage.Resizable = DataGridViewTriState.True;
            dataGridPlayerRangListImage.SortMode = DataGridViewColumnSortMode.Automatic;
            dataGridPlayerRangListImage.ToolTipText = "Kliknite za promjenu slike.";
            dataGridPlayerRangListImage.Width = 64;
            // 
            // GamesPlayed
            // 
            GamesPlayed.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            GamesPlayed.DataPropertyName = "GamesPlayed";
            dataGridViewCellStyle12.BackColor = Color.LightGoldenrodYellow;
            dataGridViewCellStyle12.SelectionBackColor = Color.Goldenrod;
            GamesPlayed.DefaultCellStyle = dataGridViewCellStyle12;
            GamesPlayed.HeaderText = "Sudjelovao";
            GamesPlayed.Name = "GamesPlayed";
            GamesPlayed.ReadOnly = true;
            GamesPlayed.Width = 102;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.DataPropertyName = "Name";
            dataGridViewCellStyle13.BackColor = Color.LightGoldenrodYellow;
            dataGridViewCellStyle13.SelectionBackColor = Color.Goldenrod;
            dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle13;
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
            dataGridViewCellStyle14.BackColor = Color.LightGoldenrodYellow;
            dataGridViewCellStyle14.SelectionBackColor = Color.Goldenrod;
            Goals.DefaultCellStyle = dataGridViewCellStyle14;
            Goals.HeaderText = "Golovi";
            Goals.MinimumWidth = 6;
            Goals.Name = "Goals";
            Goals.ReadOnly = true;
            Goals.Width = 74;
            // 
            // YellowCards
            // 
            YellowCards.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            YellowCards.DataPropertyName = "YellowCards";
            dataGridViewCellStyle15.BackColor = Color.LightGoldenrodYellow;
            dataGridViewCellStyle15.SelectionBackColor = Color.Goldenrod;
            YellowCards.DefaultCellStyle = dataGridViewCellStyle15;
            YellowCards.HeaderText = "Žuti kartoni";
            YellowCards.MinimumWidth = 120;
            YellowCards.Name = "YellowCards";
            YellowCards.ReadOnly = true;
            YellowCards.Width = 120;
            // 
            // lblRangList
            // 
            lblRangList.AutoSize = true;
            lblRangList.Font = new Font("Consolas", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            lblRangList.Location = new Point(1244, 51);
            lblRangList.Name = "lblRangList";
            lblRangList.Size = new Size(88, 17);
            lblRangList.TabIndex = 12;
            lblRangList.Text = "Rang lista";
            // 
            // rbSortYellowCards
            // 
            rbSortYellowCards.AutoSize = true;
            rbSortYellowCards.Location = new Point(422, 13);
            rbSortYellowCards.Name = "rbSortYellowCards";
            rbSortYellowCards.Padding = new Padding(3, 0, 3, 0);
            rbSortYellowCards.Size = new Size(115, 18);
            rbSortYellowCards.TabIndex = 13;
            rbSortYellowCards.Text = "Žuti kartoni";
            rbSortYellowCards.UseVisualStyleBackColor = true;
            rbSortYellowCards.Click += rbSort_Click;
            // 
            // rbSortGoals
            // 
            rbSortGoals.AutoSize = true;
            rbSortGoals.Location = new Point(343, 13);
            rbSortGoals.Name = "rbSortGoals";
            rbSortGoals.Padding = new Padding(3, 0, 3, 0);
            rbSortGoals.Size = new Size(73, 18);
            rbSortGoals.TabIndex = 14;
            rbSortGoals.Text = "Golovi";
            rbSortGoals.UseVisualStyleBackColor = true;
            rbSortGoals.Click += rbSort_Click;
            // 
            // grpRangListButtons
            // 
            grpRangListButtons.BackgroundImageLayout = ImageLayout.None;
            grpRangListButtons.Controls.Add(rbSortGamesPlayed);
            grpRangListButtons.Controls.Add(rbSortGoals);
            grpRangListButtons.Controls.Add(rbSortYellowCards);
            grpRangListButtons.FlatStyle = FlatStyle.Flat;
            grpRangListButtons.Location = new Point(1237, 40);
            grpRangListButtons.Name = "grpRangListButtons";
            grpRangListButtons.Size = new Size(584, 37);
            grpRangListButtons.TabIndex = 15;
            grpRangListButtons.TabStop = false;
            // 
            // rbSortGamesPlayed
            // 
            rbSortGamesPlayed.AutoSize = true;
            rbSortGamesPlayed.Checked = true;
            rbSortGamesPlayed.Location = new Point(117, 13);
            rbSortGamesPlayed.Name = "rbSortGamesPlayed";
            rbSortGamesPlayed.Size = new Size(95, 18);
            rbSortGamesPlayed.TabIndex = 15;
            rbSortGamesPlayed.TabStop = true;
            rbSortGamesPlayed.Text = "Sudjelovao";
            rbSortGamesPlayed.UseVisualStyleBackColor = true;
            rbSortGamesPlayed.Click += rbSort_Click;
            // 
            // dataGridFavTeamMatches
            // 
            dataGridFavTeamMatches.AllowDrop = true;
            dataGridFavTeamMatches.AllowUserToAddRows = false;
            dataGridFavTeamMatches.AllowUserToDeleteRows = false;
            dataGridFavTeamMatches.AllowUserToResizeColumns = false;
            dataGridFavTeamMatches.AllowUserToResizeRows = false;
            dataGridFavTeamMatches.AutoGenerateColumns = false;
            dataGridFavTeamMatches.BackgroundColor = Color.LightGoldenrodYellow;
            dataGridFavTeamMatches.CellBorderStyle = DataGridViewCellBorderStyle.Sunken;
            dataGridFavTeamMatches.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridFavTeamMatches.Columns.AddRange(new DataGridViewColumn[] { locationDataGridViewTextBoxColumn, attendanceDataGridViewTextBoxColumn, homeTeamCountryDataGridViewTextBoxColumn, awayTeamCountryDataGridViewTextBoxColumn });
            dataGridFavTeamMatches.DataSource = matchesBindingSource;
            dataGridFavTeamMatches.GridColor = Color.DarkGoldenrod;
            dataGridFavTeamMatches.Location = new Point(597, 401);
            dataGridFavTeamMatches.Name = "dataGridFavTeamMatches";
            dataGridFavTeamMatches.ReadOnly = true;
            dataGridViewCellStyle21.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.BackColor = Color.LightGoldenrodYellow;
            dataGridViewCellStyle21.Font = new Font("Consolas", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle21.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle21.SelectionBackColor = Color.Goldenrod;
            dataGridViewCellStyle21.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle21.WrapMode = DataGridViewTriState.True;
            dataGridFavTeamMatches.RowHeadersDefaultCellStyle = dataGridViewCellStyle21;
            dataGridFavTeamMatches.RowHeadersWidth = 51;
            dataGridFavTeamMatches.RowTemplate.Height = 29;
            dataGridFavTeamMatches.Size = new Size(556, 534);
            dataGridFavTeamMatches.TabIndex = 16;
            // 
            // locationDataGridViewTextBoxColumn
            // 
            locationDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            locationDataGridViewTextBoxColumn.DataPropertyName = "Location";
            dataGridViewCellStyle17.BackColor = Color.LightGoldenrodYellow;
            dataGridViewCellStyle17.SelectionBackColor = Color.Goldenrod;
            locationDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle17;
            locationDataGridViewTextBoxColumn.HeaderText = "Lokacija";
            locationDataGridViewTextBoxColumn.Name = "locationDataGridViewTextBoxColumn";
            locationDataGridViewTextBoxColumn.ReadOnly = true;
            locationDataGridViewTextBoxColumn.Width = 88;
            // 
            // attendanceDataGridViewTextBoxColumn
            // 
            attendanceDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            attendanceDataGridViewTextBoxColumn.DataPropertyName = "Attendance";
            dataGridViewCellStyle18.BackColor = Color.LightGoldenrodYellow;
            dataGridViewCellStyle18.SelectionBackColor = Color.Goldenrod;
            attendanceDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle18;
            attendanceDataGridViewTextBoxColumn.HeaderText = "Posjetitelji";
            attendanceDataGridViewTextBoxColumn.Name = "attendanceDataGridViewTextBoxColumn";
            attendanceDataGridViewTextBoxColumn.ReadOnly = true;
            attendanceDataGridViewTextBoxColumn.Width = 116;
            // 
            // homeTeamCountryDataGridViewTextBoxColumn
            // 
            homeTeamCountryDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            homeTeamCountryDataGridViewTextBoxColumn.DataPropertyName = "HomeTeamCountry";
            dataGridViewCellStyle19.BackColor = Color.LightGoldenrodYellow;
            dataGridViewCellStyle19.SelectionBackColor = Color.Goldenrod;
            homeTeamCountryDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle19;
            homeTeamCountryDataGridViewTextBoxColumn.HeaderText = "Domaćin";
            homeTeamCountryDataGridViewTextBoxColumn.Name = "homeTeamCountryDataGridViewTextBoxColumn";
            homeTeamCountryDataGridViewTextBoxColumn.ReadOnly = true;
            homeTeamCountryDataGridViewTextBoxColumn.Width = 81;
            // 
            // awayTeamCountryDataGridViewTextBoxColumn
            // 
            awayTeamCountryDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            awayTeamCountryDataGridViewTextBoxColumn.DataPropertyName = "AwayTeamCountry";
            dataGridViewCellStyle20.BackColor = Color.LightGoldenrodYellow;
            dataGridViewCellStyle20.SelectionBackColor = Color.Goldenrod;
            awayTeamCountryDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle20;
            awayTeamCountryDataGridViewTextBoxColumn.HeaderText = "Gost";
            awayTeamCountryDataGridViewTextBoxColumn.Name = "awayTeamCountryDataGridViewTextBoxColumn";
            awayTeamCountryDataGridViewTextBoxColumn.ReadOnly = true;
            awayTeamCountryDataGridViewTextBoxColumn.Width = 60;
            // 
            // matchesBindingSource
            // 
            matchesBindingSource.DataSource = typeof(DataRepository.Models.Matches);
            // 
            // lblFavTeamMatches
            // 
            lblFavTeamMatches.AutoSize = true;
            lblFavTeamMatches.Font = new Font("Consolas", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            lblFavTeamMatches.Location = new Point(597, 378);
            lblFavTeamMatches.Name = "lblFavTeamMatches";
            lblFavTeamMatches.Size = new Size(288, 17);
            lblFavTeamMatches.TabIndex = 17;
            lblFavTeamMatches.Text = "Rang lista prema broju posjetitelja";
            // 
            // lblConnection
            // 
            lblConnection.AutoSize = true;
            lblConnection.Location = new Point(1844, 37);
            lblConnection.Name = "lblConnection";
            lblConnection.Size = new Size(0, 14);
            lblConnection.TabIndex = 18;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1918, 977);
            Controls.Add(lblConnection);
            Controls.Add(lblFavTeamMatches);
            Controls.Add(dataGridFavTeamMatches);
            Controls.Add(lblRangList);
            Controls.Add(dataGridPlayerRangList);
            Controls.Add(dataGridFavPlayers);
            Controls.Add(lblDebug01);
            Controls.Add(dataGridAllPlayers);
            Controls.Add(lblFavPlayers);
            Controls.Add(menuStripMain);
            Controls.Add(grpRangListButtons);
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
            grpRangListButtons.ResumeLayout(false);
            grpRangListButtons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridFavTeamMatches).EndInit();
            ((System.ComponentModel.ISupportInitialize)matchesBindingSource).EndInit();
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
        private BindingSource playerBindingSource3;
        private DataGridView dataGridPlayerRangList;
        private Label lblRangList;
        private RadioButton rbSortYellowCards;
        private RadioButton rbSortGoals;
        private GroupBox grpRangListButtons;
        private RadioButton rbSortGamesPlayed;
        private DataGridView dataGridFavTeamMatches;
        private BindingSource matchesBindingSource;
        private DataGridViewTextBoxColumn locationDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn attendanceDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn homeTeamCountryDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn awayTeamCountryDataGridViewTextBoxColumn;
        private Label lblFavTeamMatches;
        private Label lblConnection;
        private DataGridViewImageColumn DataGridAllPlayersImage;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn shirtNumberDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn positionDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn captainDataGridViewCheckBoxColumn;
        private DataGridViewImageColumn dataGridFavPlayersImage;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn shirtNumberDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn positionDataGridViewTextBoxColumn1;
        private DataGridViewCheckBoxColumn captainDataGridViewCheckBoxColumn1;
        private DataGridViewImageColumn dataGridPlayerRangListImage;
        private DataGridViewTextBoxColumn GamesPlayed;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn Goals;
        private DataGridViewTextBoxColumn YellowCards;
    }
}