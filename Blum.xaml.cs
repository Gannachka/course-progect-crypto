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
            if (inputMessege.Text != "")
            {
                time.Start();
                Tuple<List<string>, int> cyphertext = blum.Encrypt(inputMessege.Text);
                for (int i = 0; i < cyphertext.Item1.Count; i++)
                {
                    outPutEncrypt.Text += cyphertext.Item1[i].ToString() + " ";
                }
                outPutEncrypt.Text += cyphertext.Item2.ToString();
                time.Stop();
                privateKey.Text = (float)time.ElapsedMilliseconds / 1000 + "sec";
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

        private void DecryptButton_Click(object sender, RoutedEventArgs e)
        {           
                time.Start();
                string temp = outPutEncrypt.Text;
                inputMessege.Text = blum.decrypt(temp);
                inputMessege.Text = temp;
                publicKey.Text = (float)time.ElapsedMilliseconds / 1000 + "sec";
                time.Reset();          
          
        }

        private void decryptButton_Click(object sender, RoutedEventArgs e)
        {
        if (outPutEncrypt.Text != "")
        {
            time.Start();
            string temp = outPutEncrypt.Text;
            decodingMessege.Text = inputMessege.Text;
            publicKey.Text = (float)time.ElapsedMilliseconds / 1000 + "sec";
            time.Reset();
            }
            else
                MessageBox.Show("Поле для расшифрования пустое");
        }
    }
}
