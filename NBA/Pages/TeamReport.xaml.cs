using NBA_2hour.Models;
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
    /// Логика взаимодействия для TeamReport.xaml
    /// </summary>
    public partial class TeamReport : Page
    {
        public TeamReport()
        {
            InitializeComponent();
            CBRank.SelectedIndex = 0;
            App.MainWindowInstance.BLogout.Visibility = Visibility.Visible;
            Refresh();
        }

        private void DGTeamReport_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex()+1).ToString();
        }
        private void Refresh()
        {
            var filtred = App.DB.PlayerStatistics.ToList();
            if (CBRank.SelectedIndex == 0 && CBRank.SelectedItem != null)
                filtred = filtred.OrderBy(f=> f.Point).ToList();
            if (CBRank.SelectedIndex == 1 && CBRank.SelectedItem != null)
                filtred = filtred.OrderBy(f => f.Rebound).ToList();
            if (CBRank.SelectedIndex == 2 && CBRank.SelectedItem != null)
                filtred = filtred.OrderBy(f => f.Assist).ToList();
            if (CBRank.SelectedIndex == 3 && CBRank.SelectedItem != null)
                filtred = filtred.OrderBy(f => f.Steal).ToList();
            if (CBRank.SelectedIndex == 4 && CBRank.SelectedItem != null)
                filtred = filtred.OrderBy(f => f.Block).ToList();
            DGTeamReport.ItemsSource = filtred;
            
        }
        private void BSearch_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
        }
    }
}
