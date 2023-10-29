using System;
using System.Globalization;
using Xamarin.Forms;

namespace DriveConnect.Converters
{
    public class ObjectVisibility : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string)
            {
                string valueString = value as string;
                if (string.IsNullOrEmpty(valueString) || valueString == "\r\n")
                    return false;
                else
                    return true;
            }
            else if (value is int)
            {
                int valueInt = (int)value;
                if (valueInt == 0) return false;
                else return true;
            }
            else if (value is double)
            {
                double valueDouble = (double)value;
                if (valueDouble == 0) return false;
                else return true;
            }
            else
                return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}