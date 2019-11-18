using System;
using System.Windows.Input;

namespace Barnaul.ViewModels
{
    public class BaseCommand : ICommand
    {
        Action<object> _action;

        /// <summary>
        /// Конструктор с действием без параметра
        /// </summary>
        /// <param name="action">Действие без параметра</param>
        public BaseCommand(Action action = null)
        {
            _action = (p) => { action.Invoke(); };
        }

        /// <summary>
        /// Конструктор с действием с параметром
        /// </summary>
        /// <param name="action">Действие с параметром</param>
        public BaseCommand(Action<object> action = null)
        {
            _action = action;
        }

        #region Implementation of ICommand

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return _action != null;
        }

        public void Execute(object parameter)
        {
            _action?.Invoke(parameter);
        }

        #endregion
    }
}
