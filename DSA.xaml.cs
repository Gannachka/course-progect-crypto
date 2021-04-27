using CourseProgect.Algoritms.DSA;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для Bag.xaml
    /// </summary>
    public partial class DSA : Window
    {
        public DSA()
        {
            InitializeComponent();
        }

        int q;
        int p;
        int g;
        int x;
        int y;

        private void encrypt_Click(object sender, RoutedEventArgs e)
        {

            Keys key = new Keys();
             q = key.GenerateQ();
             p = key.GenerateP(q);
             g = key.GenerateG(q, p);
             x = key.GenerateX(q);
             y = key.FastExponentiation(p, g, x);

            cipher_r.Text = "";
            cipher_s.Text = "";

            string src = source.Text;

            DSAClass dsa = new DSAClass();
            int[] res;

            res = dsa.Signature(src, q, p, g, x);
            cipher_r.Text += Convert.ToString(res[0]);
            cipher_s.Text += Convert.ToString(res[1]);

            
        }

        private void decrypt_Click(object sender, RoutedEventArgs e)
        {
            int Q = Convert.ToInt32(q);
            int P = Convert.ToInt32(p);
            int Y = Convert.ToInt32(y);

            int r = Convert.ToInt32(textR.Text);
            int s = Convert.ToInt32(textS.Text);

            Keys key = new Keys();
            int g = key.GenerateG(q, p);

            string src = source.Text;

            DSAClass dsa = new DSAClass();
            if (dsa.CheckingSignature(Q, P, r, Y, g, s, src)&& src==inputLine.Text)
            {
                cipher.Text = source.Text + " " + r + ", " + s;
            }
            else
            {
                cipher.Text = "The signature isn't correct";
            }
        }

        private void browseButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                source.Text = File.ReadAllText(openFileDialog.FileName, Encoding.Default);
        }
    }
}
