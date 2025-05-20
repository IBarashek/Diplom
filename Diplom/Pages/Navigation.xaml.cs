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
using Diplom.Pages;
using Diplom.Classes;


namespace Diplom.Pages
{
    /// <summary>
    /// Логика взаимодействия для Navigation.xaml
    /// </summary>
    public partial class Navigation : Page
    {
        public Navigation()
        {
            InitializeComponent();
            NavigatedFrame.NavigationService.Navigate(new Authorization());
        }

        private void Authorization_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            if(ConnectionClass.currentUser != null)
            {
                NavigatedFrame.NavigationService.Navigate(new Profile());
            }
            else
            {
                NavigatedFrame.NavigationService.Navigate(new Authorization());
            }
        }

        private void Favorites_Click(object sender, RoutedEventArgs e)
        {
            NavigatedFrame.NavigationService.Navigate(new Favorites());
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            NavigatedFrame.NavigationService.Navigate(new Search());
        }

        private void Sightseeing_Click(object sender, RoutedEventArgs e)
        {
            //туры и бла бла бла
        }

        private void Calendar_Click(object sender, RoutedEventArgs e)
        {
            //расписание по турам
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            //настройки, не знаю понадобятся ли они вообще
        }
    }
}
