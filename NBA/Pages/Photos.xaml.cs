using Microsoft.Win32;
using NBA_2hour.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для Photos.xaml
    /// </summary>
    public partial class Photos : Page
    {
        int currentPage = 0;
        int pagesCount;
        int takePhoto = 12;
        public Photos()
        {
            InitializeComponent();

        }
        private void Refresh()
        {
            TBPage.Text = currentPage.ToString();
            var photo = App.DB.Pictures.ToList();
            pagesCount = photo.Count / takePhoto;
            if (photo.Count % takePhoto != 0)
                pagesCount++;
            LVPhotos.ItemsSource = photo.Skip(currentPage * takePhoto).Take(takePhoto).ToList();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
            App.MainWindowInstance.TBWelcome.Visibility = Visibility.Collapsed;
            App.MainWindowInstance.TBName.Text = "Photos";
            App.MainWindowInstance.TBName.VerticalAlignment = VerticalAlignment.Center;
        }

        private void BNext_Click(object sender, RoutedEventArgs e)
        {
            currentPage++;
            if (currentPage == pagesCount)
            {
                currentPage--;
                return;
            }
            Refresh();
        }

        private void BPrevious_Click(object sender, RoutedEventArgs e)
        {
            currentPage--;
            if (currentPage < 0)
            {
                currentPage = 0;
                return;
            }
            Refresh();
        }

        private void BLoadPhoto_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog() { Filter = ".jpg, .jpeg, .png|*.jpg; *.jpeg; *.png" , Multiselect=true};
            if (dialog.ShowDialog().GetValueOrDefault()) 
            {
                foreach(var fileName in dialog.FileNames)
                {
                    var picture = new Pictures();
                    picture.Img = File.ReadAllBytes(fileName);
                    picture.CreateTime = DateTime.Now;
                    picture.NumberOfLike = 0;
                    App.DB.Pictures.Add(picture);
                    App.DB.SaveChanges();
                    Refresh();
                }
            }
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var selectedPicture = LVPhotos.SelectedItem as Pictures;
            if (selectedPicture == null)
            {
                MessageBox.Show("Select an image to upload");
                return;
            }
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = ".png, .jpg, .jpeg | *.png, *.jpg, *.jpeg";
            if (saveFileDialog.ShowDialog().GetValueOrDefault())
            {
                var file = File.Create(saveFileDialog.FileName);
                file.Close();
                File.WriteAllBytes(saveFileDialog.FileName, selectedPicture.Img);
            }
        }

        private void BFirstPage_Click(object sender, RoutedEventArgs e)
        {
            currentPage = 0;
            Refresh();
        }

        private void BLastPage_Click(object sender, RoutedEventArgs e)
        {
            currentPage = pagesCount - 1;
            Refresh();
        }

        private void TBPage_TextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[0-9]");
            if (!regex.IsMatch(e.Text))
            {
                e.Handled = true;
            }
        }

        private void TBPage_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TBPage.Text == string.Empty)
                return;
            if (int.Parse(TBPage.Text) > pagesCount - 1)
                return;
            currentPage = int.Parse(TBPage.Text);
            Refresh();
        }
    }
}
