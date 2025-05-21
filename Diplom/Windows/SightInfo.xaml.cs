using Diplom.Classes;
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
using Diplom.Pages;


namespace Diplom.Windows
{
    public partial class SightInfo : Window
    {
        BitmapImage bitmap = new BitmapImage();
        KazanSight currentSight;
        public SightInfo(KazanSight sight)
        {
            InitializeComponent();
            currentSight = sight;
            // Указываем путь к изображению
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(sight.Image, UriKind.Absolute);
            bitmap.EndInit();

            // Присваиваем изображение элементу Image
            ImgSight.Source = bitmap;

            TxtName.Text = sight.Name;
            TxtDescription.Text = sight.Description;

            if (ConnectionClass.currentUser != null)
            {
                FavoritesKazanSight favorites = ConnectionClass.entities.FavoritesKazanSight.Where(x => x.Id_User == ConnectionClass.currentUser.Id_User).FirstOrDefault();
                if (favorites.IsChosen == true)
                {
                    BtnLike.Foreground = Brushes.Red;
                }
            }
        }

        private void Favorites_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (ConnectionClass.currentUser != null)
            {
                FavoritesKazanSight favorites = ConnectionClass.entities.FavoritesKazanSight.Where(x => x.Id_User == ConnectionClass.currentUser.Id_User).FirstOrDefault();
                if (button.Foreground == Brushes.Gray)
                {
                    button.Foreground = Brushes.Red;
                    if (favorites != null)
                    {
                        favorites.IsChosen = true;
                    }
                    else
                    {
                        FavoritesKazanSight newFavorites = new FavoritesKazanSight()
                        {
                            Id_User = ConnectionClass.currentUser.Id_User,
                            Id_Sight = currentSight.Id_Sight,
                            IsChosen = true
                        };
                        ConnectionClass.entities.FavoritesKazanSight.Add(newFavorites);
                    }
                }
                else
                {
                    favorites.IsChosen = false;
                    button.Foreground = Brushes.Gray;
                }
                ConnectionClass.entities.SaveChanges();
            }
            else
            {
                MessageBox.Show("Для этого действия вам нужно авторизоваться");
            }
        }
    }
}
