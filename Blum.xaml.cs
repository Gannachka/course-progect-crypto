using CourseProgect.Algoritms.Blum;
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
    /// Логика взаимодействия для Blum.xaml
    /// </summary>
    public partial class Blum : Window
    {
        public static Stopwatch time = new Stopwatch();
        public BlumGoldwasser blum = new BlumGoldwasser(499, 547, -57, 52, 159201);
        public Blum()
        {
            InitializeComponent();
        }

        private void encryptButton_Click(object sender, RoutedEventArgs e)
        {
            time.Start();
            //outPutEncrypt.Text = diffieHellmanEncryption.Encrypt(inputMessege.Text);
            Tuple<List<string>, int> cyphertext= blum.Encrypt(inputMessege.Text);
            outPutEncrypt.Text = cyphertext.Item2.ToString();
            time.Stop();
            //EncryptTime.Text = (float)time.ElapsedMilliseconds / 1000 + "sec";
            time.Reset();
        }

        private void browseButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                inputMessege.Text = File.ReadAllText(openFileDialog.FileName, Encoding.Default);
        }

        private void decryptButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
