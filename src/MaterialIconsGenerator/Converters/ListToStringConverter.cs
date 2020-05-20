using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;

namespace MaterialIconsGenerator.Converters
{
    public class ListToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var list = (IEnumerable<object>)value ?? new List<object>();

            return string.Join(", ", list);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var text = (string)value ?? "";
            return text.Split(',');
        }
    }
}
