using DataRepository.Dal;
using DataRepository.Models;
using DataRepository.Utilities;
using System.Reflection;
using System.Resources;
using System.Text.RegularExpressions;

namespace DesktopWinForms
{
    public partial class MainForm : Form
    {
        private static DataManager dataManager = new DataManager();
        private ISet<Results> results = new HashSet<Results>();
        private ISet<Matches> matches = new HashSet<Matches>();
        private ISet<Matches> favTeamMetch = new HashSet<Matches>();

        private readonly ISettingsRepository settingsRepo;
        public SettingsLocal AppSettings { get; set; }
        private SettingsFavorite settingsFavorite;

        private ISet<Player> playerSet = new HashSet<Player>();
        private ISet<Player> favPlayerSet = new HashSet<Player>();
        private ISet<Player> playerRangList = new HashSet<Player>();
        private static PlayerImageManager playerImageManager = new PlayerImageManager();

        // dictionary with team name as key and set of players as value
        private Dictionary<string, ISet<Player>> teamDictionary = new Dictionary<string, ISet<Player>>();

        public MainForm()
        {
            InitializeComponent();

            // prepare settings object
            AppSettings = new SettingsLocal();

            // initialize settings
            settingsRepo = RepositoryFactory.GetSettingsRepo();
            // create favorite settings file with default values
            settingsFavorite = new SettingsFavorite();

            // scribe from FormClosing event
            SubscribeEventMainForm_FormClosing();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // if settings file does not exist, show startup settings form
            CheckIfSettingsFileExists();
            // if settings favorite file does not exist set default values
            CheckIfSettingsFavoriteFileExists();

            // load results & matches and display them
            using (LoadingForm loadingForm = new LoadingForm(LoadResultsAndMetches))
            {
                //show loading form if operation takes longer than expected
                loadingForm.ShowDialog();
            }

            DisplayLoadedResultsAndMetches();
            // load players from favorite team and display them
            GetPlayersFromFavoriteTeam();
            // display players from selected favorite team in dataGridAllPlayers
            DisplayPlayersFromFavoriteTeam();
            // display favorite players in dataGridFavPlayers
            DisplayFavoritePlayers();
            // display player rang list
            DisplayPlayerRangList();
            // display favorite team matches in dataGridFavTeamMatches
            DisplayFavoriteTeamMatches();

            // change current lozalizable language
            SetLanguage();
        }


        private void SetLanguage()
        {
            try
            {
                ResourceManager resourceManager = new ResourceManager("DesktopWinForms.Resources.croatian", Assembly.GetExecutingAssembly());
                // change current lozalizable language to english
                if (AppSettings.Language == "eng")
                {
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
                    resourceManager = new ResourceManager("DesktopWinForms.Resources.english", Assembly.GetExecutingAssembly());
                }
                // change current lozalizable language to croatian
                else if (AppSettings.Language == "cro")
                {
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("hr-HR");
                    resourceManager = new ResourceManager("DesktopWinForms.Resources.croatian", Assembly.GetExecutingAssembly());
                }
                TranslateMainForm(resourceManager);
            }
            catch (Exception ex)
            {
                //dataManager.ErrorLog(ex.Message + ", " + ex.StackTrace);
            }

        }

