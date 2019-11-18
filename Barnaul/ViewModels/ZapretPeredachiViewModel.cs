namespace Barnaul.ViewModels
{
    public class ZapretPeredachiViewModel : ANotifyViewModel
    {
        public bool Value1 { get => Get<bool>(); set => Set(value); }
        public bool Value2 { get => Get<bool>(); set => Set(value); }
        public bool Value3 { get => Get<bool>(); set => Set(value); }
        public bool Value4 { get => Get<bool>(); set => Set(value); }
        public bool Value5 { get => Get<bool>(); set => Set(value); }
        public bool Value6 { get => Get<bool>(); set => Set(value); }

        public BaseCommand ZapretAll {
            get => new BaseCommand(() =>
            {
                Value1 = true;
                Value2 = true;
                Value3 = true;
                Value4 = true;
                Value5 = true;
                Value6 = true;
            });
        }

        public BaseCommand OtmenaAll {
            get => new BaseCommand(() =>
            {
                Value1 = false;
                Value2 = false;
                Value3 = false;
                Value4 = false;
                Value5 = false;
                Value6 = false;
            });
        }
    }
}
