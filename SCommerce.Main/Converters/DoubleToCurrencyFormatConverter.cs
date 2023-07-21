using System;
using Windows.UI.Xaml.Data;

namespace SCommerce.Main.Converters
{
    public class DoubleToCurrencyFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is double num)
            {
                return num.ToString("0.##");
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
