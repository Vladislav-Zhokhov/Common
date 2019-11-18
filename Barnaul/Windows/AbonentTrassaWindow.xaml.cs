using Barnaul.ViewModels;
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
    /// Interaction logic for AbonentTrassaWindow.xaml
    /// </summary>
    public partial class AbonentTrassaWindow : Window
    {
        public AbonentTrassaWindow(AbonentTrassaViewModel vm)
        {
            _viewModel = vm;

            InitializeComponent();
            DataContext = vm;
        }

        private readonly AbonentTrassaViewModel _viewModel;
    }
}
