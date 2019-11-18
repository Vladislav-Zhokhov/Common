using System.Windows;

namespace Barnaul.Windows
{
    public partial class FormularPodchinennogoWindow : Window
    {
        public FormularPodchinennogoWindow()
        {
            InitializeComponent();
        }

        private void Button_DannyePoTipyZrk_Click(object sender, RoutedEventArgs e)
        {
            new DannyePoTipuZrkWindow().Show();
        }

        private void Button_Close_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
