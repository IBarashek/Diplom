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
    /// Логика взаимодействия для ChangeKazanSight.xaml
    /// </summary>
    public partial class ChangeKazanSight : Window
    {
        KazanSight currentSight;
        public ChangeKazanSight(KazanSight kazanSight)
        {
            InitializeComponent();
            currentSight = kazanSight;
            TxbName.Text = currentSight.Name;
            TxbDescription.Text = currentSight.Description;
            CmbTypeSight.ItemsSource = ConnectionClass.entities.TypeSight.Select(x => x.Name).ToList();
            CmbTypeSight.SelectedIndex = currentSight.Id_TypeSight - 1;
            TxtFile.Text = currentSight.Image;
            BitmapImage bitmap = new BitmapImage();

            bitmap.BeginInit();
            bitmap.UriSource = new Uri(currentSight.Image, UriKind.Absolute);
            bitmap.EndInit();

            // Присваиваем изображение элементу Image
            ImgSight.Source = bitmap;
        }

        private void ChooseFile_Click(object sender, RoutedEventArgs e)
        {
            BitmapImage bitmap = new BitmapImage();

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Изображения (*.png;*.jpg;*.jpeg;*.gif)|*.png;*.jpg;*.jpeg;*.gif";
            // Показываем диалог
            if (openFileDialog.ShowDialog() == true)
            {
                string selectedFilePath = openFileDialog.FileName;
                // Указываем путь к изображению
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(selectedFilePath, UriKind.Absolute);
                bitmap.EndInit();

                // Присваиваем изображение элементу Image
                ImgSight.Source = bitmap;
                TxtFile.Text = selectedFilePath;
            }
        }

        private void CoBack_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Change_click(object sender, RoutedEventArgs e)
        {
            string name = TxbName.Text;
            string description = TxbDescription.Text;
            string filePath = TxtFile.Text;
            string location = TxbLocation.Text;
            string contacts = TxbContacts.Text;
            string time = TxbTime.Text;
            if (!String.IsNullOrEmpty(name) && !String.IsNullOrEmpty(description) && !String.IsNullOrEmpty(filePath) && CmbTypeSight.SelectedItem != null )
            {
                currentSight.Name = name;
                currentSight.Description = description;
                currentSight.Image = filePath;
                currentSight.Location = location;
                currentSight.Contacts = contacts;
                currentSight.WorkMode = time;
                currentSight.Id_TypeSight = CmbTypeSight.SelectedIndex + 1;
                ConnectionClass.entities.SaveChanges();
                MessageBox.Show("Достопримечательность успешно изменена ");
                this.Close();
            }
            else
            {
                MessageBox.Show("Не все поля заполнены");
            }

        }
    }
}
