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
    /// Логика взаимодействия для M_498.xaml
    /// </summary>
    public partial class M_498 : Window
    {
        public M_498()
        {
            InitializeComponent();
        }
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void ClickM_498_2(object sender, RoutedEventArgs e)
        {
            this.Close();
            new M_498_2().ShowDialog();
        }
    }
}
