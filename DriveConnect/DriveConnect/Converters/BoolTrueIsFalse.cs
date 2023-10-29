using System;
using System.Globalization;
using Xamarin.Forms;

namespace DriveConnect.Converters
{
    public class BoolTrueIsFalse : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isEnable;
            if (value is bool)
            {
                if ((bool)value == true)
                    isEnable = false;
                else
                    isEnable = true;
            }
            else
                isEnable = true;

            return isEnable;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
