using System;
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
using System.Windows.Shapes;

namespace Barnaul.Windows
{
    /// <summary>
    /// Логика взаимодействия для M_498_2.xaml
    /// </summary>
    public partial class M_498 : Window
    {
        bool flag = true;
        public M_498()
        {
            InitializeComponent();
            a.Height = 0;
            a.Visibility = Visibility.Hidden;
            b.Height = 0;
            b.Visibility = Visibility.Hidden;
            winM_498.Height = 205;
        }
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void ClickM_498(object sender, RoutedEventArgs e)
        {
            if (flag)
            {
                a.Height = 206;
                a.Visibility = Visibility.Visible;
                b.Height = 112;
                b.Visibility = Visibility.Visible;
                winM_498.Height = 580;
                flag = false;
            }
            else if (!flag)
            {
                a.Height = 0;
                a.Visibility = Visibility.Hidden;
                b.Height = 0;
                b.Visibility = Visibility.Hidden;
                winM_498.Height = 205;
                flag = true;
            }
        }
        private int _numValue = 0;

        public int NumValue
        {
            get { return _numValue; }
            set
            {
                _numValue = value;
                txtNum.Text = value.ToString();
            }
        }

        public void NumberUpDown()
        {
            InitializeComponent();
            txtNum.Text = _numValue.ToString();
        }

        private void cmdUp_Click(object sender, RoutedEventArgs e)
        {
            NumValue++;
        }

        private void cmdDown_Click(object sender, RoutedEventArgs e)
        {
            NumValue--;
        }

        private void txtNum_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtNum == null)
            {
                return;
            }

            if (!int.TryParse(txtNum.Text, out _numValue))
                txtNum.Text = _numValue.ToString();
        }

    }
}