        private void TranslateMainForm(ResourceManager resourceManager)
        {
            this.Text = resourceManager.GetString("MainForm");
            menuStripFile.Text = resourceManager.GetString("menuStripFile");
            menuStripSettings.Text = resourceManager.GetString("menuStripSettings");
            menuStripFilePrintStats.Text = resourceManager.GetString("menuStripFilePrintStats");
            // if favorite settings file does not exist set default values
            if (settingsFavorite.FavoriteTeam != null)
            {
                menuStripFavTeamComboBox.Text = settingsFavorite.FavoriteTeam;
            }
            else
            {
                menuStripFavTeamComboBox.Text = resourceManager.GetString("menuStripFavTeamComboBox");
            }
            lblFavPlayers.Text = resourceManager.GetString("lblFavPlayers");
            lblFavTeamMatches.Text = resourceManager.GetString("lblFavTeamMatches");
            lblRangList.Text = resourceManager.GetString("lblRangList");
            rbSortGamesPlayed.Text = resourceManager.GetString("rbSortGamesPlayed");
            rbSortGoals.Text = resourceManager.GetString("rbSortGoals");
            rbSortYellowCards.Text = resourceManager.GetString("rbSortYellowCards");
            // data grid view columns
            dataGridAllPlayers.Columns[0].HeaderText = resourceManager.GetString("dataGridImage");
            dataGridAllPlayers.Columns[1].HeaderText = resourceManager.GetString("dataGridName");
            dataGridAllPlayers.Columns[2].HeaderText = resourceManager.GetString("dataGridNumber");
            dataGridAllPlayers.Columns[3].HeaderText = resourceManager.GetString("dataGridPosition");
            dataGridAllPlayers.Columns[4].HeaderText = resourceManager.GetString("dataGridCaptain");
            dataGridFavPlayers.Columns[0].HeaderText = resourceManager.GetString("dataGridImage");
            dataGridFavPlayers.Columns[1].HeaderText = resourceManager.GetString("dataGridName");
            dataGridFavPlayers.Columns[2].HeaderText = resourceManager.GetString("dataGridNumber");
            dataGridFavPlayers.Columns[3].HeaderText = resourceManager.GetString("dataGridPosition");
            dataGridFavPlayers.Columns[4].HeaderText = resourceManager.GetString("dataGridCaptain");
            dataGridFavTeamMatches.Columns[0].HeaderText = resourceManager.GetString("dataGridLoacation");
            dataGridFavTeamMatches.Columns[1].HeaderText = resourceManager.GetString("dataGridAttendance");
            dataGridFavTeamMatches.Columns[2].HeaderText = resourceManager.GetString("dataGridHomeTeam");
            dataGridFavTeamMatches.Columns[3].HeaderText = resourceManager.GetString("dataGridAwayTeam");
            dataGridPlayerRangList.Columns[0].HeaderText = resourceManager.GetString("dataGridImage");
            dataGridPlayerRangList.Columns[1].HeaderText = resourceManager.GetString("rbSortGamesPlayed");
            dataGridPlayerRangList.Columns[2].HeaderText = resourceManager.GetString("dataGridName");
            dataGridPlayerRangList.Columns[3].HeaderText = resourceManager.GetString("rbSortGoals");
            dataGridPlayerRangList.Columns[4].HeaderText = resourceManager.GetString("rbSortYellowCards");
            cntxMenuStripFavPlayer.Text = resourceManager.GetString("cntxMenuStripFavPlayer");
        }

        private void DisplayFavoriteTeamMatches()
        {
            // sort favTeamMetch by attendace
            favTeamMetch = favTeamMetch.OrderByDescending(x => x.Attendance).ToHashSet();

            // display favorite team matches in dataGridFavTeamMatches
            dataGridFavTeamMatches.DataSource = favTeamMetch.ToList();
        }

        private void DisplayPlayerRangList()
        {
            // sort playerRangList by goals if rbSortGoals is checked
            if (rbSortGoals.Checked)
            {
                playerRangList = playerRangList.OrderByDescending(x => x.Goals).ToHashSet();
            }
            // sort playerRangList by yellow cards if rbSortYellowCards is checked
            else if (rbSortYellowCards.Checked)
            {
                playerRangList = playerRangList.OrderByDescending(x => x.YellowCards).ToHashSet();
            }
            // sort playerRangList by games played if rbSortGamesPlayed is checked
            else if (rbSortGamesPlayed.Checked)
            {
                playerRangList = playerRangList.OrderByDescending(x => x.GamesPlayed).ToHashSet();
            }

            // display playerRangList in dataGridPlayerRangList
            dataGridPlayerRangList.DataSource = playerRangList.ToList();
        }

        private void LoadResultsAndMetches()
        {
            //Thread.Sleep(4000); // just for test purposes

            try
            {
                results = dataManager.GetResultsByChampionship(AppSettings.Championship);
                matches = dataManager.GetMatchesByChampionship(AppSettings.Championship);
            }
            catch (Exception ex)
            {
                // save log message;
                //dataManager.ErrorLog(ex.Message);
                // load results from file
                dataManager.SetFileDataRepo();
                // load results based on settings
                results = dataManager.GetResultsByChampionship(AppSettings.Championship);
                matches = dataManager.GetMatchesByChampionship(AppSettings.Championship);
                // display that data is loaded from file (lblConnection = offline)
                lblConnection.Text = "Offline";
                lblConnection.ForeColor = Color.Red;
            }

        }

