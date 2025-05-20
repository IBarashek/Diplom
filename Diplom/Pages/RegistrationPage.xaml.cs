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
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void BtnRegistration_Click(object sender, RoutedEventArgs e)
        {
            string login = TxbLogin.Text;
            string password = PwbPassword.Password;
            string password2 = PwbPassword2.Password;
            if (!String.IsNullOrEmpty(login) && !String.IsNullOrEmpty(password) && !String.IsNullOrEmpty(password2))
            {
                User user = ConnectionClass.entities.User.Where(x => x.Login.Equals(login)).FirstOrDefault();
                if (user == null)
                {
                    if (password == password2)
                    {
                        ConnectionClass.currentUser = new User()
                        {
                            Login = login,
                            Password = password,
                            Image = "pack://application:,,,/Images/commonUser.jpg"
                        };
                        ConnectionClass.entities.User.Add(ConnectionClass.currentUser);
                        ConnectionClass.entities.SaveChanges();
                        MessageBox.Show("Регистрация прошла успешно");
                        NavigationService.Navigate(new Profile());
                    }
                    else
                    {
                        MessageBox.Show("Ваши пароли не совпадают");
                    }
                }
                else
                {
                    MessageBox.Show("Такой пользователь уже зарегестрирован");
                }

            }
            else
            {
                MessageBox.Show("Не все поля ззаполнены!");
            }
        }
    }
}
