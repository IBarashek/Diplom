﻿using System;
using System.Collections.Generic;
using System.Drawing;
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
    public partial class SightInfo : Window
    {
        BitmapImage bitmap = new BitmapImage();
        public SightInfo(KazanSight sight)
        {
            InitializeComponent();
            // Указываем путь к изображению
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(sight.Image, UriKind.Absolute);
            bitmap.EndInit();

            // Присваиваем изображение элементу Image
            ImgSight.Source = bitmap;

            TxtName.Text = sight.Name;
            TxtDescription.Text = sight.Description;
        }

        private void Favorites_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
