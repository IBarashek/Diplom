using Diplom.Classes;
using Diplom.Windows;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Логика взаимодействия для KazanSight.xaml
    /// </summary>
    public partial class KazanSightPage : Page
    {
        public KazanSightPage()
        {
            InitializeComponent();
            LstSight.ItemsSource = ConnectionClass.entities.KazanSight
                   .Where(x => x.IsDelete == false).ToList();
            this.DataContext = this;
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            var sight = LstSight.SelectedItem as KazanSight;

            if (sight != null)
            {
                ChangeKazanSight window = new ChangeKazanSight(sight);
                window.Show();
            }
            else
            {
                MessageBox.Show("Для архивирования выберите достопримечательность");
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var sight = LstSight.SelectedItem as KazanSight;
            
            if (sight != null)
            {
                MessageBoxResult messageResult = MessageBox.Show("Вы действительно хотите перенести в архив выбранную достопримечательность?", "Удаление", MessageBoxButton.YesNo);
                if (messageResult == MessageBoxResult.Yes)
                {
                    KazanSight DelSight = ConnectionClass.entities.KazanSight.Where(x => x.Id_Sight == sight.Id_Sight).FirstOrDefault();
                    DelSight.IsDelete = true;
                    ConnectionClass.entities.SaveChanges();
                    LstSight.ItemsSource = ConnectionClass.entities.KazanSight
                   .Where(x => x.IsDelete == false).ToList();
                }
            }
            else
            {
                MessageBox.Show("Для архивирования выберите достопримечательность");
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddKazanSight window = new AddKazanSight();
            window.Show();
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
