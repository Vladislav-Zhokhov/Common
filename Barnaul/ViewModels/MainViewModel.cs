using Barnaul.Windows;

namespace Barnaul.ViewModels
{
    public class MainViewModel : ANotifyViewModel
    {
        /// <summary>
        /// Открыть окно "Формуляр Цели"
        /// </summary>
        public BaseCommand OpenFС { get; } = new BaseCommand(() =>
        {
            var window = new VvodNomeraWindow();
            window.VM.Title = "Номер трассы";
            window.VM.Text = "Номер трассы";
            window.Show();
        });

        /// <summary>
        /// Открыть окно "Формуляр подчиненного"
        /// </summary>
        public BaseCommand OpenFP { get; } = new BaseCommand(() => new FormularPodchinennogoWindow().Show());

        /// <summary>
        /// Открыть окно "Запрет передачи"
        /// </summary>
        public BaseCommand OpenZP { get; } = new BaseCommand(() => new ZapretPeredachiWindow().ShowDialog());

        /// <summary>
        /// Открыть окно "Сброс трассы"
        /// </summary>
        public BaseCommand OpenST { get; } = new BaseCommand(() => new VvodNomeraWindow(
            new VvodNomeraViewModel
            {
                Title = "Сброс трассы",
                Text = "Номер трассы",
            }
        ).Show());

        /// <summary>
        /// Открыть окно "Уничтожить цель"
        /// </summary>
        public BaseCommand OpenUC { get; } = new BaseCommand(() => new AbonentTrassaWindow(
            new AbonentTrassaViewModel
            {
                WindowName = "Уничтожить цель",
                HaveDalnostAndAzimut = true,
            }
        ).Show());

        /// <summary>
        /// Открыть окно "Сбросить команду по цели"
        /// </summary>
        public BaseCommand OpenSC { get; } = new BaseCommand(() => new AbonentTrassaWindow(
            new AbonentTrassaViewModel
            {
                WindowName = "Сбросить команду по цели",
                HaveDalnostAndAzimut = false,
            }
        ).Show());


        /// <summary>
        /// Открыть окно "Запрет стрельбы по цели"
        /// </summary>
        public BaseCommand OpenKZC { get; } = new BaseCommand(() => new AbonentTrassaWindow(
            new AbonentTrassaViewModel
            {
                WindowName = "Запрет стрельбы по цели",
                HaveDalnostAndAzimut = true,
            }
        ).Show());

        /// <summary>
        /// Открыть окно "Кнопки 2Z"
        /// </summary>
        public BaseCommand Open2Z { get; } = new BaseCommand(() => new VvodComandi2ZWindow().Show());
    }
}
