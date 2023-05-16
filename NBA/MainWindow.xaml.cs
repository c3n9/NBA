using NBA_2hour.Pages;
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

namespace NBA_2hour
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            App.MainWindowInstance = this;
            MainFrame.Navigate(new MainScreen());
        }

        private void BBack_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.GoBack();
        }

        private void BLogout_Click(object sender, RoutedEventArgs e)
        {
            if (App.loggedAdmin == null)
            {
                return;
            }
            App.loggedAdmin = null;
            do
            {
                MainFrame.GoBack();
            }
            while (MainFrame.CanGoBack);
        }
    }
}
