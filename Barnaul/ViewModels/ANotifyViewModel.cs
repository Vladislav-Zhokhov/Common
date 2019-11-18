using System;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Barnaul.ViewModels
{
    public class ANotifyViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Словарь значений приватных свойств
        /// </summary>
        private readonly Dictionary<string, object> _values = new Dictionary<string, object>();

        /// <summary>
        /// Установить значение свойства с вызовом PropertyChanged
        /// </summary>
        /// <typeparam name="T">Тип свойства</typeparam>
        /// <param name="value">Новое значение</param>
        /// <param name="propertyName">Название свойства (извлекается автоматически)</param>
        protected void Set<T>(T value, [CallerMemberName]string propertyName = null)
        {
            object oldValue = null;
            if (_values.ContainsKey(propertyName))
            {
                oldValue = _values[propertyName];
                // Обновляем значение поля
                _values[propertyName] = value;
            }
            else
            {
                // Добавляем значение поля
                _values.Add(propertyName, value);
            }
            // Уведомляем подписчиков
            NotifyPropertyChanged(oldValue, value, propertyName);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

            // Уведомляем об изменении всех свойств, которые зависят от этого поля
            foreach (var member in GetType().GetProperties())
            {
                var attributes = member.GetCustomAttributes(typeof(DependsOnAttribute), true);
                if (attributes.Length == 0) continue;
                var dependsOn = attributes.First() as DependsOnAttribute;
                if (dependsOn.DependsOn.Contains(propertyName))
                    NotifyPropertyChanged(member.Name);
            }

        }

        /// <summary>
        /// Получить значение свойства
        /// </summary>
        /// <typeparam name="T">Тип свойства</typeparam>
        /// <param name="propertyName">Название свойства (извлекается автоматически)</param>
        /// <returns>Значение свойства</returns>
        protected T Get<T>([CallerMemberName]string propertyName = null)
        {
            if (_values?.ContainsKey(propertyName) == true)
                return (T)_values[propertyName];
            else
                return default(T);
        }

        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new ExtendedPropertyChangedEventArgs(propertyName));
        }
        protected void NotifyPropertyChanged(object oldValue, object newValue, [CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new ExtendedPropertyChangedEventArgs(oldValue, newValue, propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }

    /// <summary>
    /// Расширенные аргументы события изменения свойства
    /// </summary>
    public class ExtendedPropertyChangedEventArgs : PropertyChangedEventArgs
    {
        /// <summary>
        /// Старое значение свойства
        /// </summary>
        public object OldValue { get; set; }

        /// <summary>
        /// Новое значение свойства
        /// </summary>
        public object NewValue { get; set; }

        public ExtendedPropertyChangedEventArgs(string propertyName) : base(propertyName) { }

        public ExtendedPropertyChangedEventArgs(object oldValue, object newValue, string propertyName) : base(propertyName)
        {
            OldValue = oldValue;
            NewValue = newValue;
        }
    }


    /// <summary>
    /// Атрибут зависимости от других свойств
    /// При обновлении любого из свойств, которые указаны в списке DependsOn у данного поля тоже будет вызван PropertyChanged
    /// </summary>
    public class DependsOnAttribute : Attribute
    {
        /// <summary>
        /// Список свойств, от которых зависит данное поле
        /// </summary>
        public List<string> DependsOn { get; set; } = new List<string>();

        /// <summary>
        /// Атрибут зависимости от других свойств
        /// При обновлении любого из свойств, которые указаны в <paramref name="properties"/> у данного поля тоже будет вызван PropertyChanged
        /// </summary>
        /// <param name="properties">Свойства от которых зависит данное поле. Используйте nameof(...)</param>
        public DependsOnAttribute(params string[] properties)
        {
            DependsOn.AddRange(properties);
        }
    }
}