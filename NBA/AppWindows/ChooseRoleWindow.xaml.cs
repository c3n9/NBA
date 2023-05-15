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
using System.Windows.Shapes;

namespace NBA_2hour.AppWindows
{
    /// <summary>
    /// Логика взаимодействия для ChooseRoleWindow.xaml
    /// </summary>
    public partial class ChooseRoleWindow : Window
    {
        public ChooseRoleWindow()
        {
            InitializeComponent();
        }

        private void BEvent_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void BTechnical_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
