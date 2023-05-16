﻿using NBA_2hour.AppWindows;
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
    /// Логика взаимодействия для TechnicalAdministratorMenu.xaml
    /// </summary>
    public partial class TechnicalAdministratorMenu : Page
    {
        public TechnicalAdministratorMenu()
        {
            InitializeComponent();
            App.MainWindowInstance.BBack.Visibility = Visibility.Visible;
            new MessageWindow().ShowDialog();
        }

        private void BTeamReport_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BManageExecutions_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            App.MainWindowInstance.TBName.Text = "Technical Administrator Menu";
        }
    }
}
