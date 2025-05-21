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
    /// Логика взаимодействия для ChangeData.xaml
    /// </summary>
    public partial class ChangeData : Window
    {
        User user = ConnectionClass.currentUser;
        public ChangeData()
        {
            InitializeComponent();
            
            TxbName.Text = user.Name;
            TxbPatronymic.Text = user.Patronymic;
            TxbLastName.Text = user.LastName;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            string name = TxbName.Text;
            string patronymic = TxbPatronymic.Text;
            string lastName =  TxbLastName.Text;
            if (!String.IsNullOrEmpty(name)&& !String.IsNullOrEmpty(patronymic) && !String.IsNullOrEmpty(lastName))
            {
                user.Name = name;
                user.Patronymic = patronymic;
                user.LastName = lastName;
                ConnectionClass.currentUser = user;
                ConnectionClass.entities.SaveChanges();
                MessageBox.Show("Вы успешно изменили данные");
                this.Close();
            }
            else
            {
                MessageBox.Show("Не все поля заполнены");
            }
            
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
