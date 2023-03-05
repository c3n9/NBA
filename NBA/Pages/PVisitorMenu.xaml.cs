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
    /// Логика взаимодействия для PVisitorMenu.xaml
    /// </summary>
    public partial class PVisitorMenu : Page
    {
        public PVisitorMenu()
        {
            InitializeComponent();
            App.MainWindowInstanse.HeaderGrid.Visibility = Visibility.Visible;
            App.MainWindowInstanse.Title.Text = "Visitor menu";
        }
        private void BTeams_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PTeamsMain());
        }

        private void BPlayers_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PPlayersMain());
        }

        private void BMatchups_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PMatchupList());
        }

        private void BPhotos_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PPhotos());
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            App.MainWindowInstanse.HeaderGrid.Visibility = Visibility.Visible;
            App.MainWindowInstanse.Title.Text = "Visitor menu";
        }
    }
}
