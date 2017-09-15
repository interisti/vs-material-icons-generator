using System;
using System.Collections;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace MaterialIconsGenerator.Converters
{
    class EmptyListVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return Visibility.Collapsed;
            else
            {
                var list = value as ICollection;
                if (list != null)
                {
                    if (list.Count == 0)
                        return Visibility.Collapsed;
                    else
                        return Visibility.Visible;
                }
                else
                {
                    return Visibility.Visible;
                }
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
