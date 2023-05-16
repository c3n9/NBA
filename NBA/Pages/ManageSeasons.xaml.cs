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
    /// Логика взаимодействия для ManageSeasons.xaml
    /// </summary>
    public partial class ManageSeasons : Page
    {
        public ManageSeasons()
        {
            InitializeComponent();
            var matchupType = App.DB.MatchupType.ToList();
            matchupType.Insert(0, new MatchupType() { Name = "All" });
            CBMatchupType.ItemsSource = matchupType;
            CBMatchupType.SelectedIndex = 0;
            CBSeason.ItemsSource = App.DB.Season.ToList();
            CBSeason.SelectedIndex = 2;

        }

        private void BSearch_Click(object sender, RoutedEventArgs e)
        {
            if (DGSeasonMatch.SelectedItem ==  null)
            {
                MessageBox.Show("Select season and matcuptype");
                return;
            }
            var selectedSeason = DGSeasonMatch.SelectedItem.GetType().GetProperty("matchup").GetValue(DGSeasonMatch.SelectedItem) as Matchup;
            
            DGMatchups.ItemsSource = App.DB.Matchup.Where(m => m.MatchupTypeId == selectedSeason.MatchupTypeId && m.SeasonId == selectedSeason.SeasonId).ToList();
        }

        private void CBSeason_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void CBMatchupType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            App.MainWindowInstance.TBWelcome.Visibility = Visibility.Collapsed;
            App.MainWindowInstance.TBName.Text = "Manage Seasons";
            App.MainWindowInstance.TBName.VerticalAlignment = VerticalAlignment.Center;
            Refresh();
        }
        private void Refresh()
        {
            var filtred = App.DB.Matchup.ToList();
            if (CBMatchupType.SelectedIndex == 1)
                filtred = filtred.Where(f => f.MatchupTypeId == 0).ToList();
            if (CBMatchupType.SelectedIndex == 2)
                filtred = filtred.Where(f => f.MatchupTypeId == 1).ToList();
            if (CBMatchupType.SelectedIndex == 3)
                filtred = filtred.Where(f => f.MatchupTypeId == 201).ToList();
            if (CBMatchupType.SelectedIndex == 4)
                filtred = filtred.Where(f => f.MatchupTypeId == 202).ToList();
            if (CBMatchupType.SelectedIndex == 5)
                filtred = filtred.Where(f => f.MatchupTypeId == 203).ToList();
            if (CBMatchupType.SelectedIndex == 6)
                filtred = filtred.Where(f => f.MatchupTypeId == 204).ToList();
            if (CBSeason.SelectedIndex == 0)
                filtred = filtred.Where(f => f.SeasonId == 1).ToList();
            if (CBSeason.SelectedIndex == 1)
                filtred = filtred.Where(f => f.SeasonId == 2).ToList();
            if (CBSeason.SelectedIndex == 2)
                filtred = filtred.Where(f => f.SeasonId == 3).ToList();
            var v = filtred.GroupBy(g => new { g.Season, g.MatchupType }); //Группировка по двум элементам
           
            DGSeasonMatch.ItemsSource = v.Select(d => new
            {
                matchup = d.FirstOrDefault(), // берем в matchup первый подходящий элемент
                number = d.Count() // считаем все эти элементы
            });          
        }
    }
}
