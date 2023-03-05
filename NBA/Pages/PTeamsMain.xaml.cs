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
    /// Логика взаимодействия для PTeamsMain.xaml
    /// </summary>
    public partial class PTeamsMain : Page
    {
        public PTeamsMain()
        {
            InitializeComponent();
            LVAtlanticTeams.ItemsSource = App.DB.Team.Where(t => t.DivisionId == 3).ToList();
            LVCentralTeams.ItemsSource = App.DB.Team.Where(t => t.DivisionId == 2).ToList();
            LVSoutheastTeams.ItemsSource = App.DB.Team.Where(t => t.DivisionId == 1).ToList();
            LVNorthwesternTeams.ItemsSource = App.DB.Team.Where(t => t.DivisionId == 5).ToList();
            LVPacificTeams.ItemsSource = App.DB.Team.Where(t => t.DivisionId == 6).ToList();
            LVSouthwesternTeams.ItemsSource = App.DB.Team.Where(t => t.DivisionId == 4).ToList();
            App.MainWindowInstanse.HeaderGrid.Visibility = Visibility.Visible;
            App.MainWindowInstanse.Title.Text = "Teams Main";
        }
        private void Roster_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = 0;
            TeamDetailNavigate(sender,selectedIndex);
        }
        private void Matchup_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = 1;
            TeamDetailNavigate(sender,selectedIndex);
        }
        private void FirstLineup_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = 2;
            TeamDetailNavigate(sender,selectedIndex);
        }
        private void TeamDetailNavigate(object sender, int index)
        {
            var selectedTeam = (sender as Hyperlink).DataContext as Team;
            if (selectedTeam == null)
            {
                MessageBox.Show("Select team");
                return;
            }
            NavigationService.Navigate(new PTeamDetail(selectedTeam, index));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            App.MainWindowInstanse.HeaderGrid.Visibility = Visibility.Visible;
            App.MainWindowInstanse.Title.Text = "Teams Main";
        }
    }
}
