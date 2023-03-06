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
            DGPlayerInTeam.ItemsSource = contextTeam.PlayerInTeam.Where(t => t.TeamId == team.TeamId && t.SeasonId==3).ToList();
            DGMatchup.ItemsSource = App.DB.Matchup.Where(t => t.Team_Away == team.TeamId).ToList();
          
            LVPLayers.ItemsSource = contextTeam.PlayerInTeam.Where(p => p.Player.PositionId == 1 && p.SeasonId == 3).ToList();
            App.MainWindowInstanse.HeaderGrid.Visibility = Visibility.Visible;
            App.MainWindowInstanse.Title.Text = "Team Detail";
        }
    }
}
