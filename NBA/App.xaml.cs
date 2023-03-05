using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using NBA.Models;

namespace NBA
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static NBAEntities DB = new NBAEntities();
        public static Admin loggedAdmin = null;
        public static MainWindow MainWindowInstanse;
    }
}
