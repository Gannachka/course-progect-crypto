using CourseProgect.Algoritms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public Stopwatch time = new Stopwatch();
        public RSAClass rsa = new RSAClass();
        public RSA()
        {
            InitializeComponent();
        }

        private void decryptButton_Click(object sender, RoutedEventArgs e)
        {
            string a = outPutEncrypt.Text;
            time.Start();
            a = inputMessege.Text;
            inputMessege.Text = outPutEncrypt.Text;
            
            time.Stop();
            //DecryptTime.Text = (float)time.ElapsedMilliseconds / 1000 + "sec";
            time.Reset();
        }

        private void encryptButton_Click(object sender, RoutedEventArgs e)
        {
            time.Start();
            outPutEncrypt.Text = RSAClass.EncryptMessage(inputMessege.Text);
            time.Stop();
            //EncryptTime.Text = (float)time.ElapsedMilliseconds / 1000 + "sec";
            time.Reset();
        }
    }
}
