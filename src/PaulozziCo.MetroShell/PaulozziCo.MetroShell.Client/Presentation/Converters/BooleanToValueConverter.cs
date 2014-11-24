using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace PaulozziCo.MetroShell.Presentation.Converters
{
    public class BooleanToValueConverter :
        DependencyObject,
        IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? ValueForTrue : ValueForFalse;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        public object ValueForTrue
        {
            get { return (object)GetValue(ValueForTrueProperty); }
            set { SetValue(ValueForTrueProperty, value); }
        }
        public static readonly DependencyProperty ValueForTrueProperty =
            DependencyProperty.Register("ValueForTrue", typeof(object), typeof(BooleanToValueConverter), new PropertyMetadata(null));

        public object ValueForFalse
        {
            get { return (object)GetValue(ValueForFalseProperty); }
            set { SetValue(ValueForFalseProperty, value); }
        }
        public static readonly DependencyProperty ValueForFalseProperty =
            DependencyProperty.Register("ValueForFalse", typeof(object), typeof(BooleanToValueConverter), new PropertyMetadata(null));
    }
}
