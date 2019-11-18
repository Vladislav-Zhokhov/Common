namespace Barnaul.ViewModels
{
    public class VvodNomeraViewModel : ANotifyViewModel
    {
        /// <summary>
        /// Заголовок окна
        /// </summary>
        public string Title { get => Get<string>(); set => Set(value); }

        /// <summary>
        /// Текст окна
        /// </summary>
        public string Text { get => Get<string>(); set => Set(value); }

        /// <summary>
        /// Введённое число
        /// </summary>
        public int Number{ get => Get<int>(); set => Set(value); }
    }
}
