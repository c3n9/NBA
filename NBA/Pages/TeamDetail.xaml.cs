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
    /// Логика взаимодействия для TeamDetail.xaml
    /// </summary>
    public partial class TeamDetail : Page
    {
        Team contextTeam;
        public TeamDetail(Team team, int selectedIndex)
        {
            InitializeComponent();
            TCTeamDetail.SelectedIndex = selectedIndex;
            contextTeam = team;
            DataContext = contextTeam;
            CBSeason.ItemsSource = App.DB.Season.ToList();
            CBSeason.SelectedIndex = 2;
            Refresh(3);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            App.MainWindowInstance.TBWelcome.Visibility = Visibility.Collapsed;
            App.MainWindowInstance.TBName.Text = "Team Detail";
            App.MainWindowInstance.TBName.VerticalAlignment = VerticalAlignment.Center;
        }
        private void Refresh(int seasonId)
        {
            DGPlayers.ItemsSource = contextTeam.PlayerInTeam.Where(x => x.SeasonId == seasonId).ToList();
            DGMatchup.ItemsSource = contextTeam.Matchup.Where(x => x.SeasonId == seasonId).ToList();
            LVPLayersSF.ItemsSource = contextTeam.PlayerInTeam.Where(p => p.Player.PositionId == 1 && p.SeasonId == seasonId).ToList();
            LVPLayersPF.ItemsSource = contextTeam.PlayerInTeam.Where(p => p.Player.PositionId == 2 && p.SeasonId == seasonId).ToList();
            LVPLayersC.ItemsSource = contextTeam.PlayerInTeam.Where(p => p.Player.PositionId == 3 && p.SeasonId == seasonId).ToList();
            LVPLayersSG.ItemsSource = contextTeam.PlayerInTeam.Where(p => p.Player.PositionId == 4 && p.SeasonId == seasonId).ToList();
            LVPLayersPG.ItemsSource = contextTeam.PlayerInTeam.Where(p => p.Player.PositionId == 5 && p.SeasonId == seasonId).ToList();
        }
        private void BSearch_Click(object sender, RoutedEventArgs e)
        {
            var season = CBSeason.SelectedItem as Season;
            Refresh(season.SeasonId);
        }
    }
}
