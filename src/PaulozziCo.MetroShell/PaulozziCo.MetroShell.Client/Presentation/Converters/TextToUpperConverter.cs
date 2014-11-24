using System;
using System.Globalization;
using System.Net;
using System.Windows;
using System.Windows.Data;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace PaulozziCo.MetroShell.Presentation.Converters
{
    public class TextToUpperConverter : IValueConverter
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
                return valueAsString.ToUpper(CultureInfo.CurrentUICulture);
            }
            else
            {
                return value.ToString().ToUpper(CultureInfo.CurrentUICulture);
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}