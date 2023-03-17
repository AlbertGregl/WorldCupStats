using DataRepository.Dal;
using DataRepository.Models;
using System.ComponentModel;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DesktopWinForms
{
    public partial class MainForm : Form
    {
        private DataManager dataManager;
        private ISet<Results> results;
        private ISet<Matches> matches;
        private readonly ISettingsRepository settingsRepo;
        public Settings AppSettings { get; set; }
        private SettingsFavorite settingsFavorite;
        private ISet<Player> playerSet;
        private ISet<Player> favPlayerSet;


        public MainForm()
        {
            InitializeComponent();

            // prepare settings object
            AppSettings = new Settings();

            // initialize the Data
            dataManager = new DataManager();
            results = new HashSet<Results>();
            matches = new HashSet<Matches>();
            playerSet = new HashSet<Player>();
            favPlayerSet = new HashSet<Player>();

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

            try
            {
                // load results based on settings
                results = dataManager.GetResultsByChampionship(AppSettings.Championship);
                matches = dataManager.GetMatchesByChampionship(AppSettings.Championship);
            }
            catch (Exception ex)
            {
                //alert user
                MessageBox.Show(ex.Message, "Oops :(");
            }

            // sort the resluts by GroupId
            HashSet<Results> sortedResults = results.OrderBy(x => x.GroupId).ToHashSet();

            // display Country and FifaCode in comboBox
            foreach (var item in sortedResults)
            {
                menuStripFavTeamComboBox.Items.Add($"{item.Country} ({item.FifaCode})");
            }
            // sort menuStripFavTeamComboBox
            menuStripFavTeamComboBox.Sorted = true;

            // display players from selected favorite team in dataGridAllPlayers
            DisplayPlayersFromFavoriteTeam();

            // display favorite players in dataGridFavPlayers
            DisplayFavoritePlayers();
        }

        private void DisplayFavoritePlayers()
        {
            // get players from favorite team and add them to playerSet
            foreach (Matches match in matches)
            {
                if (match.HomeTeamCountry == settingsFavorite.FavoriteTeam)
                {
                    match.HomeTeamStatistics.StartingEleven.ForEach(x => playerSet.Add(x));
                    match.HomeTeamStatistics.Substitutes.ForEach(x => playerSet.Add(x));
                }
            }

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
            dataGridFavPlayers.Refresh();

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
            playerSet.Clear();
            // get players from favorite team and add them to playerSet
            foreach (Matches match in matches)
            {
                if (match.HomeTeamCountry == settingsFavorite.FavoriteTeam)
                {
                    match.HomeTeamStatistics.StartingEleven.ForEach(x => playerSet.Add(x));
                    match.HomeTeamStatistics.Substitutes.ForEach(x => playerSet.Add(x));
                }
            }

            // sort players by shirt number
            playerSet = playerSet.OrderBy(x => x.ShirtNumber).ToHashSet();

            // display players in dataGridAllPlayers
            dataGridAllPlayers.DataSource = playerSet.ToList();
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
        {
            e.Effect = DragDropEffects.Move;
        }

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

            // display players from selected favorite team in dataGridAllPlayers
            DisplayPlayersFromFavoriteTeam();

            RemoveFavPlayersFromPanel();
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

            CustomizeFavoriteColumnAppearance(dataGridFavPlayers);

            // display players
            dataGridFavPlayers.DataSource = favPlayerSet.ToList();
            dataGridAllPlayers.DataSource = playerSet.ToList();

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

    }
}