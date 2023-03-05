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
    /// Логика взаимодействия для PMatchupList.xaml
    /// </summary>
    public partial class PMatchupList : Page
    {
        public PMatchupList()
        {
            InitializeComponent();
            LVMatchups.ItemsSource = App.DB.Matchup.ToList();
            App.MainWindowInstanse.HeaderGrid.Visibility = Visibility.Visible;
            App.MainWindowInstanse.Title.Text = "Matchup List";
        }


        private void BView_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            App.MainWindowInstanse.HeaderGrid.Visibility = Visibility.Visible;
            App.MainWindowInstanse.Title.Text = "Matchup List";
        }
    }
}
