using NBA_2hour.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для PlayersMain.xaml
    /// </summary>
    public partial class PlayersMain : Page
    {
        int pagesCount;
        char currentLetter = ' ';
        int playersOnPage = 10;
        int currentPage = 0;
        public PlayersMain()
        {
            InitializeComponent();
            GenerateButtons();
            var team = App.DB.Team.ToList();
            team.Insert(0, new Team() { TeamName = "View all" });
            CBTeam.ItemsSource = team.ToList();
            CBTeam.SelectedIndex = 0;
            var season = App.DB.Season.ToList();
            CBSeason.ItemsSource = season.ToList();
            CBSeason.SelectedIndex = 2;
            Refresh();
        }
        private void GenerateButtons()
        {
            List<char> alphabet = new List<char>();
            for (int i = 0; i < 26; i++)
            {
                alphabet.Add(Convert.ToChar(i + 65));
            }
            foreach (char letter in alphabet)
            {
                var button = new Button();
                button.Content = letter;
                button.DataContext = letter;
                button.Background = new SolidColorBrush(Color.FromRgb(105, 149, 194));
                button.FontFamily = new FontFamily("Verdana");
                button.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                button.BorderThickness = new Thickness(0, 0, 0, 0);
                button.FontWeight = FontWeights.Bold;
                button.Width = 25;
                button.Margin = new Thickness(10, 0, 0, 0);
                button.FontSize = 20;
                button.Click += Letter_CLick;
                BAlphabetButtons.Children.Add(button);
            }
        }
        private void Letter_CLick(object sender, RoutedEventArgs e)
        {
            currentLetter = (char)(sender as Button).DataContext;
            Refresh();
        }
        private void CBSeason_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void CBTeam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void TBSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }
        private void Refresh()
        {
            var filtred = App.DB.PlayerInTeam.ToList();
            var selectedTeam = CBTeam.SelectedItem as Team;
            var textSearch = TBSearch.Text.ToLower();
            if (CBTeam.SelectedIndex != 0 && selectedTeam != null)
                filtred = filtred.Where(f => f.TeamId == selectedTeam.TeamId).ToList();
            if (!String.IsNullOrWhiteSpace(textSearch))
                filtred = filtred.Where(f => f.Player.Name.ToLower().Contains(textSearch)).ToList();
            if (CBSeason.SelectedIndex == 1)
                filtred = filtred.Where(f => f.SeasonId == 1).ToList();
            if (CBSeason.SelectedIndex == 2)
                filtred = filtred.Where(f => f.SeasonId == 2).ToList();
            if (CBSeason.SelectedIndex == 3)
                filtred = filtred.Where(f => f.SeasonId == 3).ToList();
            if (currentLetter != ' ')
                filtred = filtred.Where(f => f.Player.Name[0] == currentLetter).ToList();
            pagesCount = filtred.Count / playersOnPage;
            if (filtred.Count % playersOnPage != 0)
                pagesCount++;
            TBTotalRecord.Text = $"Total {filtred.Count} records, {playersOnPage} records in one page";
            TBPage.Text = currentPage.ToString();
            DGPlayers.ItemsSource = filtred.Skip(playersOnPage * currentPage).Take(playersOnPage);
            TBPagingText.Text = $"of {pagesCount - 1}";
        }

        private void BFirstPage_Click(object sender, RoutedEventArgs e)
        {
            currentPage = 0;
            Refresh();
        }

        private void BPreviousPage_Click(object sender, RoutedEventArgs e)
        {
            currentPage--;
            if (currentPage < 0)
                currentPage = 0;
            Refresh();
        }

        private void BNextPage_Click(object sender, RoutedEventArgs e)
        {
            currentPage++;
            if (currentPage == pagesCount)
                currentPage--;
            Refresh();
        }

        private void BLastPage_Click(object sender, RoutedEventArgs e)
        {
            currentPage = pagesCount - 1;
            Refresh();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            App.MainWindowInstance.TBWelcome.Visibility = Visibility.Collapsed;
            App.MainWindowInstance.TBName.Text = "Players Main";
            App.MainWindowInstance.TBName.VerticalAlignment = VerticalAlignment.Center;
        }

        private void BAll_Click(object sender, RoutedEventArgs e)
        {
            currentLetter = ' ';
            Refresh();
        }

        private void TBPage_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TBPage.Text == string.Empty)
                return;
            if (int.Parse(TBPage.Text) > pagesCount)
                return;
            currentPage = int.Parse(TBPage.Text);
            Refresh();
        }

        private void TBPage_TextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[0-9]");
            if (!regex.IsMatch(e.Text))
            {
                e.Handled = true;
            }
        }

        private void DGPlayers_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedPlayer = DGPlayers.SelectedItem as PlayerInTeam;
            if(selectedPlayer == null)
            {
                MessageBox.Show("Select player");
                return;
            }
            NavigationService.Navigate(new PlayerDetail(selectedPlayer));
        }
    }
}
