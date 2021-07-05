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
           if (inputMessege.Text != "")
            {
              
                time.Start();
                outPutEncrypt.Text = diffieHellmanEncryption.Encrypt(inputMessege.Text);
                time.Stop();
                privateKey.Text = (float)time.ElapsedMilliseconds / 1000 + "sec";
                time.Reset();
            }
            else
                MessageBox.Show("Введите сообщение");
           
        }

        private void decryptButton_Click(object sender, RoutedEventArgs e)
        {
            string a = outPutEncrypt.Text;
            if (outPutEncrypt.Text != "")
            {
                time.Start();
                decodingMessege.Text = diffieHellmanEncryption.Decrypt();
                time.Stop();
                publicKey.Text = (float)time.ElapsedMilliseconds / 1000 + "sec";
                time.Reset();
            }
            else
                MessageBox.Show("Поле для расшифрования пустое");
        }

        private void outPutEncrypt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
