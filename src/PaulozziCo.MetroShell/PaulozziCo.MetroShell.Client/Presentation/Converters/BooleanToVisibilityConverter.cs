using System;
using System.Windows;
using System.Globalization;

namespace PaulozziCo.MetroShell.Presentation.Converters
{
    public class BooleanToVisibilityConverter : ConverterBase<bool, Visibility>
    {
        public BooleanToVisibilityConverter()
        {
            this.TrueValue = Visibility.Visible;
            this.FalseValue = Visibility.Collapsed;
        }

        public override Visibility Convert(bool value, CultureInfo culture)
        {
            if (!value)
            {
                return this.FalseValue;
            }
            return this.TrueValue;
        }

        public Visibility FalseValue { get; set; }

        public Visibility TrueValue { get; set; }
    }
}
