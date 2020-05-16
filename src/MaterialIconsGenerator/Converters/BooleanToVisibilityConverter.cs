using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace MaterialIconsGenerator.Converters
{
    /// <summary>
    /// This BooleanToVisibility converter allows us to override the converted value when
    /// the bound value is false.
    /// The built-in converter in WPF restricts us to always use Collapsed when the bound
    /// value is false.
    /// </summary>
    public class BooleanToVisibilityConverter : IValueConverter
    {
        public bool Inverted { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool bValue = false;
            if (value is bool)
            {
                bValue = (bool)value;
            }
            else if (value is bool?)
            {
                var tmp = (bool?)value;
                bValue = tmp.HasValue ? tmp.Value : false;
            }

            if (Inverted)
            {
                bValue = !bValue;
            }

            return (bValue) ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var bValue = (value is Visibility)
            ? (Visibility)value == Visibility.Visible
            : false;

            if (Inverted)
            {
                bValue = !bValue;
            }

            return bValue;
        }
    }
}
