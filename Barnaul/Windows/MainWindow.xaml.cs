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

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            new KonfigRLI().ShowDialog();
        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            new KonfigRLI().ShowDialog();
        }

        private void MenuItem_Click_6(object sender, RoutedEventArgs e)
        {
            new KonfigRLI(2).ShowDialog();
        }

        private void MenuItem_Click_7(object sender, RoutedEventArgs e)
        {
            new ControlMods().ShowDialog();
        }

        private void MenuItem_Click_8(object sender, RoutedEventArgs e)
        {
            new EntSecResp().ShowDialog();

        }

        private void MenuItem_Click_9(object sender, RoutedEventArgs e)
        {
            new EntAreaResp().ShowDialog();
        }

        private void MenuItem_Click_10(object sender, RoutedEventArgs e)
        {
            new DKRU().ShowDialog();
        }

        private void MenuItem_Click_11(object sender, RoutedEventArgs e)
        {
            new StandingPointIssue().ShowDialog();
        }

        private void MenuItem_Click_12(object sender, RoutedEventArgs e)
        {
            new TTXSubordinate().ShowDialog();
        }
    }
}
