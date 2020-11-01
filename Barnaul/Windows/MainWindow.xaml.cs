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

        private void SoprovodBlyat(object sender, RoutedEventArgs e)
        {
            new BlankZapretaAZSoprovozhdenie().ShowDialog();
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
            new GoalCharacteristics().ShowDialog();
        }

        private void restart(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            new CommandTable().ShowDialog();
        }

        private void Gk_Click(object sender, RoutedEventArgs e)
        {
            Mest.IsChecked = false;
        }

        private void Mest_Click(object sender, RoutedEventArgs e)
        {
            Gk.IsChecked = false;
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            new Trace().ShowDialog();
        }

        private void Reper_Click(object sender, RoutedEventArgs e)
        {
            Ts.IsChecked = false;
        }

        private void Ts_Click(object sender, RoutedEventArgs e)
        {
            Reper.IsChecked = false;
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            new SpeedUpdate().ShowDialog();
        }
    }
}
