using System;
using System.Globalization;
using System.Windows.Data;

namespace MaterialIconsGenerator.Converters
{
    public class FontSizeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is double))
            {
                throw new ArgumentException("Input value is not of type double.");
            }
            double num = 0;
            if (parameter is string)
            {
                double.TryParse((string)parameter, NumberStyles.Any, CultureInfo.InvariantCulture, out num);
            }
            return (double)value + num;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
