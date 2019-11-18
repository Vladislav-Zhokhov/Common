using System.Windows;

namespace Barnaul.Windows
{
    using ViewModels;

    public partial class VvodNomeraWindow : Window
    {
        public VvodNomeraViewModel VM { get => DataContext as VvodNomeraViewModel; set => DataContext = value; }

        public VvodNomeraWindow(VvodNomeraViewModel vm)
        {
            InitializeComponent();

            DataContext = vm;
            VM = vm;
        }

        public VvodNomeraWindow()
        {
            InitializeComponent();

            DataContext = new VvodNomeraViewModel();
        }

    }
}
