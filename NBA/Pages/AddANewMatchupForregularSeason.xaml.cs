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
    /// Логика взаимодействия для AddANewMatchupForregularSeason.xaml
    /// </summary>
    public partial class AddANewMatchupForregularSeason : Page
    {
        int currentIndex;
        public AddANewMatchupForregularSeason(int index)
        {
            InitializeComponent();
            App.MainWindowInstance.TBWelcome.Visibility = Visibility.Collapsed;
            App.MainWindowInstance.TBName.VerticalAlignment = VerticalAlignment.Center;
            currentIndex = index;
            CBTeamAway.ItemsSource = App.DB.Team.ToList();
            CBTeamHome.ItemsSource = App.DB.Team.ToList();
            if (currentIndex == 0)
            {
                TBMatchupType.Text = "Matchup Type: Preseason";
                App.MainWindowInstance.TBName.Text = "Add a new matchup for Preseason";
            }
            if (currentIndex == 1)
            {
                TBMatchupType.Text = "Matchup Type: Regular Season";
                App.MainWindowInstance.TBName.Text = "Add a new matchup for Regular Season";
            }
        }

        private void BSubmit_Click(object sender, RoutedEventArgs e)
        {
            var teamAway = CBTeamAway.SelectedItem as Team;
            var teamHome = CBTeamHome.SelectedItem as Team;
            string error = "";
            if (String.IsNullOrWhiteSpace(TBTime.Text))
                error += "Enter staart time\n";
            if (DPDate.SelectedDate == null)
                error += "Select date\n";
            if (String.IsNullOrWhiteSpace(TBLocation.Text))
                error += "Enter matchup location\n";
            if (teamAway == null)
                error += "Select Team Away\n";
            if (teamHome == null)
                error += "Select Team Home\n";
            if (!String.IsNullOrWhiteSpace(error))
            {
                MessageBox.Show(error);
                return;
            }
            var newMatchup = new Matchup() { SeasonId = 3, MatchupTypeId = currentIndex, Team = teamAway, Team1 = teamHome, Starttime = DPDate.SelectedDate.Value+DateTime.Parse(TBTime.Text).TimeOfDay, Team_Away_Score = 0, Team_Home_Score = 0, Location = TBLocation.Text, Status=-1};
            App.DB.Matchup.Add(newMatchup);
            App.DB.SaveChanges();
            NavigationService.GoBack();
        }
    }
}
