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
    /// Логика взаимодействия для PAdminLogin.xaml
    /// </summary>
    public partial class PAdminLogin : Page
    {
        public PAdminLogin()
        {
            InitializeComponent();
            App.MainWindowInstanse.HeaderGrid.Visibility = Visibility.Visible;
            App.MainWindowInstanse.Title.Text = "Admin Login";
        }
        private void BLogin_Click(object sender, RoutedEventArgs e)
        {
            var admin = App.DB.Admin.FirstOrDefault(a => a.Jobnumber == TBJobnumber.Text);
            if(admin == null)
            {
                MessageBox.Show("Wrong jobnumber");
                return;
            }
            if(admin.Passwords != PBPassword.Password)
            {
                MessageBox.Show("Wrong password");
                return;
            }

            App.loggedAdmin = admin;

            if (App.loggedAdmin.RoleId == "1")
            {
                NavigationService.Navigate(new PEventAdministratorMenu());
            }
            if (App.loggedAdmin.RoleId == "2")
            {
                NavigationService.Navigate(new PTechnicalAdministratorMenu());
            }
        }

        private void BCancel_Click(object sender, RoutedEventArgs e)
        {
            TBJobnumber.Text = "";
            PBPassword.Password = "";
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            App.MainWindowInstanse.HeaderGrid.Visibility = Visibility.Visible;
            App.MainWindowInstanse.Title.Text = "Admin Login";
        }
    }
}
