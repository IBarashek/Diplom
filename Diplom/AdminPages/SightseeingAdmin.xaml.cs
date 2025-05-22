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
            LstSightseeing.ItemsSource = ConnectionClass.entities.Sightseeing
.Where(x => x.IsDelete == false).ToList();
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var sightseeing = LstSightseeing.SelectedItem as Sightseeing;

            if (sightseeing != null)
            {
                MessageBoxResult messageResult = MessageBox.Show("Вы действительно хотите перенести в архив выбранную экскурсию?", "Удаление", MessageBoxButton.YesNo);
                if (messageResult == MessageBoxResult.Yes)
                {
                    Sightseeing DelSight = ConnectionClass.entities.Sightseeing.Where(x => x.Id_Sightseeing == sightseeing.Id_Sightseeing).FirstOrDefault();
                    DelSight.IsDelete = true;
                    ConnectionClass.entities.SaveChanges();
                    LstSightseeing.ItemsSource = ConnectionClass.entities.Sightseeing
                   .Where(x => x.IsDelete == false).ToList();
                }
            }
            else
            {
                MessageBox.Show("Для архивирования выберите экскурсию");
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddSightseeing window = new AddSightseeing();
            window.Show();
        }

        private void Searc_TextChanged(object sender, TextChangedEventArgs e)
        {
            string search = TxbSearch.Text;
            if (search != null)
            {
                LstSightseeing.ItemsSource = ConnectionClass.entities.Sightseeing.Where(x => x.Name.Contains(search) || x.Description.Contains(search) && x.IsDelete == false).ToList();
            }
            else
            {
                LstSightseeing.ItemsSource = ConnectionClass.entities.Sightseeing
.Where(x => x.IsDelete == false).ToList();
            }
        }
    }
}
