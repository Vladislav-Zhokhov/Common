using System.Windows;

namespace Barnaul.Windows
{
    /// <summary>
    /// Это вкладка бланк яапрета АЗ у сопровождения
    /// </summary>
    public partial class BlankZapretaAZSoprovozhdenie : Window
    {
        public BlankZapretaAZSoprovozhdenie()
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