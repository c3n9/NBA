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
    /// Логика взаимодействия для ManagePlayers.xaml
    /// </summary>
    public partial class ManagePlayers : Page
    {
        public ManagePlayers()
        {
            InitializeComponent();
            var countryes = App.DB.Country.ToList();
            countryes.Insert(0, new Country() { CountryName = "View all" });
            CBCountry.ItemsSource = countryes;
            CBCountry.SelectedIndex = 0;
            var positions = App.DB.Position.ToList();
            positions.Insert(0, new Position() { Name = "View all" });
            CBPosition.ItemsSource = positions;
            CBPosition.SelectedIndex = 0;


        }
        private void Refresh()
        {
            App.MainWindowInstance.TBWelcome.Visibility = Visibility.Collapsed;
            App.MainWindowInstance.TBName.Text = "Manage Players";
            App.MainWindowInstance.TBName.VerticalAlignment = VerticalAlignment.Center;
            var filtred = App.DB.Player.ToList();
            var selectedPosition = CBPosition.SelectedItem as Position;
            var selectedCounry = CBCountry.SelectedItem as Country;
            var surchText = TBSurch.Text.ToLower();
            if (selectedPosition != null && CBPosition.SelectedIndex != 0)
                filtred = filtred.Where(f => f.PositionId == selectedPosition.PositionId).ToList();
            if (selectedCounry != null && CBCountry.SelectedIndex != 0)
                filtred = filtred.Where(f=> f.CountryCode == selectedCounry.CountryCode).ToList();
            if (!String.IsNullOrWhiteSpace(surchText))
                filtred = filtred.Where(f => f.Name.ToLower().Contains(surchText)).ToList();
            DGPlayers.ItemsSource = filtred;
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        private void TBSurch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }

        private void CBPosition_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void CBCountry_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }
    }
}
