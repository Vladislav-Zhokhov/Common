using Barnaul.Windows;

namespace Barnaul.ViewModels
{
    public class AbonentTrassaViewModel : ANotifyViewModel
    {
        public string WindowName { get => Get<string>(); set => Set(value); }
        public bool HaveDalnostAndAzimut { get => Get<bool>(); set => Set(value); }
    }
}
