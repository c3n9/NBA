using NBA.Models;
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

namespace NBA.Pages
{
    /// <summary>
    /// Логика взаимодействия для PTeamDetail.xaml
    /// </summary>
    public partial class PTeamDetail : Page
    {
        Team contextTeam;
        public PTeamDetail(Team team, int selectIndex)
        {
            InitializeComponent();
            contextTeam = team;
            DataContext = contextTeam;
            TCTeam.SelectedIndex = selectIndex;
            DGPlayerInTeam.ItemsSource = App.DB.PlayerInTeam.Where(t => t.TeamId == team.TeamId).ToList();
            DGMatchup.ItemsSource = App.DB.Matchup.Where(t => t.Team_Away == team.TeamId).ToList();
            List <Player> players = new List<Player>();
            players = App.DB.Player.Where(p => p.PositionId == 3).ToList();
            LVPLayers.ItemsSource = players;
            App.MainWindowInstanse.HeaderGrid.Visibility = Visibility.Visible;
            App.MainWindowInstanse.Title.Text = "Team Detail";
        }
    }
}
