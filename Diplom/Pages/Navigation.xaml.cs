﻿using System;
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
            MainFrame.NavigationService.Navigate(new AuthRegGuest());
        }

        private void Authorization_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new AuthRegGuest());
        }
    }
}
