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
    /// Логика взаимодействия для MessageWindow.xaml
    /// </summary>
    public partial class MessageWindow : Window
    {
        public MessageWindow(String name)
        {
            InitializeComponent();
            TBMessageName.Text = $"{name} - Future Add-on";
        }

        private void BAgree_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
