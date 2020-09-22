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
    /// Логика взаимодействия для CommandTable.xaml
    /// </summary>
    public partial class CommandTable : Window
    {
        public CommandTable()
        {
            InitializeComponent();
        }

        private void KR_Click(object sender, RoutedEventArgs e)
        {
            bool ui = false;
            if(KR.Content.ToString() == "КРУ/ДКРУ" && !ui)
            {
                ui = true;
                KR.Content = "КО/ДКО";
                KO.Text = "КРУ";
                DKO.Text = "ДКРУ";
            }
            if (KR.Content.ToString() == "КО/ДКО" && !ui)
            {
                ui = true;
                KR.Content = "КРУ/ДКРУ";
                KO.Text = "КО";
                DKO.Text = "ДКО";
            }
        }
    }
}
