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
    /// Логика взаимодействия для VisitorMain.xaml
    /// </summary>
    public partial class VisitorMain : Page
    {
        public VisitorMain()
        {
            InitializeComponent();
            Refresh();
        }

        private void BTeams_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TeamsMain());
        }
        private void Refresh()
        {
            App.MainWindowInstance.BBack.Visibility = Visibility.Visible;
        }

        private void BPlayers_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PlayersMain());
        }

        private void BMatchups_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MatchupList());
        }

        private void BPhotos_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Photos());
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            App.MainWindowInstance.TBWelcome.Visibility = Visibility.Collapsed;
            App.MainWindowInstance.TBName.Text = "Visitor Main";
            App.MainWindowInstance.TBName.VerticalAlignment = VerticalAlignment.Center;
            Refresh();
        }
    }
}
