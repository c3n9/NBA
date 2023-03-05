using System;
using System.Collections.Generic;
using System.IO;
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
using NBA.Services;
namespace NBA.Pages
{
    /// <summary>
    /// Логика взаимодействия для PPhotos.xaml
    /// </summary>
    public partial class PPhotos : Page
    {
        int currentIndex = 0;
        public PPhotos()
        {
            InitializeComponent(); 
            App.MainWindowInstanse.HeaderGrid.Visibility = Visibility.Visible;
            App.MainWindowInstanse.Title.Text = "Photos";
        }

        private void BPrevious_Click(object sender, RoutedEventArgs e)
        {
            currentIndex--;
            if (currentIndex < 0)
                currentIndex = App.DB.Team.Count();
            Refresh();
        }

        private void BNext_Click(object sender, RoutedEventArgs e)
        {
            currentIndex++;
            if (currentIndex > App.DB.Team.Count())
                currentIndex = 0;
            Refresh();
        }
        private void Refresh()
        {
            TBList.Text = Convert.ToString(currentIndex);
            var images = App.DB.Team.ToList().Skip(currentIndex).Take(9).ToList();
            if(images.Count == 0)
                images = App.DB.Team.Take(9).ToList();
            if (images.Count == 1)
                images.AddRange(App.DB.Team.Take(2));
            if (images.Count == 2)
                images.AddRange(App.DB.Team.Take(3));
            if (images.Count == 3)
                images.AddRange(App.DB.Team.Take(4));
            if (images.Count == 4)
                images.AddRange(App.DB.Team.Take(5));
            if (images.Count == 5)
                images.AddRange(App.DB.Team.Take(6));
            if (images.Count == 6)
                images.AddRange(App.DB.Team.Take(7));
            if (images.Count == 7)
                images.AddRange(App.DB.Team.Take(8));
            if (images.Count == 8)
                images.AddRange(App.DB.Team.Take(9));
            Image1.Source = MyTools.BytesToImage(images[0].Logo);
            Image2.Source = MyTools.BytesToImage(images[1].Logo);
            Image3.Source = MyTools.BytesToImage(images[2].Logo);
            Image4.Source = MyTools.BytesToImage(images[3].Logo);
            Image5.Source = MyTools.BytesToImage(images[4].Logo);
            Image6.Source = MyTools.BytesToImage(images[5].Logo);
            Image7.Source = MyTools.BytesToImage(images[6].Logo);
            Image8.Source = MyTools.BytesToImage(images[7].Logo);
            Image9.Source = MyTools.BytesToImage(images[8].Logo);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }
    }
}
