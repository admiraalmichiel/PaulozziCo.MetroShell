using Microsoft.LightSwitch;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PaulozziCo.MetroShell.Presentation.Converters
{
    public class ValidationBrushConverter : ConverterBase<IEnumerable, Brush>
    {
        public override Brush Convert(IEnumerable value, CultureInfo culture)
        {
            IEnumerable<ValidationResult> enumerable;
            bool hasErrors;
            if (value == null)
            {
                return null;
            }
            ResourceDictionary resources = Application.Current.Resources;
            if (value is ValidationResults)
            {
                enumerable = (ValidationResults)value;
                hasErrors = ((ValidationResults)value).HasErrors;
            }
            else if (value is IEnumerable<ValidationResult>)
            {
                enumerable = (IEnumerable<ValidationResult>)value;
                hasErrors = enumerable.Any<ValidationResult>(r => r.Severity == ValidationSeverity.Error);
            }
            else
            {
                enumerable = from r in value.Cast<ValidationError>()
                             where r.ErrorContent is ValidationResult
                             select (ValidationResult)r.ErrorContent;
                hasErrors = value.Cast<ValidationError>().Any<ValidationError>(r => r.Exception != null);
            }
            if (!hasErrors && !enumerable.Any<ValidationResult>(r => (r.Severity == ValidationSeverity.Error)))
            {
                if (!enumerable.Any<ValidationResult>(r => (r.Severity == ValidationSeverity.Warning)) && !enumerable.Any<ValidationResult>(r => (r.Severity == ValidationSeverity.Informational)))
                {
                    return new SolidColorBrush(Colors.Transparent);
                }
                return (Brush)resources[this.WarningBrushName];
            }
            return (Brush)resources[this.ErrorBrushName];
        }

        public string ErrorBrushName { get; set; }

        public string WarningBrushName { get; set; }
    }
}
