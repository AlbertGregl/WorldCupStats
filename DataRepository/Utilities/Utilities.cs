using DataRepository.Models;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository.Utilities
{
    public class Utilities
    {

        public static void PrintoutFavoriteTeamStatistics(ISet<Player> playerRangList, ISet<Matches> favTeamMetch, SettingsFavorite settingsFavorite)
        {
            // Display the print dialog and get the selected printer
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            PrinterSettings printerSettings = printDialog.PrinterSettings;

            // Create a PrintDocument object and set its properties
            PrintDocument printDocument = new PrintDocument();
            printDocument.DefaultPageSettings.Landscape = true;
            printDocument.PrinterSettings = printerSettings;

            // Handle the PrintPage event and draw the table onto the page
            printDocument.PrintPage += (s, pe) =>
            {
                // Set the font and margin sizes
                Font font = new Font("Consolas", 10);
                Font fontBold = new Font("Consolas", 10, FontStyle.Bold);
                Font heading = new Font("Consolas", 12, FontStyle.Bold);
                Font title = new Font("Consolas", 14, FontStyle.Bold);
                int margin = 40;
                int tableWidth = pe.PageBounds.Width - (margin * 2);

                // Define the columns for Player Rang List and their widths
                string[] columnsPlayer = { "Name", "Games Played", "Goals", "Yellow Cards" };
                float[] columnWidths = { 0.4f, 0.2f, 0.2f, 0.2f };

                float y = margin;

                // Calculate the row height based on the font size
                float rowHeight = font.GetHeight() * 1.5f;

                // Draw Title
                pe.Graphics.DrawString($"World Cap Statistics for {settingsFavorite.FavoriteTeam}", title, Brushes.Black, margin * 6, y);
                y += rowHeight * 2;

                // Draw heading for Player Rang List
                pe.Graphics.DrawString("Player Rang List", heading, Brushes.Black, margin, y);
                y += rowHeight;

                // Draw the header row for Player Rang List
                for (int i = 0; i < columnsPlayer.Length; i++)
                {
                    float x = margin + (tableWidth * columnWidths.Take(i).Sum());
                    pe.Graphics.DrawString(columnsPlayer[i], fontBold, Brushes.Black, x, y);
                }
                y += rowHeight;

                // Draw the table data for Player Rang List
                foreach (Player player in playerRangList)
                {
                    float x = margin;
                    pe.Graphics.DrawString(player.Name, font, Brushes.Black, x, y);
                    x += tableWidth * columnWidths[0];
                    pe.Graphics.DrawString(player.GamesPlayed.ToString(), font, Brushes.Black, x, y);
                    x += tableWidth * columnWidths[1];
                    pe.Graphics.DrawString(player.Goals.ToString(), font, Brushes.Black, x, y);
                    x += tableWidth * columnWidths[2];
                    pe.Graphics.DrawString(player.YellowCards.ToString(), font, Brushes.Black, x, y);
                    y += rowHeight;
                }
                y += rowHeight;

                // Draw heading for Player Rang List
                pe.Graphics.DrawString("Matches Rang List", heading, Brushes.Black, margin, y);
                y += rowHeight;

                // Define the columns for Matches Rang List
                string[] columnsMatches = { "Location", "Attendance", "Home Team", "Away Team" };


                // Draw the header row for Matches Rang List
                for (int i = 0; i < columnsMatches.Length; i++)
                {
                    float x = margin + (tableWidth * columnWidths.Take(i).Sum());
                    pe.Graphics.DrawString(columnsMatches[i], fontBold, Brushes.Black, x, y);
                }
                y += rowHeight;

                // Draw the table data Matches Rang List
                foreach (Matches match in favTeamMetch)
                {
                    float x = margin;
                    pe.Graphics.DrawString(match.Location, font, Brushes.Black, x, y);
                    x += tableWidth * columnWidths[0];
                    pe.Graphics.DrawString(match.Attendance.ToString(), font, Brushes.Black, x, y);
                    x += tableWidth * columnWidths[1];
                    pe.Graphics.DrawString(match.HomeTeamCountry, font, Brushes.Black, x, y);
                    x += tableWidth * columnWidths[2];
                    pe.Graphics.DrawString(match.AwayTeamCountry, font, Brushes.Black, x, y);
                    y += rowHeight;
                }

            };

            // Print the document
            printDocument.Print();
        }


    }
}
