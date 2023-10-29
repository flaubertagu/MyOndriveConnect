using System;
using System.Globalization;
using Xamarin.Forms;

namespace DriveConnect.Converters
{
    public class BoolTrueIsTrue : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isVisible;
            if (value is bool)
            {
                if ((bool)value == true)
                    isVisible = true;
                else
                    isVisible = false;
            }
            else
                isVisible = false;
            return isVisible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
