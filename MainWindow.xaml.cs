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

namespace CourseProgect
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RSA rsa = new RSA();
            rsa.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Deffi deffi = new Deffi();
            deffi.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            AlGamal alGamal = new AlGamal();
            alGamal.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Blum blum = new Blum();
            blum.Show();
        }
    }
}
