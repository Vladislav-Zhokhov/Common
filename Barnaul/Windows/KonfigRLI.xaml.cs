using System;
using System.Collections.Generic;
using System.Collections;
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
    /// Логика взаимодействия для KonfigRLI.xaml
    /// </summary>
    public partial class KonfigRLI : Window
    {
        public KonfigRLI()
        {
            InitializeComponent();
            level.Text = levelCom.Text;
            tipText.Text = tip.Content.ToString();
        }
        public KonfigRLI(int a)
        {
            InitializeComponent();
            level.Text = levelCom.Text;
            tipText.Text = tip.Content.ToString();
            tabControl.SelectedIndex = 1;
        }

        private void ComboBox_DropDownClosed(object sender, EventArgs e)
        {
            level.Text = levelCom.Text;
        }

        private void Tip_Click(object sender, RoutedEventArgs e)
        {
            tipText.Text = tip.Content.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }

}
