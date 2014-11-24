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
using PaulozziCo.MetroShell.Utilities;

namespace PaulozziCo.MetroShell.Presentation.Converters
{
    public class BooleanToThicknessConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Nullable<Boolean> val = value as Nullable<Boolean>;
            string param = parameter.ToString();
            string[] separator = {":"};
            string[] results = {"0", "0"};

            if (!val.HasValue) val = true;

            if (param.IndexOf(":") > 0)
            {
                results = param.Split(separator, StringSplitOptions.None);
            }
            else
            {
                results[0] = param;
            }

            Thickness thickness = val.Value ? results[0].ToThickness() : results[1].ToThickness();

            return thickness;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
