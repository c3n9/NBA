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
using Microsoft.Win32;
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
                image.Height = 500;
                image.DataContext = picture;
                image.MouseRightButtonDown += MouseRightButtonDown;
                image.Margin = new Thickness(5);
                WPPhotos.Children.Add(image);
            }
        }
        private void MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            //var selectedPicture = WPPhotos.DataContext as Pictures;
            var selectedPicture = (sender as Image).DataContext as Pictures; 
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = ".png, .jpg, .jpeg | *.png, *.jpg, *.jpeg";
            if (saveFileDialog.ShowDialog().GetValueOrDefault())
            {
                var file = File.Create(saveFileDialog.FileName);
                file.Close();
                File.WriteAllBytes(saveFileDialog.FileName, selectedPicture.Img);
            }
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        private void BLoadPhoto_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog() { Filter = ".png, .jpg, .jpeg | *.png; *.jpg; *.jpeg;", Multiselect = true };
            if(dialog.ShowDialog().GetValueOrDefault()) 
            {
                foreach (var fileName in dialog.FileNames)
                {
                    var picture = new Pictures();
                    picture.Img = File.ReadAllBytes(fileName);
                    picture.CreateTime= DateTime.Now;
                    picture.NumberOfLike = 0;
                    App.DB.Pictures.Add(picture);
                    App.DB.SaveChanges();
                    Refresh();
                }

                //var picture = new Pictures();
                //picture.Img = File.ReadAllBytes(dialog.FileName);
                //picture.CreateTime = DateTime.Now;
                //picture.NumberOfLike = 0;
                //App.DB.Pictures.Add(picture);
                //App.DB.SaveChanges();
                //Refresh();
            }
        }
        
    }
}
