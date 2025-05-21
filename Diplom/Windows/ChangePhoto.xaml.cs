using Diplom.Classes;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
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
using System.Windows.Shapes;

namespace Diplom.Windows
{
    /// <summary>
    /// Логика взаимодействия для ChangePhoto.xaml
    /// </summary>
    public partial class ChangePhoto : Window
    {
        BitmapImage bitmap = new BitmapImage();

        public ChangePhoto()
        {
            InitializeComponent();

            bitmap.BeginInit();
            bitmap.UriSource = new Uri(ConnectionClass.currentUser.Image, UriKind.Absolute);
            bitmap.EndInit();

            // Присваиваем изображение элементу Image
            ImgPhoto.Source = bitmap;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(TxtNameFile.Text))
            {
                ConnectionClass.currentUser.Image = TxtNameFile.Text;
                ConnectionClass.entities.SaveChanges();
                this.Close();
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            
        }
        private void ChooseFile_Click(object sender, RoutedEventArgs e)
        {
            BitmapImage bitmap2 = new BitmapImage();

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Изображения (*.png;*.jpg;*.jpeg;*.gif)|*.png;*.jpg;*.jpeg;*.gif";
            // Показываем диалог
            if (openFileDialog.ShowDialog() == true)
            {
                string selectedFilePath = openFileDialog.FileName;
                // Указываем путь к изображению
                bitmap2.BeginInit();
                bitmap2.UriSource = new Uri(selectedFilePath, UriKind.Absolute);
                bitmap2.EndInit();

                // Присваиваем изображение элементу Image
                ImgPhoto.Source = bitmap2;
                TxtNameFile.Text = selectedFilePath;
            }
        }
    }
}
