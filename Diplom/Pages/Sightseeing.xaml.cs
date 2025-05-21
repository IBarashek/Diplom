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

namespace Diplom.Pages
{
    /// <summary>
    /// Логика взаимодействия для Sightseeing.xaml
    /// </summary>
    public partial class Sightseeing : Page
    {
        public Sightseeing()
        {
            InitializeComponent();
        }

        private void Info_Click(object sender, MouseButtonEventArgs e)
        {
            //создать новое окно
        }

        private void textChanged(object sender, TextChangedEventArgs e)
        {
            if (TxbSearch.Text == "")
            {
                LstSight.ItemsSource = ConnectionClass.entities.KazanSight.ToList();
            }
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            string search = TxbSearch.Text;
            if (search != null)
            {
                LstSight.ItemsSource = ConnectionClass.entities.Sightseeing.Where(x => x.Name.Contains(search) || x.Description.Contains(search) ).ToList();
            }
            else
            {
                LstSight.ItemsSource = ConnectionClass.entities.Sightseeing.ToList();
            }
        }

        private void SelDateChanged(object sender, SelectionChangedEventArgs e)
        {
            LstSight.ItemsSource = ConnectionClass.entities.Sightseeing.Where(x=> x.DateSightseeing == DapDate.SelectedDate).ToList();
        }
    }
}
