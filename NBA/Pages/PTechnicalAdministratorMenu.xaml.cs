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
    /// Логика взаимодействия для PTechnicalAdministratorMenu.xaml
    /// </summary>
    public partial class PTechnicalAdministratorMenu : Page
    {
        public PTechnicalAdministratorMenu()
        {
            InitializeComponent();
            App.MainWindowInstanse.HeaderGrid.Visibility = Visibility.Visible;
            App.MainWindowInstanse.Title.Text = "Technical Administration";
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            App.MainWindowInstanse.HeaderGrid.Visibility = Visibility.Visible;
            App.MainWindowInstanse.Title.Text = "Technical Administration";
        }
    }
}
