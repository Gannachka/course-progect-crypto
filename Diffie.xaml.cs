using CourseProgect.Algoritms.diffiie_helman;
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
    /// Логика взаимодействия для Deffi.xaml
    /// </summary>
    public partial class Deffi  //: Window
    {
        public static Stopwatch time = new Stopwatch();
        public DiffieHellmanEncryption diffieHellmanEncryption = new DiffieHellmanEncryption();
        public Deffi()
        {
            InitializeComponent();
        }

        private void browseButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                inputMessege.Text = File.ReadAllText(openFileDialog.FileName, Encoding.Default);
        }

        private void encryptButton_Click(object sender, RoutedEventArgs e)
        {
            time.Start();
            outPutEncrypt.Text = diffieHellmanEncryption.Encrypt(inputMessege.Text);
            time.Stop();
            //EncryptTime.Text = (float)time.ElapsedMilliseconds / 1000 + "sec";
            time.Reset();
        }

        private void decryptButton_Click(object sender, RoutedEventArgs e)
        {
            string a = outPutEncrypt.Text;
            time.Start();
            a = inputMessege.Text;
            inputMessege.Text = outPutEncrypt.Text;
            outPutEncrypt.Text = diffieHellmanEncryption.Decrypt();
            time.Stop();
            //DecryptTime.Text = (float)time.ElapsedMilliseconds / 1000 + "sec";
            time.Reset();
        }

        private void outPutEncrypt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