        private void DisplayLoadedResultsAndMetches()
        {
            // sort the resluts by GroupId
            results.OrderBy(x => x.GroupId).ToHashSet();

            // display Country and FifaCode in comboBox
            foreach (var item in results)
            {
                menuStripFavTeamComboBox.Items.Add($"{item.Country} ({item.FifaCode})");
            }
            // sort menuStripFavTeamComboBox
            menuStripFavTeamComboBox.Sorted = true;
        }

        private void DisplayFavoritePlayers()
        {
            // add players to favPlayerSet if their shirt number is in settingsFavorite.FavoritePlayerShirtNums
            foreach (Player player in playerSet)
            {
                if (settingsFavorite.FavoritePlayerShirtNums.Contains(player.ShirtNumber))
                {
                    favPlayerSet.Add(player);
                    playerSet.Remove(player);
                }
            }

            // sort players by shirt number
            playerSet = playerSet.OrderBy(x => x.ShirtNumber).ToHashSet();
            favPlayerSet = favPlayerSet.OrderBy(x => x.ShirtNumber).ToHashSet();

            // display players in dataGridFavPlayers
            dataGridFavPlayers.DataSource = favPlayerSet.ToList();
            CustomizeFavoriteColumnAppearance(dataGridFavPlayers);
            //dataGridFavPlayers.Refresh();

            // display players in dataGridAllPlayers
            dataGridAllPlayers.DataSource = playerSet.ToList();

        }

        private void RemoveFavPlayersFromPanel()
        {
            // remove all players
            favPlayerSet.Clear();
            // clear the list of shirt numbers
            settingsFavorite.FavoritePlayerShirtNums.Clear();
            // clear the list of players in dataGridFavPlayers
            dataGridFavPlayers.DataSource = favPlayerSet.ToList();
        }

        private void DisplayPlayersFromFavoriteTeam()
        {
            // sort players by shirt number
            playerSet = playerSet.OrderBy(x => x.ShirtNumber).ToHashSet();

            // display players in dataGridAllPlayers
            dataGridAllPlayers.DataSource = playerSet.ToList();

        }

        private void GetPlayersFromFavoriteTeam()
        {
            ClearDataGrids();

            // if team exists in teamDictionary then use dictionary to get players
            //  -> user has already selected that team and players are already loaded
            if (teamDictionary.ContainsKey(settingsFavorite.FavoriteTeam))
            {
                playerSet = teamDictionary[settingsFavorite.FavoriteTeam];
                playerRangList = playerSet.ToHashSet();
                // add match to favTeamMetch
                GetFavTeamMetch();
                // set playrSet and playerFavSet based on teamDictionary
                foreach (Player player in teamDictionary[settingsFavorite.FavoriteTeam])
                {
                    if (player.Favorite)
                    {
                        playerSet.Remove(player);
                        favPlayerSet.Add(player);
                    }
                }

                return;
            }

            // get players from favorite team and add them to playerSet
            foreach (Matches match in matches)
            {
                // if home team is favorite team
                if (match.HomeTeamCountry == settingsFavorite.FavoriteTeam)
                {
                    try
                    {
                        GetFavHomeTeamData(match);
                    }
                    catch (Exception ex)
                    {
                        //dataManager.ErrorLog(ex.Message + ", " + ex.StackTrace);
                    }
                }
                if (match.AwayTeamCountry == settingsFavorite.FavoriteTeam)
                {
                    try
                    {
                        GetFavAwayTeamData(match);
                    }
                    catch (Exception ex)
                    {
                        //dataManager.ErrorLog(ex.Message + ", " + ex.StackTrace);
                    }
                }
            }

            // add players to teamDictionary
            teamDictionary.Add(settingsFavorite.FavoriteTeam, playerSet);
        }

        private void GetFavTeamMetch()
        {
            foreach (Matches match in matches)
            {
                if (match.HomeTeamCountry == settingsFavorite.FavoriteTeam || match.AwayTeamCountry == settingsFavorite.FavoriteTeam)
                {
                    // add metch to FavTeamMetch
                    favTeamMetch.Add(match);
                }
            }
        }

