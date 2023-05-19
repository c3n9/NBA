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
    /// Логика взаимодействия для ManageTeams.xaml
    /// </summary>
    public partial class ManageTeams : Page
    {
        public ManageTeams()
        {
            InitializeComponent();

            var conferences = App.DB.Conference.ToList();
            conferences.Insert(0, new Conference() { Name = "View all" });
            CBConference.ItemsSource = conferences;
            CBConference.SelectedIndex = 0;
            var divisions = App.DB.Division.ToList();
            divisions.Insert(0, new Division() { Name = "View All" });
            CBDivision.ItemsSource = divisions;
            CBDivision.SelectedIndex = 0;
            Refresh();

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }
        private void Refresh()
        {
            App.MainWindowInstance.TBWelcome.Visibility = Visibility.Collapsed;
            App.MainWindowInstance.TBName.Text = "Manage Teams";
            App.MainWindowInstance.TBName.VerticalAlignment = VerticalAlignment.Center;
            var filtred = App.DB.Team.ToList();
            var selectedConferences = CBConference.SelectedItem as Conference;
            var selectedDivision = CBDivision.SelectedItem as Division;
            var surchText = TBSurch.Text.ToLower();
            if (selectedConferences != null && CBConference.SelectedIndex != 0)
                filtred = filtred.Where(x => x.Division.ConferenceId == selectedConferences.ConferenceId).ToList();
            if (selectedDivision != null && CBDivision.SelectedIndex != 0)
                filtred = filtred.Where(x => x.DivisionId == selectedDivision.DivisionId).ToList();
            if(!String.IsNullOrWhiteSpace(surchText))
                filtred = filtred.Where(x => x.TeamName.ToLower().Contains(surchText)).ToList();
            DGTeams.ItemsSource = filtred;

        }
        private void CBConference_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void CBDivision_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }
    }
}
