using System.Windows;

namespace Barnaul.Windows
{
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
    }
}
