using System;
using System.Globalization;
using Xamarin.Forms;

namespace DriveConnect.Converters
{
    public class DateFormatted : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string datestring;
            DateTime minDate = DateTime.MinValue;
            DateTimeOffset minDateOffSet = DateTimeOffset.MinValue;
            if (value is DateTime)
            {
                DateTime dateCompared = ((DateTime)value);
                if (dateCompared == minDate)
                    datestring = "---";
                else
                    datestring = dateCompared.ToString("MMMM d, yyyy HH:mm");
            }
            else if (value is DateTimeOffset)
            {
                DateTimeOffset dateCompared = ((DateTimeOffset)value);
                if (dateCompared == minDateOffSet)
                    datestring = "---";
                else
                    datestring = dateCompared.ToString("MMMM d, yyyy HH:mm");
            }
            else
                datestring = "---";

            return datestring;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
