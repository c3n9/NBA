using NBA_2hour.AppWindows;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Логика взаимодействия для AdminLogin.xaml
    /// </summary>
    public partial class AdminLogin : Page
    {
        public AdminLogin()
        {
            InitializeComponent();
            App.MainWindowInstance.BBack.Visibility = Visibility.Visible;
        }

        private void BLogin_Click(object sender, RoutedEventArgs e)
        {
            var user = App.DB.Admin.FirstOrDefault(x => x.Jobnumber == TBJobnumber.Text);
            if(user == null)
            {
                MessageBox.Show("The user does not exist");
                return;
            }
            if(user.Passwords != TBPassword.Password)
            {
                MessageBox.Show("Wrong password");
                return;
            }
            App.loggedAdmin = user;
            if (App.loggedAdmin.Role.RoleId == 1.ToString())
            {
                NavigationService.Navigate(new EventAdministratorMenu());
            }
            if(App.loggedAdmin.Role.RoleId == 2.ToString())
            {
                NavigationService.Navigate(new TechnicalAdministratorMenu());
            }
        }

        private void BCancel_Click(object sender, RoutedEventArgs e)
        {
            TBJobnumber.Text = String.Empty;
            TBPassword.Password = String.Empty;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            App.MainWindowInstance.TBWelcome.Visibility = Visibility.Collapsed;
            App.MainWindowInstance.TBName.Text = "Admin Login";
            App.MainWindowInstance.TBName.VerticalAlignment = VerticalAlignment.Center;
            App.MainWindowInstance.BLogout.Visibility = Visibility.Collapsed;
        }
    }
}
