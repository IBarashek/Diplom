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
using System.Windows.Shapes;

namespace Diplom.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddSightseeing.xaml
    /// </summary>
    public partial class AddSightseeing : Window
    {
        public AddSightseeing()
        {
            InitializeComponent();
            CmbEmployee.ItemsSource = ConnectionClass.entities.Employee.Select(x=> x.Name).ToList();
            CmbSight.ItemsSource = ConnectionClass.entities.KazanSight.Select(x => x.Name).ToList();
            CmbType.ItemsSource = ConnectionClass.entities.TypeSightseeing.Select(x => x.Name).ToList();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (CmbEmployee.SelectedItem != null && CmbSight.SelectedItem != null && CmbType.SelectedItem != null
                && !String.IsNullOrEmpty(TxbCost.Text) && !String.IsNullOrEmpty(TxbDescription.Text) && !String.IsNullOrEmpty(TxbLimit.Text)
                && !String.IsNullOrEmpty(TxbName.Text) && DapDate.SelectedDate != null)
            {
                string name = TxbName.Text;
                string descriptionSightseeing = TxbDescription.Text;
                int cost = Convert.ToInt32(TxbCost.Text);
                int limit = Convert.ToInt32(TxbLimit.Text);
                int id_Sight = CmbSight.SelectedIndex + 1;
                int id_Employee = CmbEmployee.SelectedIndex + 1;
                int id_Type = CmbType.SelectedIndex + 1;
                Sightseeing sightseeing = new Sightseeing()
                {
                    Id_Employee = id_Employee,
                    Id_Type = id_Type,
                    Id_Sight = id_Sight,
                    Cost = cost,
                    Limit = limit,
                    Name = name,
                    Description = descriptionSightseeing,
                    DateSightseeing = (DateTime)DapDate.SelectedDate,
                    Id_Administrator = ConnectionClass.administrator.Id_Administrator
                };
                ConnectionClass.entities.Sightseeing.Add(sightseeing);
                ConnectionClass.entities.SaveChanges();
                MessageBox.Show("Экскурсия была успешно добавлена");
            }
            else
            {
                MessageBox.Show("Не все поля заполнены");
            }

        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
