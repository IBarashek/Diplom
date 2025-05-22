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

namespace Diplom.AdminPages
{
    /// <summary>
    /// Логика взаимодействия для SightseeingAdmin.xaml
    /// </summary>
    public partial class SightseeingAdmin : Page
    {
        public SightseeingAdmin()
        {
            InitializeComponent();
            LstSight.ItemsSource = ConnectionClass.entities.KazanSight.ToList();
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            // Получаем кнопку, по которой кликнули
            Button button = sender as Button;

            // Получаем товар, связанный с этой кнопкой
            KazanSightPage sightToRemove = button.Tag as KazanSightPage;

            if (sightToRemove != null)
            {
                // Удаляем из коллекции
                MessageBox.Show("sdawds");
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Searc_TextChanged(object sender, TextChangedEventArgs e)
        {
            string search = TxbSearch.Text;
            if (search != null)
            {
                LstSight.ItemsSource = ConnectionClass.entities.KazanSight.Where(x => x.Name.Contains(search) || x.Description.Contains(search)).ToList();
            }
            else
            {
                LstSight.ItemsSource = ConnectionClass.entities.KazanSight.ToList();
            }
        }
    }
}
