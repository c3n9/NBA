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
    /// Логика взаимодействия для EventAdministratorMenu.xaml
    /// </summary>
    public partial class EventAdministratorMenu : Page
    {
        public EventAdministratorMenu()
        {
            InitializeComponent();
            App.MainWindowInstance.BBack.Visibility = Visibility.Visible;
            App.MainWindowInstance.BLogout.Visibility = Visibility.Visible;
        }

        private void BManageSeasons_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ManageSeasons());
        }

        private void BManageTeams_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ManageTeams());
        }

        private void BManageMatchups_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ManageMatchup());
        }

        private void BManagePlayers_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ManagePlayers());
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            App.MainWindowInstance.TBWelcome.Visibility = Visibility.Collapsed;
            App.MainWindowInstance.TBName.Text = "Event Administrator Menu";
            App.MainWindowInstance.TBName.VerticalAlignment = VerticalAlignment.Center;
        }
    }
}
