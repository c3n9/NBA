using NBA_2hour.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NBA_2hour.Pages
{
    /// <summary>
    /// Логика взаимодействия для PlayersMain.xaml
    /// </summary>
    public partial class PlayersMain : Page
    {
        int pagesCount;
        int playersOnPage = 10;
        int currentPage = 0;
        public PlayersMain()
        {
            InitializeComponent();
            var team = App.DB.Team.ToList();
            team.Insert(0, new Team() { TeamName = "View all" });
            CBTeam.ItemsSource = team.ToList();
            CBTeam.SelectedIndex = 0;
            var season = App.DB.Season.ToList();
            CBSeason.ItemsSource = season.ToList();
            CBSeason.SelectedIndex = 2;
            Refresh();
        }

        private void CBSeason_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void CBTeam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void TBSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }
        private void Refresh()
        {
            var filter = App.DB.PlayerInTeam.ToList();
            var selectedTeam = CBTeam.SelectedItem as Team;
            var textSearch = TBSearch.Text.ToLower();
            if (selectedTeam.TeamId != 0)
                filter = filter.Where(f => f.TeamId == selectedTeam.TeamId).ToList();
            if (!String.IsNullOrWhiteSpace(textSearch))
                filter = filter.Where(f => f.Player.Name.ToLower().Contains(textSearch)).ToList();
            if (CBSeason.SelectedIndex == 1)
                filter = filter.Where(f => f.SeasonId == 1).ToList();
            if (CBSeason.SelectedIndex == 2)
                filter = filter.Where(f => f.SeasonId == 2).ToList();
            if (CBSeason.SelectedIndex == 3)
                filter = filter.Where(f => f.SeasonId == 3).ToList();

            filter.Add(new PlayerInTeam());

            pagesCount = filter.Count / playersOnPage;
            if (filter.Count % playersOnPage != 0)
                pagesCount++;

            TBTotalRecord.Text = $"{filter.Count}, {playersOnPage} in one page";

            DGPlayers.ItemsSource = filter.Skip(playersOnPage * currentPage).Take(playersOnPage);
        }

        private void BFirstPage_Click(object sender, RoutedEventArgs e)
        {
            currentPage = 0;
            Refresh();
        }

        private void BPreviousPage_Click(object sender, RoutedEventArgs e)
        {
            currentPage--;
            if (currentPage < 0)
                currentPage = 0;
            Refresh();
        }

        private void BNextPage_Click(object sender, RoutedEventArgs e)
        {
            currentPage++;
            if (currentPage == pagesCount)
                currentPage--;
            Refresh();
        }

        private void BLastPage_Click(object sender, RoutedEventArgs e)
        {
            currentPage = pagesCount-1;
            Refresh();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            App.MainWindowInstance.TBWelcome.Visibility = Visibility.Collapsed;
            App.MainWindowInstance.TBName.Text = "Players Main";
            App.MainWindowInstance.TBName.VerticalAlignment = VerticalAlignment.Center;
        }
    }
}
