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
    /// Логика взаимодействия для AuthRegGuest.xaml
    /// </summary>
    public partial class AuthRegGuest : Page
    {
        public AuthRegGuest()
        {
            InitializeComponent();
        }

        private void Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if(button.Name == "BtnAuth")
            {
                NavigationService.Navigate(new Authorization());
            }
            else if(button.Name == "BtnReg")
            {
               // NavigationService.Navigate(new );
            }
            else
            {
               // NavigationService.Navigate(new );
            }
        }
    }
}