        private void ClearDataGrids()
        {
            // remove all data from playerSet
            playerSet.Clear();
            // remove all data from playerRangList
            playerRangList.Clear();
            // remove all data from favPlayerSet
            favPlayerSet.Clear();
            // clear favTeamMetch
            favTeamMetch.Clear();
        }

        private void GetFavAwayTeamData(Matches match)
        {
            // add players from starting eleven and substitutes
            match.AwayTeamStatistics.StartingEleven.ForEach(x =>
            {
                playerSet.Add(x);
                //x.Image = playerImageManager.GetDefaultImage();
                x = playerImageManager.LoadPlayerImage(x);
                x.GamesPlayed++;
                playerRangList.Add(x);
            });
            match.AwayTeamStatistics.Substitutes.ForEach(x =>
            {
                playerSet.Add(x);
                //x.Image = playerImageManager.GetDefaultImage();
                x = playerImageManager.LoadPlayerImage(x);
                x.GamesPlayed++;
                playerRangList.Add(x);
            });
            // add goal and yellow cards to playerRangList if player scored a goal
            match.AwayTeamEvents.ForEach(x =>
            {
                if (x.TypeOfEvent == "goal" || x.TypeOfEvent == "goal-penalty")
                {
                    // get player from playerRangList
                    Player player = playerRangList.First(y => y.Name == x.Player);
                    player.Goals++;
                }
                if (x.TypeOfEvent == "yellow-card")
                {
                    // get player from playerRangList
                    Player player = playerRangList.First(y => y.Name == x.Player);
                    player.YellowCards++;
                }
                if (x.TypeOfEvent == "substitution-in")
                {
                    Player player = playerRangList.First(y => y.Name == x.Player);
                    // add Games Played
                    player.GamesPlayed++;
                }
            });

            // add metch to FavTeamMetch
            favTeamMetch.Add(match);
        }

        private void GetFavHomeTeamData(Matches match)
        {
            // add players from starting eleven and substitutes
            match.HomeTeamStatistics.StartingEleven.ForEach(x =>
            {
                playerSet.Add(x);
                //x.Image = playerImageManager.GetDefaultImage();
                x = playerImageManager.LoadPlayerImage(x);
                x.GamesPlayed++;
                playerRangList.Add(x);
            });
            match.HomeTeamStatistics.Substitutes.ForEach(x =>
            {
                playerSet.Add(x);
                //x.Image = playerImageManager.GetDefaultImage();
                x = playerImageManager.LoadPlayerImage(x);
                x.GamesPlayed++;
                playerRangList.Add(x);
            });

            // add goal and yellow cards to playerRangList if player scored a goal
            match.HomeTeamEvents.ForEach(x =>
            {
                if (x.TypeOfEvent == "goal" || x.TypeOfEvent == "goal-penalty")
                {
                    // get player from playerRangList
                    Player player = playerRangList.First(y => y.Name == x.Player);
                    // add goal to player
                    player.Goals++;
                }
                if (x.TypeOfEvent == "yellow-card")
                {
                    Player player = playerRangList.First(y => y.Name == x.Player);
                    // add yellow card to player
                    player.YellowCards++;
                }
                if (x.TypeOfEvent == "substitution-in")
                {
                    Player player = playerRangList.First(y => y.Name == x.Player);
                    // add Games Played
                    player.GamesPlayed++;
                }
            });

            // add metch to FavTeamMetch
            favTeamMetch.Add(match);
        }

        private void CheckIfSettingsFileExists()
        {
            if (!settingsRepo.SettingsFileCreated())
            {
                SettingsForm settingsForm = new SettingsForm("Početne Postavke");
                // settings form will have to access AppSettings prop
                settingsForm.MainForm = this;
                // unsubscribe to prevent infinite loop
                UnsubscribeEventMainForm_FormClosing();
                // show settings form
                settingsForm.ShowDialog();
            }
            else
            {
                // load settings from file
                AppSettings = settingsRepo.LoadSettings();
            }
        }

        private void CheckIfSettingsFavoriteFileExists()
        {
            if (!settingsRepo.SettingsFavoriteFileCreated())
            {
                settingsFavorite.FavoriteTeam = "Croatia";
                settingsFavorite.FavoritePlayerShirtNums = new HashSet<int>() { 0 };
            }
            else
            {
                // load settings favorite from file
                settingsFavorite = settingsRepo.LoadSettingsFavorite();
                lblDebug01.Text = settingsFavorite.FavoriteTeam;
            }
        }

