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
    /// Логика взаимодействия для MainScreen.xaml
    /// </summary>
    public partial class MainScreen : Page
    {
        int currentIndex = 0;
        int takePictures = 3;
        public MainScreen()
        {
            InitializeComponent();
            Refresh();
        }

        private void BVisitor_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new VisitorMain());
        }

        private void BAdmin_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminLogin());
        }
        private void Refresh()
        {
            App.MainWindowInstance.BBack.Visibility = Visibility.Collapsed;
            var images = App.DB.Pictures.ToList().Skip(currentIndex).Take(takePictures).ToList();
            LVImages.ItemsSource = images;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            App.MainWindowInstance.TBWelcome.Visibility = Visibility.Visible;
            App.MainWindowInstance.BLogout.Visibility = Visibility.Collapsed;
            App.MainWindowInstance.TBName.Text = "NBA Managment System";
            Refresh();
        }

        private void BNext_Click(object sender, RoutedEventArgs e)
        {
            currentIndex++;
            if (currentIndex > App.DB.Pictures.Count() - 3)
                currentIndex = 1;
            Refresh();
        }

        private void BPrevious_Click(object sender, RoutedEventArgs e)
        {
            currentIndex--;
            if (currentIndex < 0)
                currentIndex = App.DB.Pictures.Count() - 3;
            Refresh();
        }
    }
}
