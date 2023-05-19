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
        PlayerInTeam contextPlayerInTeam;
        public PlayerDetail(PlayerInTeam playerInTeam)
        {
            InitializeComponent();
            var areaPoints = ChartPoints.ChartAreas.Add("PointsArea");
            var areaRebounds = ChartRebounds.ChartAreas.Add("ReboundsArea");
            var areaAssists = ChartAssists.ChartAreas.Add("AssistsArea");
            var areaSteals = ChartSteals.ChartAreas.Add("StealsArea");
            var areaBlocks = ChartBlocks.ChartAreas.Add("BlocksArea");

            contextPlayerInTeam = playerInTeam;

            DataContext = playerInTeam;
            TBPPGinSeason.Text = playerInTeam.Player.PlayerStatistics.Where(s => s.Matchup.SeasonId == 3).Sum(s => s.Point).ToString();
            TBAPGinSeason.Text = playerInTeam.Player.PlayerStatistics.Where(s => s.Matchup.SeasonId == 3).Sum(s => s.Assist).ToString();
            TBRPGinSeason.Text = playerInTeam.Player.PlayerStatistics.Where(s => s.Matchup.SeasonId == 3).Sum(s => s.Rebound).ToString();
            TBPPGinCareer.Text = playerInTeam.Player.PlayerStatistics.Sum(s => s.Point).ToString();
            TBAPGinCareer.Text = playerInTeam.Player.PlayerStatistics.Sum(s => s.Assist).ToString();
            TBRPGinCareer.Text = playerInTeam.Player.PlayerStatistics.Sum(s => s.Rebound).ToString();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            App.MainWindowInstance.TBWelcome.Visibility = Visibility.Collapsed;
            App.MainWindowInstance.TBName.Text = "Players Detail";
            App.MainWindowInstance.TBName.VerticalAlignment = VerticalAlignment.Center;
            
        }
        
        private void Refresh()
        {
            ChartRebounds.Series.Clear();
            ChartPoints.Series.Clear();
            ChartAssists.Series.Clear();
            ChartSteals.Series.Clear();
            ChartBlocks.Series.Clear();
            var startDate = DPStartDate.SelectedDate;
            var endDate = DPEndDate.SelectedDate;

            var stats = contextPlayerInTeam.Player.PlayerStatistics.Where(p => p.Matchup.Starttime.Date >= startDate.Value.Date && p.Matchup.Starttime.Date <= endDate.Value.Date).OrderBy(o => o.Matchup.Starttime);

            var seriaPoint = ChartPoints.Series.Add("pointsLine");
            seriaPoint.ChartType = SeriesChartType.Line;
            seriaPoint.BorderWidth = 5;
            var chartDataPoint = stats.GroupBy(x => x.Matchup.Starttime.Date).ToDictionary(Key => Key.Key, Value => Value.Sum(v => v.Point));
            seriaPoint.Points.DataBindXY(chartDataPoint.Keys, chartDataPoint.Values);

            var seriaRebound = ChartRebounds.Series.Add("reboundsLine");
            seriaRebound.ChartType = SeriesChartType.Line;
            seriaRebound.BorderWidth = 5;
            var chartDataRebound = stats.GroupBy(x => x.Matchup.Starttime.Date).ToDictionary(Key => Key.Key, Value => Value.Sum(v => v.Rebound));
            seriaRebound.Points.DataBindXY(chartDataRebound.Keys, chartDataRebound.Values);

            var seriaAssist = ChartAssists.Series.Add("assistsLine");
            seriaAssist.ChartType = SeriesChartType.Line;
            seriaAssist.BorderWidth = 5;
            var chartDataAssist = stats.GroupBy(x => x.Matchup.Starttime.Date).ToDictionary(Key => Key.Key, Value => Value.Sum(v => v.Assist));
            seriaAssist.Points.DataBindXY(chartDataAssist.Keys, chartDataAssist.Values);

            var seriaSteals = ChartSteals.Series.Add("stealsLine");
            seriaSteals.ChartType = SeriesChartType.Line;
            seriaSteals.BorderWidth = 5;
            var chartDataSteal = stats.GroupBy(x => x.Matchup.Starttime.Date).ToDictionary(Key => Key.Key, Value => Value.Sum(v => v.Steal));
            seriaSteals.Points.DataBindXY(chartDataSteal.Keys, chartDataSteal.Values);

            var seriaBlock = ChartBlocks.Series.Add("blocksLine");
            seriaBlock.ChartType = SeriesChartType.Line;
            seriaBlock.BorderWidth = 5;
            var chartDataBlock = stats.GroupBy(x => x.Matchup.Starttime.Date).ToDictionary(Key => Key.Key, Value => Value.Sum(v => v.Block));
            seriaBlock.Points.DataBindXY(chartDataBlock.Keys, chartDataBlock.Values);
        }

        private void BSearch_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
        }
    }
}
