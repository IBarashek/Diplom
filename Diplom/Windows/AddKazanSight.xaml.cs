using Diplom.Classes;
using Microsoft.Win32;
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
using System.Windows.Shapes;

namespace Diplom.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddKazanSight.xaml
    /// </summary>
    public partial class AddKazanSight : Window
    {
        public AddKazanSight()
        {
            InitializeComponent();
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

        private void Add_click(object sender, RoutedEventArgs e)
        {
            string name = TxbName.Text;
            string description = TxbDescription.Text;
            string filePath = TxtFile.Text;
            if (!String.IsNullOrEmpty(name) && !String.IsNullOrEmpty(description) && !String.IsNullOrEmpty(filePath))
            {
                KazanSight sight = new KazanSight()
                {
                    Name = name,
                    Description = description,
                    Image = filePath,
                    Id_Administrator = ConnectionClass.administrator.Id_Administrator
                };
                ConnectionClass.entities.KazanSight.Add(sight);
                ConnectionClass.entities.SaveChanges();
                MessageBox.Show("Достопримечательность успешно добавлена");
                this.Close();
            }
            else
            {
                MessageBox.Show("Не все поля заполнены");
            }

        }
    }
}
