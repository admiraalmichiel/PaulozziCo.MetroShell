using System;
using System.Globalization;
using System.Windows.Data;
using PaulozziCo.MetroShell.Utilities;

namespace PaulozziCo.MetroShell.Presentation.Converters
{
    public abstract class ConverterBase<TFrom, TTo> : ConverterBase<TFrom, TTo, object>
    {
        protected ConverterBase()
        {
        }

        public abstract TTo Convert(TFrom value, CultureInfo culture);
        public sealed override TTo Convert(TFrom value, object parameter, CultureInfo culture)
        {
            return this.Convert(value, culture);
        }

        public virtual TFrom ConvertBack(TTo value, CultureInfo culture)
        {
            return base.ConvertBack(value, null, culture);
        }

        public sealed override TFrom ConvertBack(TTo value, object parameter, CultureInfo culture)
        {
            return this.ConvertBack(value, culture);
        }
    }

    public abstract class ConverterBase<TFrom, TTo, TParameter> : IValueConverter
    {
        protected ConverterBase()
        {
        }

        public abstract TTo Convert(TFrom value, TParameter parameter, CultureInfo culture);
        public virtual TFrom ConvertBack(TTo value, TParameter parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        private static TParameter ConvertParameter(object parameter)
        {
            if (parameter == null)
            {
                return default(TParameter);
            }
            if (parameter is TParameter)
            {
                return (TParameter)parameter;
            }
            if ((parameter is string) && typeof(TParameter).IsEnum)
            {
                return (TParameter)Enum.Parse(typeof(TParameter), (string)parameter, true);
            }
            return (TParameter)System.Convert.ChangeType(parameter, typeof(TParameter), CultureInfo.InvariantCulture);
        }

        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Parameter.ThrowIfNotNullAndNotOfType<TFrom>(value, "value");
            return this.Convert((TFrom)value, ConverterBase<TFrom, TTo, TParameter>.ConvertParameter(parameter), culture);
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Parameter.ThrowIfNotNullAndNotOfType<TTo>(value, "value");
            return this.ConvertBack((TTo)value, ConverterBase<TFrom, TTo, TParameter>.ConvertParameter(parameter), culture);
        }
    }
}
