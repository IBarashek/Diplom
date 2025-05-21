using Diplom.Classes;
using Diplom.Windows;
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

namespace Diplom.Pages
{
    /// <summary>
    /// Логика взаимодействия для Favorites.xaml
    /// </summary>
    public partial class Favorites : Page
    {
        public Favorites()
        {
            InitializeComponent();

            if (ConnectionClass.currentUser != null)
            {
                LstFavorites.ItemsSource = ConnectionClass.entities.KazanSight
                    .Where(x => x.Id_Sight == x.FavoritesKazanSight
                    .Where(y => y.IsChosen == true && y.Id_User == ConnectionClass.currentUser.Id_User).FirstOrDefault().Id_Sight).ToList();
            }
        }

        private void ShowInfo_Click(object sender, MouseButtonEventArgs e)
        {
            string search = TxbSearch.Text;
            if (search != null)
            {
                LstFavorites.ItemsSource = ConnectionClass.entities.KazanSight.Where(x => x.Name.Contains(search) || x.Description.Contains(search)).ToList();
            }
            else
            {
                LstFavorites.ItemsSource = ConnectionClass.entities.KazanSight.ToList();
            }
        }

        private void TxbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TxbSearch.Text == "")
            {
                LstFavorites.ItemsSource = ConnectionClass.entities.KazanSight.ToList();
            }
        }

        private void Search_CLick(object sender, RoutedEventArgs e)
        {

            KazanSight sight = LstFavorites.SelectedItem as KazanSight;
            SightInfo info = new SightInfo(sight);
            info.Show();
        }
    }
}
