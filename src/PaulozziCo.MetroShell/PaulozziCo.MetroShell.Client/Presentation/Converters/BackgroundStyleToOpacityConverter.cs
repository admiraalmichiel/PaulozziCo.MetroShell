using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Data;
using PaulozziCo.MetroShell.Model;
using System.Globalization;

namespace PaulozziCo.MetroShell.Presentation.Converters
{
    public class BackgroundStyleToOpacityConverter : IValueConverter
    {
        private const Double defaultOpacity = 1d;

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null) return defaultOpacity;

            Double result = defaultOpacity;

            Double opacity = (parameter != null) ? System.Double.Parse(parameter.ToString(), System.Globalization.NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture.NumberFormat) : 0.1d;

            if (value is BackgroudColorStyle)
            {
                BackgroudColorStyle style = (BackgroudColorStyle)value;

                if (style == BackgroudColorStyle.Dark)
                    result = opacity;

            }
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
