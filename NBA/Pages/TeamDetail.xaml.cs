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
        public TeamDetail(Team team)
        {
            InitializeComponent();
            contextTeam = team;
            DataContext = contextTeam;
            DGPlayers.ItemsSource= App.DB.PlayerInTeam.Where(x=> x.TeamId == team.TeamId).ToList();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            App.MainWindowInstance.TBWelcome.Visibility = Visibility.Collapsed;
            App.MainWindowInstance.TBName.Text = "Team Detail";
            App.MainWindowInstance.TBName.VerticalAlignment = VerticalAlignment.Center;
        }
    }
}
