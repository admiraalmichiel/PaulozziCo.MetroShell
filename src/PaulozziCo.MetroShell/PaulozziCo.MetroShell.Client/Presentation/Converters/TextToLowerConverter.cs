using System;
using System.Globalization;
using System.Windows.Data;

namespace PaulozziCo.MetroShell.Presentation.Converters
{
    public class TextToLowerConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {

            String valueAsString = value as String;
            if (value == null)
            {
                return string.Empty;
            }
            else if (valueAsString != null)
            {
                return valueAsString.ToLower(CultureInfo.CurrentUICulture);
            }
            else
            {
                return value.ToString().ToLower(CultureInfo.CurrentUICulture);
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
