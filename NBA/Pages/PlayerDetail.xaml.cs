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
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NBA_2hour.Pages
{
    /// <summary>
    /// Логика взаимодействия для PlayerDetail.xaml
    /// </summary>
    public partial class PlayerDetail : Page
    {
        public PlayerDetail(PlayerInTeam playerInTeam)
        {
            InitializeComponent();
            DataContext = playerInTeam;
            //DGCareer.ItemsSource = App.DB.PlayerStatistics.Where(c => c.PlayerId == playerInTeam.PlayerId && c.TeamId == playerInTeam.TeamId).ToList();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            App.MainWindowInstance.TBWelcome.Visibility = Visibility.Collapsed;
            App.MainWindowInstance.TBName.Text = "Players Detail";
            App.MainWindowInstance.TBName.VerticalAlignment = VerticalAlignment.Center;
            Chart.ChartAreas.Add(new ChartArea("Default"));
            Chart.Series.Add(new Series("Series1"));
            Chart.Series["Series1"].ChartArea = "Default";
            Chart.Series["Series1"].ChartType = SeriesChartType.Line;
            string[] axisXData = new string[] { "a", "b", "c" };
            double[] axisYData = new double[] { 0.1, 1.5, 1.9 };
            Chart.Series["Series1"].Points.DataBindXY(axisXData, axisYData);
        }

        private void BPoints_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BRebounds_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BAssists_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BSteals_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BBlocks_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
