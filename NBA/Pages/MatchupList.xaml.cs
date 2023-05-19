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
    /// Логика взаимодействия для MatchupList.xaml
    /// </summary>
    public partial class MatchupList : Page
    {
        public MatchupList()
        {
            InitializeComponent();
            LVMatchup.ItemsSource = App.DB.Matchup.ToList();
        }

        private void BView_Click(object sender, RoutedEventArgs e)
        {
            System.Media.SystemSounds.Beep.Play();
            new MessageWindow("Matchup Detail").ShowDialog();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            App.MainWindowInstance.TBWelcome.Visibility = Visibility.Collapsed;
            App.MainWindowInstance.TBName.Text = "Matchups List";
            App.MainWindowInstance.TBName.VerticalAlignment = VerticalAlignment.Center;
        }
    }
}
