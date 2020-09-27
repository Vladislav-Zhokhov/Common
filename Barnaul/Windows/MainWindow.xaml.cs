using System.Windows;

namespace Barnaul.Windows
{
    using Microsoft.Xaml.Behaviors.Core;
    using ViewModels;

    public partial class MainWindow : Window
    {
        public MainViewModel VM { get; } = new MainViewModel();

        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = VM;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MapUserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            new SelectPO().ShowDialog();
        }

        private void MenuItem_Click1(object sender, RoutedEventArgs e)
        {
            new Select().ShowDialog();
        }
        private void MenuItem_Click2(object sender, RoutedEventArgs e)
        {
            new Characteristics().ShowDialog();
        }

        private void restart(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }

        private void MenuItem_ClickNavigate(object sender, RoutedEventArgs e)
        {
            new Navigate().ShowDialog();
        }
        private void MenuItem_ClickH911(object sender, RoutedEventArgs e)
        {
            new H911().ShowDialog();
        }
        private void MenuItem_ClickM_498(object sender, RoutedEventArgs e)
        {
            new M_498().ShowDialog();
        }
        private void MenuItem_ClickContolABCK(object sender, RoutedEventArgs e)
        {
            new ControlABCK().ShowDialog();
        }
        private void MenuItem_ClickControlRST(object sender, RoutedEventArgs e)
        {
            new ControlRST().ShowDialog();
        }
        private void MenuItem_ClickControlR910M(object sender, RoutedEventArgs e)
        {
            new ControlR910M().ShowDialog();
        }
    }
}
