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
using NBA.Models;
using NBA.Services;
namespace NBA.Pages
{
    /// <summary>
    /// Логика взаимодействия для PPhotos.xaml
    /// </summary>
    public partial class PPhotos : Page
    {
        int currentPage = 0;
        int maxPage;
        int takePicture = 5;
        public PPhotos()
        {
            InitializeComponent();
            App.MainWindowInstanse.HeaderGrid.Visibility = Visibility.Visible;
            App.MainWindowInstanse.Title.Text = "Photos";
            maxPage = App.DB.Pictures.Count() / takePicture;
            if (App.DB.Pictures.Count() % takePicture != 0)
                maxPage++;
        }

        private void BPrevious_Click(object sender, RoutedEventArgs e)
        {
            currentPage--;
            if (currentPage < 0)
                currentPage = 0;
            Refresh();
        }

        private void BNext_Click(object sender, RoutedEventArgs e)
        {
            currentPage++;
            if (currentPage == maxPage)
                currentPage = maxPage - 1;
            Refresh();
        }
        private void Refresh()
        {
            TBList.Text = Convert.ToString(currentPage + 1);
            GenerateImages(App.DB.Pictures.ToList().Skip(currentPage * takePicture).Take(takePicture).ToList());


        }
        private void GenerateImages(List<Pictures> pictures)
        {
            WPPhotos.Children.Clear();
            foreach (var picture in pictures)
            {
                Image image = new Image();
                image.Source = MyTools.BytesToImage(picture.Img);
                image.Width = 200;
                image.Height = 200;
                image.Margin = new Thickness(5);
                WPPhotos.Children.Add(image);
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }
    }
}