        public void SaveSettings()
        {
            // save settings to file
            settingsRepo.SaveSettings(AppSettings);
        }

        // SettingsChanged event handler
        private void SettingsForm_SettingsChanged(object sender, EventArgs e)
        {
            // reload the main form
            MainForm_Load(sender, e);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // string language if null set to "cro" else AppSettings.Language
            string language = AppSettings.Language == null ? "cro" : AppSettings.Language;
            // open the close form with settings language
            DialogResult dialogResult = new CloseForm(language).ShowDialog();
            // if the user clicked Yes, close the app
            if (dialogResult == DialogResult.Yes)
            {
                // unsubscribe to prevent infinite loop
                UnsubscribeEventMainForm_FormClosing();

                if (settingsFavorite.FavoritePlayerShirtNums.Count == 0)
                {
                    settingsFavorite.FavoritePlayerShirtNums = new HashSet<int>() { 0 };
                }

                // before exit store favorite settings
                settingsRepo.SaveSettingsFavorite(settingsFavorite);
                // close the application
                Application.Exit();
            }
            else
            {
                // do not close the app
                e.Cancel = true;
            }
        }

        // unsubscribe from FormClosing event
        public void UnsubscribeEventMainForm_FormClosing()
            => FormClosing -= MainForm_FormClosing;

        // scribe from FormClosing event
        public void SubscribeEventMainForm_FormClosing()
            => FormClosing += MainForm_FormClosing;

