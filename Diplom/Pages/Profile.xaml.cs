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
using static System.Net.Mime.MediaTypeNames;

namespace Diplom.Pages
{
    /// <summary>
    /// Логика взаимодействия для Profile.xaml
    /// </summary>
    public partial class Profile : Page
    {
        BitmapImage bitmap = new BitmapImage();
        User user = ConnectionClass.currentUser;
        public Profile()
        {
            InitializeComponent();

            // Указываем путь к изображению
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(user.Image, UriKind.Absolute);
            bitmap.EndInit();

            // Присваиваем изображение элементу Image
            ImgUser.Source = bitmap;
            TxtLogin.Text = user.Login;
            TxtName.Text = user.Name;
            TxtLastName.Text = user.LastName;
            TxtPatronymic.Text = user.Patronymic;
        }
    }
}
