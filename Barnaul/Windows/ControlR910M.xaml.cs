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
    /// Логика взаимодействия для ControlR910M.xaml
    /// </summary>
    public partial class ControlR910M : Window
    {
        public ControlR910M()
        {
            InitializeComponent();
        }
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
