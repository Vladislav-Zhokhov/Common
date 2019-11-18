using System.Windows;

namespace Barnaul.Windows
{
    using ViewModels;

    public partial class ZapretPeredachiWindow : Window
    {
        public ZapretPeredachiViewModel VM { get; set; } = new ZapretPeredachiViewModel();

        public ZapretPeredachiWindow()
        {
            InitializeComponent();

            this.DataContext = VM;
        }

        private void Button_Close_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
