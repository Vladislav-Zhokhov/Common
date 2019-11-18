using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Barnaul.Converters
{
    /// <summary>
    /// Конвертер из bool в Visibility
    /// </summary>
    public class BoolToVisibilityConverter : IValueConverter
    {
        public static readonly BoolToVisibilityConverter Converter = new BoolToVisibilityConverter();

        public BoolToVisibilityConverter()
        {
            DefaultValue = Visibility.Collapsed;
            HiddenValue = Visibility.Collapsed;
        }

        public bool? Parameter { get; set; }

        public Visibility DefaultValue { get; set; }

        public Visibility HiddenValue { get; set; }

        /// <summary>
        /// Преобразует значение типа bool в значение типа Visibility по следующему правилу:
        /// Если значение value и значение parameter совпадает, то возвращается Visibility.Visible,
        /// иначе - Visibility.Collapsed.
        /// </summary>
        /// <param name="value">
        /// The value produced by the binding source.
        /// </param> 
        /// <param name="targetType">
        /// The type of the binding target property.
        /// </param>
        /// <param name="parameter">
        /// The converter parameter to use.
        /// </param>
        /// <param name="culture">
        /// The culture to use in the converter.
        /// </param>
        /// <returns>
        /// A converted value. If the method returns null, the valid null value is used.
        /// </returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return DefaultValue;
            }

            if (value is bool?)
            {
                return ConvertValue(((bool?)value).Value, parameter);
            }

            return DefaultValue;
        }

        /// <summary>
        /// Converts a value. 
        /// </summary>
        /// <returns>
        /// A converted value. If the method returns null, the valid null value is used.
        /// </returns>
        /// <param name="value">
        /// The value that is produced by the binding target.
        /// </param>
        /// <param name="targetType">
        /// The type to convert to.
        /// </param>
        /// <param name="parameter">
        /// The converter parameter to use.
        /// </param>
        /// <param name="culture">
        /// The culture to use in the converter.
        /// </param>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (Visibility)value == Visibility.Visible;
        }

        private bool GetComparer(object parameter)
        {
            if (Parameter != null)
            {
                return Parameter.Value;
            }

            if (parameter == null)
            {
                return true;
            }

            if (parameter is bool)
            {
                return (bool)parameter;
            }

            return true;
        }

        private Visibility ConvertValue(bool value, object parameter)
        {
            return ConvertValue(value, GetComparer(parameter));
        }

        private Visibility ConvertValue(bool value, bool parameter)
        {
            return (value == parameter)
                     ? Visibility.Visible
                     : HiddenValue;
        }
    }
}
