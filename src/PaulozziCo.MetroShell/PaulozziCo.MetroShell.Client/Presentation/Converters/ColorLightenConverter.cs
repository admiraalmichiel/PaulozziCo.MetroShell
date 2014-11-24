using PaulozziCo.MetroShell.Model;
using PaulozziCo.MetroShell.Utilities;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace PaulozziCo.MetroShell.Presentation.Converters
{
    public class ColorLightenConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return null;

            Color color = new Color();
            Double pct = 0.2d;

            if (value is Color)
            {
                if (parameter != null)
                {
                    double conv;
                    if (Double.TryParse(parameter.ToString(), NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out conv))
                    {
                        pct = conv;
                    }
                }

                color = (Color)value;

                ColorHelper.HslColor hslBase = ColorHelper.HslColor.FromColor(color);
                color = hslBase.Lighten(pct).ToColor();
            }

            return color;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class ColorDarkenConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return null;

            Color color = new Color();
            Double pct = 0.2d;

            if (value is Color)
            {
                if (parameter != null)
                {
                    double conv;
                    if (Double.TryParse(parameter.ToString(),NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out conv))
                    {
                        pct = conv;
                    }
                }

                color = (Color)value;

                ColorHelper.HslColor hslBase = ColorHelper.HslColor.FromColor(color);
                color = hslBase.Darken(pct).ToColor();
            }

            return color;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