        // handle the MouseDown event of the dataGridAllPlayers
        // control to initiate the drag operation when the user selects a multiple rows
        private void dataGridAllPlayers_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // If the user is clicking and dragging, start a drag-and-drop operation
                DataGridView.HitTestInfo hitTestInfo = dataGridAllPlayers.HitTest(e.X, e.Y);
                if (hitTestInfo.Type == DataGridViewHitTestType.Cell &&
                    dataGridAllPlayers.SelectedRows.Count > 0 &&
                    hitTestInfo.ColumnIndex == 0 &&
                    hitTestInfo.RowIndex == dataGridAllPlayers.SelectedRows[0].Index)
                {
                    var selectedRows = dataGridAllPlayers.SelectedRows.Cast<DataGridViewRow>().ToArray();
                    dataGridAllPlayers.DoDragDrop(selectedRows, DragDropEffects.Move);
                }
            }
        }

        private void dataGridFavPlayers_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // If the user is clicking and dragging, start a drag-and-drop operation
                DataGridView.HitTestInfo hitTestInfo = dataGridFavPlayers.HitTest(e.X, e.Y);
                if (hitTestInfo.Type == DataGridViewHitTestType.Cell &&
                dataGridFavPlayers.SelectedRows.Count > 0 &&
                hitTestInfo.ColumnIndex == 0 &&
                hitTestInfo.RowIndex == dataGridFavPlayers.SelectedRows[0].Index)
                {
                    var selectedRows = dataGridFavPlayers.SelectedRows.Cast<DataGridViewRow>().ToArray();
                    dataGridFavPlayers.DoDragDrop(selectedRows, DragDropEffects.Move);
                }
            }
        }

        //handle the DragEnter and DragDrop events of the dataGridFavPlayers
        private void dataGridPlayers_DragEnter(object sender, DragEventArgs e)
            => e.Effect = DragDropEffects.Move;

        private async void dataGridFavPlayers_DragDrop(object sender, DragEventArgs e)
        {
            // implement drag-drop
            // get the rows that were dragged
            DataGridViewRow[] rows = (DataGridViewRow[])e.Data.GetData(typeof(DataGridViewRow[]));
            var players = rows.Select(r => (Player)r.DataBoundItem);

            DropPlayersToFavoriteTeam(players);
        }

        private void dataGridAllPlayers_DragDrop(object sender, DragEventArgs e)
        {
            // implement drag-drop
            // get the rows that were dragged
            DataGridViewRow[] rows = (DataGridViewRow[])e.Data.GetData(typeof(DataGridViewRow[]));
            var players = rows.Select(r => (Player)r.DataBoundItem);

            DropPlayersToAllPlayers(players);
        }

        private void menuStripSettings_Click(object sender, EventArgs e)
        {
            // clear the list of teams
            menuStripFavTeamComboBox.Items.Clear();

            SettingsForm settingsForm = new SettingsForm();
            // settings form will have to access AppSettings prop
            settingsForm.MainForm = this;
            // subscribe to SettingsAccepted event
            settingsForm.SettingsAccepted += SettingsForm_SettingsChanged;
            settingsForm.ShowDialog();
        }

        private void cmbFavRep_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblDebug01.Text = menuStripFavTeamComboBox.Text;
            // set favorite team in settingsFavorite only name is needed "Croatia (CRO)"
            settingsFavorite.FavoriteTeam = menuStripFavTeamComboBox.Text.Substring(0, menuStripFavTeamComboBox.Text.IndexOf("(") - 1);
            GetPlayersFromFavoriteTeam();
            DisplayPlayersFromFavoriteTeam();
            RemoveFavPlayersFromPanel();
            DisplayPlayerRangList();
            DisplayFavoriteTeamMatches();
        }

        private void dataGridAllPlayers_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // when press right mouse button on a player in dataGridAllPlayers 
            // open context menu with options to add player to favorite team
            if (e.Button == MouseButtons.Right)
            {
                // store all selected rows in a list
                List<DataGridViewRow> selectedRows = new List<DataGridViewRow>();
                foreach (DataGridViewRow row in dataGridAllPlayers.SelectedRows)
                {
                    selectedRows.Add(row);
                }

                // get the players from the selected rows
                IEnumerable<Player> players = selectedRows
                    .Select(row => row.DataBoundItem)
                    .OfType<Player>()
                    .ToList();

                // open context menu with options to add player to favorite team
                cntxMenuStrip.Show(Cursor.Position);

                // if cntxMenuStripFavPlayer was clicked then add players to favorite team
                cntxMenuStripFavPlayer.Click += (s, ev) =>
                {
                    DropPlayersToFavoriteTeam(players);
                };
            }
        }

        private void dataGridFavPlayers_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // when press right mouse button on a player in dataGridFavPlayers 
            // open context menu with options to remove player from favorite team
            if (e.Button == MouseButtons.Right)
            {
                // store all selected rows in a list
                List<DataGridViewRow> selectedRows = new List<DataGridViewRow>();
                foreach (DataGridViewRow row in dataGridFavPlayers.SelectedRows)
                {
                    selectedRows.Add(row);
                }

                // get the players from the selected rows
                IEnumerable<Player> players = selectedRows
                    .Select(row => row.DataBoundItem)
                    .OfType<Player>()
                    .ToList();

                // open context menu with options to remove player from favorite team
                cntxMenuStrip.Show(Cursor.Position);

                // if cntxMenuStripRemoveFavPlayer was clicked then remove players from favorite team
                cntxMenuStripFavPlayer.Click += (s, ev) =>
                {
                    DropPlayersToAllPlayers(players);
                };
            }
        }

        private void DropPlayersToFavoriteTeam(IEnumerable<Player> players)
        {
            foreach (var player in players)
            {
                if (favPlayerSet.Count < 3)
                {
                    // add player to favPlayerSet
                    favPlayerSet.Add(player);
                    // add player shirt number to 
                    settingsFavorite.FavoritePlayerShirtNums.Add(player.ShirtNumber);

                    // set that player as favorite
                    player.Favorite = true;

                    // remove that player from playerSet
                    playerSet.Remove(player);
                }
            }

            // sort the players by shirt number
            favPlayerSet = favPlayerSet.OrderBy(x => x.ShirtNumber).ToHashSet();
            playerSet = playerSet.OrderBy(x => x.ShirtNumber).ToHashSet();

            SetFavPlayersInDictionary();

            CustomizeFavoriteColumnAppearance(dataGridFavPlayers);

            // display players
            dataGridFavPlayers.DataSource = favPlayerSet.ToList();
            dataGridAllPlayers.DataSource = playerSet.ToList();

        }

        private void SetFavPlayersInDictionary()
        {
            // foreach player in favPlayerSet set Favorite = true for player in teamDictionary
            foreach (var player in teamDictionary[settingsFavorite.FavoriteTeam])
            {
                // if player is in favPlayerSet then set Favorite = true
                if (favPlayerSet.Contains(player))
                {
                    player.Favorite = true;
                }
                else
                {
                    player.Favorite = false;
                }
            }
        }

        private void DropPlayersToAllPlayers(IEnumerable<Player> players)
        {
            foreach (var player in players)
            {
                // remove the player from the favorite team
                favPlayerSet.Remove(player);
                // remove player shirt number from 
                settingsFavorite.FavoritePlayerShirtNums.Remove(player.ShirtNumber);

                // set that player as not favorite
                player.Favorite = false;

                // add that player to playerSet
                playerSet.Add(player);
            }

            // sort the players by shirt number
            favPlayerSet = favPlayerSet.OrderBy(x => x.ShirtNumber).ToHashSet();
            playerSet = playerSet.OrderBy(x => x.ShirtNumber).ToHashSet();

            SetFavPlayersInDictionary();

            CustomizeFavoriteColumnAppearance(dataGridFavPlayers);

            // display players
            dataGridFavPlayers.DataSource = favPlayerSet.ToList();
            dataGridAllPlayers.DataSource = playerSet.ToList();
        }

        private void CustomizeFavoriteColumnAppearance(DataGridView dataGridView)
        {
            // Handle the CellPainting event to draw a star instead of a check box
            // paint only one cell in the column at index -1 (the first column)
            dataGridView.CellPainting += (s, e) =>
            {
                if (e.ColumnIndex == -1 && e.RowIndex >= 0)
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                    int x = e.CellBounds.Left + 25;
                    int y = e.CellBounds.Top + (e.CellBounds.Height - e.CellStyle.Font.Height) / 2;
                    e.Graphics.DrawString("\u2605", e.CellStyle.Font, Brushes.Goldenrod, new Point(x, y));

                    e.Handled = true;
                }
            };
        }

        private void dataGridPlayerRangList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // check if the cell is in the column dataGridPlayerRangListImage
            if (e.ColumnIndex == dataGridPlayerRangList.Columns["dataGridPlayerRangListImage"].Index)
            {
                // open file explorer and let user choose image
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG";
                openFileDialog.InitialDirectory = playerImageManager.GetImageDirectoryPath();
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // get cell that was clicked
                    DataGridViewImageCell cell = (DataGridViewImageCell)dataGridPlayerRangList.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    // set the image of the picture box
                    cell.Value = Image.FromFile(openFileDialog.FileName);
                    // get the player from the row
                    Player player = (Player)dataGridPlayerRangList.Rows[e.RowIndex].DataBoundItem;
                    // set the image of the player
                    player.Image = (Image)cell.Value;
                    // save relative image path of the player
                    string imageName = Path.GetFileName(openFileDialog.FileName);
                    player.ImagePath = playerImageManager.GetRelativeImagePath(imageName);
                    // save the image of the player
                    playerImageManager.SavePlayerImage(player);
                }
                // show images in all data grids
                dataGridFavPlayers.Refresh();
                dataGridAllPlayers.Refresh();
            }
        }

        private void dataGridPlayerRangList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // check if the cell is in the column dataGridPlayerRangListImage
            if (e.ColumnIndex == dataGridPlayerRangList.Columns["dataGridPlayerRangListImage"].Index)
            {
                // get the player from the row
                Player player = (Player)dataGridPlayerRangList.Rows[e.RowIndex].DataBoundItem;

                // set the tool tip text of the cell based on language
                if (AppSettings.Language == "cro")
                {
                    dataGridPlayerRangList.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = $"Kliknite za promijenu slike {player.Name}";
                }
                else if (AppSettings.Language == "eng")
                {
                    dataGridPlayerRangList.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = $"Click to change image of {player.Name}";
                }
            }
        }

        private void rbSort_Click(object sender, EventArgs e)
        {
            // set radio button to checked
            RadioButton rb = (RadioButton)sender;
            rb.Checked = true;
            // display player rang list
            DisplayPlayerRangList();

        }

        private void menuStripFilePrintStats_Click(object sender, EventArgs e)
            => Utilities.PrintoutFavoriteTeamStatistics(playerRangList, favTeamMetch, settingsFavorite);

    }

}