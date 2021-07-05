using CourseProgect.Algoritms.Al_Gamal;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CourseProgect
{
    /// <summary>
    /// Логика взаимодействия для AlGamal.xaml
    /// </summary>
    public partial class AlGamal : Window
    {
        public static string cryptedText;
        public Stopwatch time = new Stopwatch();
        public AlGamal()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            time.Start();
            if (inputMessage.Text != "")
            {
                time.Start();
                cryptedText = ElGamal.EnCrypt(inputMessage.Text);
                encodingMessege.Text = cryptedText;
                time.Stop();
            }
            else
                MessageBox.Show("Введите сообщение");
           
           encodingTime.Text = (float)time.ElapsedMilliseconds / 1000 + "sec";
        }

        private void decodingButton_Click(object sender, RoutedEventArgs e)
        {
            if (cryptedText != "")
            {
                time.Restart();
                decodingMessege.Text = ElGamal.DeCrypt(cryptedText);
                time.Stop();

                decodingTime.Text = (float)time.ElapsedMilliseconds / 1000 + "sec";
            }
            else
                MessageBox.Show("Поле для расшифрования пустое");


        }

        private void browseButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                inputMessage.Text = File.ReadAllText(openFileDialog.FileName, Encoding.Default);
        }
    }
}
