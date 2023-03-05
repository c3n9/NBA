using NBA.Services;
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
    /// Логика взаимодействия для PMainScreen.xaml
    /// </summary>
    public partial class PMainScreen : Page
    {
        int currentIndex=0;
        public PMainScreen()
        {
            InitializeComponent();
        }

        private void BVisitor_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PVisitorMenu());
        }

        private void BAdmin_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PAdminLogin());
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
            App.MainWindowInstanse.HeaderGrid.Visibility = Visibility.Collapsed;
        }
        private void Refresh()
        {
            var images = App.DB.Pictures.ToList().Skip(currentIndex).Take(3).ToList();
            if(images.Count == 0) 
                images = App.DB.Pictures.Take(3).ToList();
            if(images.Count == 1)
                images.AddRange(App.DB.Pictures.Take(2));
            if(images.Count == 2) 
                images.AddRange(App.DB.Pictures.Take(3));
            Image1.Source = MyTools.BytesToImage(images[0].Img);
            Image2.Source = MyTools.BytesToImage(images[1].Img);
            Image3.Source = MyTools.BytesToImage(images[2].Img);

        }

        private void BPrevious_Click(object sender, RoutedEventArgs e)
        {
            currentIndex--;
            if (currentIndex < 0)
                currentIndex = App.DB.Pictures.Count();
            Refresh();
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            currentIndex++;
            if (currentIndex > App.DB.Pictures.Count())
                currentIndex = 0;
            Refresh();
        }
    }
}
