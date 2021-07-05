using CourseProgect.Algoritms;
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
    /// Логика взаимодействия для RSA.xaml
    /// </summary>
    public partial class RSA : Window
    {
        public static Stopwatch time = new Stopwatch();
        public RSAClass rsa = new RSAClass();
        public RSA()
        {
            InitializeComponent();
        }

        private void decryptButton_Click(object sender, RoutedEventArgs e)
        {
            if (outPutEncrypt.Text != "")
            {
                time.Start();
                decodingMessege.Text = RSAClass.DecryptMessage();
                time.Stop();
                publicKey.Text = (float)time.ElapsedMilliseconds / 1000 + "sec";
                time.Reset();
            }
            else
                MessageBox.Show("Поле пустое");
        }

        private void encryptButton_Click(object sender, RoutedEventArgs e)
        {
            time.Start();
            if (inputMessege.Text != "")
            {
                outPutEncrypt.Text = RSAClass.EncryptMessage(inputMessege.Text);
                time.Stop();
                privateKey.Text = (float)time.ElapsedMilliseconds / 1000 + "sec";
                time.Reset();
            }
            else
                MessageBox.Show("Введите сообщение");
           
        }

        private void browseButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                inputMessege.Text = File.ReadAllText(openFileDialog.FileName, Encoding.Default);
        }
    }
}
