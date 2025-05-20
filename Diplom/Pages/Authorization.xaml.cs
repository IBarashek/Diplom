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
using Diplom.Classes;
using Diplom.Pages;

namespace Diplom.Pages
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Page
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void Authorization_Click(object sender, RoutedEventArgs e)
        {
            string login =  TxbLogin.Text;
            string password = PwbPassword.Password;
            if(!String.IsNullOrEmpty(login) && !String.IsNullOrEmpty(password))
            {
                ConnectionClass.currentUser = ConnectionClass.entities.User.Where(x =>  x.Login == login && x.Password == password).FirstOrDefault();
                if (ConnectionClass.currentUser != null)
                {
                    MessageBox.Show("Авторизация прошла успешно");
                    NavigationService.Navigate(new Profile());
                }
                else
                {
                    MessageBox.Show("Пользователь не найден");
                }
            }
            else
            {
                MessageBox.Show("Не все поля ззаполнены!");
            }

        }
    }
}
