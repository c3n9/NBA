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
    /// Логика взаимодействия для TeamsMain.xaml
    /// </summary>
    public partial class TeamsMain : Page
    {
        public TeamsMain()
        {
            InitializeComponent();
            Refresh();
        }

        private void Refresh()
        {
            App.MainWindowInstance.BBack.Visibility = Visibility.Visible;

            LVNorthwest.ItemsSource = App.DB.Team.Where(x => x.DivisionId == 5).ToList();
            LVPacific.ItemsSource = App.DB.Team.Where(x => x.DivisionId == 6).ToList();
            LVSouthwest.ItemsSource = App.DB.Team.Where(x => x.DivisionId == 4).ToList();
            LVAtlantic.ItemsSource = App.DB.Team.Where(x => x.DivisionId == 3).ToList();
            LVCentral.ItemsSource = App.DB.Team.Where(x => x.DivisionId == 2).ToList();
            LVSoutheast.ItemsSource = App.DB.Team.Where(x => x.DivisionId == 1).ToList();
        }
        private void HLRoster_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = 0;
            TeamDeailNavigate(sender, selectedIndex);
        }

        private void HLMatchup_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = 1;
            TeamDeailNavigate(sender, selectedIndex);
        }

        private void HLFirstLineup_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = 2;
            TeamDeailNavigate(sender, selectedIndex);
        }

        private void TeamDeailNavigate(object sender, int index)
        {
            var selectedTeam = (sender as Hyperlink).DataContext as Team;
            if (selectedTeam == null)
            {
                MessageBox.Show("Select team");
                return;
            }
            NavigationService.Navigate(new TeamDetail(selectedTeam, index));
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            App.MainWindowInstance.TBWelcome.Visibility = Visibility.Collapsed;
            App.MainWindowInstance.TBName.Text = "Teams Main";
            App.MainWindowInstance.TBName.VerticalAlignment = VerticalAlignment.Center;
        }
    }
}
