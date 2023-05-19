using NBA_2hour.AppWindows;
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
    /// Логика взаимодействия для ManageMatchup.xaml
    /// </summary>
    public partial class ManageMatchup : Page
    {
        public ManageMatchup()
        {
            InitializeComponent();
            CBSeason.ItemsSource = App.DB.Season.ToList();
            CBSeason.SelectedIndex = 2;
            Refresh();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        private void BUpdate_Click(object sender, RoutedEventArgs e)
        {
            System.Media.SystemSounds.Beep.Play();
            new MessageWindow("Update Matchup").ShowDialog();
        }
        private void Refresh()
        {
            App.MainWindowInstance.TBWelcome.Visibility = Visibility.Collapsed;
            App.MainWindowInstance.TBName.Text = "Manage Matchup";
            App.MainWindowInstance.TBName.VerticalAlignment = VerticalAlignment.Center;
            var filtredPreseason = App.DB.Matchup.Where(m => m.MatchupType.MatchupTypeId == 0).ToList();
            var filtredRegularSeason = App.DB.Matchup.Where(m => m.MatchupType.MatchupTypeId == 1).ToList();
            if (CBSeason.SelectedItem != null)
            {
                filtredPreseason = filtredPreseason.Where(f => f.SeasonId == CBSeason.SelectedIndex + 1).ToList();
                filtredRegularSeason = filtredRegularSeason.Where(f => f.SeasonId == CBSeason.SelectedIndex + 1).ToList();
                if (CBUseDate.IsChecked.Value)
                {
                    if (DPDateMatchup.SelectedDate == null)
                    {
                        MessageBox.Show("Select date or unchecked check box");
                        return;
                    }
                    filtredPreseason = filtredPreseason.Where(f => f.Starttime.Date == DPDateMatchup.SelectedDate.Value.Date).ToList();
                    filtredRegularSeason = filtredRegularSeason.Where(f => f.Starttime.Date == DPDateMatchup.SelectedDate.Value.Date).ToList();
                }
            }
            filtredPreseason = filtredPreseason.OrderBy(x=> x.Starttime.TimeOfDay).ToList();
            filtredRegularSeason = filtredRegularSeason.OrderBy(x => x.Starttime.TimeOfDay).ToList();
            DGMatchupPreseason.ItemsSource = filtredPreseason;
            DGMatchupRegularSeason.ItemsSource = filtredRegularSeason;
        }
        private void BSearch_Click(object sender, RoutedEventArgs e)
        {
            var selectedSeason = CBSeason.SelectedItem;
            if (selectedSeason == null)
            {
                MessageBox.Show("Select season");
                return;
            }
            Refresh();
        }

        private void BExportToExel_Click(object sender, RoutedEventArgs e)
        {
           
            
        }

        

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(TCMatchup.SelectedIndex == 0)
            {
                BExportToExel.Visibility = Visibility.Collapsed;
            }
            else
            {
                BExportToExel.Visibility = Visibility.Visible;
            }
        }

        private void BAddNewMatchup_Click(object sender, RoutedEventArgs e)
        {
            
            NavigationService.Navigate(new AddANewMatchupForregularSeason(TCMatchup.SelectedIndex));
        }
    }
}
