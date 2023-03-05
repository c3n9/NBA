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
    /// Логика взаимодействия для PPlayersMain.xaml
    /// </summary>
    public partial class PPlayersMain : Page
    {
        char currentLetter = ' ';
        public PPlayersMain()
        {
            InitializeComponent();
            GenereteCharButtons();
            App.MainWindowInstanse.HeaderGrid.Visibility = Visibility.Visible;
            App.MainWindowInstanse.Title.Text = "Players Main";
        }
        private void GenereteCharButtons()
        {
            List<char> alphabet = new List<char>();
            for (int i=0; i<26; i++)
            {
                alphabet.Add(Convert.ToChar(i+65));
            }
            foreach(char letter in alphabet)
            {
                var button = new Button();
                button.Content= letter;
                button.DataContext= letter;
                button.Background = new SolidColorBrush(Color.FromRgb(105, 149, 194));
                button.FontFamily = new FontFamily("Verdana");
                button.Foreground = new SolidColorBrush(Color.FromRgb(255,255, 255));
                button.BorderThickness = new Thickness(0,0,0,0);
                button.Width = 25;
                button.Click += Letter_CLick;
                BAlphabetButtons.Children.Add(button);
            }
        }
        private void Letter_CLick(object sender, RoutedEventArgs e)
        {
            currentLetter = (char)(sender as Button).DataContext;
            Refresh();
        }
        private void Refresh()
        {
            var filtred = App.DB.PlayerInTeam.ToList();
            if (currentLetter != ' ')
                filtred = filtred.Where(f => f.Player.Name[0] == currentLetter).ToList();
            DGPlayer.ItemsSource = filtred.ToList();
        }

        private void BAll_Click(object sender, RoutedEventArgs e)
        {
            currentLetter = ' ';
            Refresh();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }
    }
}
