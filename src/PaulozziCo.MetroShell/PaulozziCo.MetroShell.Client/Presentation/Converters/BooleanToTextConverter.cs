using System;
using System.Windows.Data;
using PaulozziCo.MetroShell.Utilities;

namespace PaulozziCo.MetroShell.Presentation.Converters
{
    public class BooleanToTextConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Nullable<Boolean> val = value as Nullable<Boolean>;

            if (!val.HasValue) return false.ToLocalizedString();

            return val.Value.ToLocalizedString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}