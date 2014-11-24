using Microsoft.LightSwitch;
using PaulozziCo.MetroShell.Presentation.Resources;
using PaulozziCo.MetroShell.Utilities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace PaulozziCo.MetroShell.Presentation.Converters
{
    public class ValidationResultToTemplateConverter : ConverterBase<object, DataTemplate>
    {
        private static IDictionary<string, ResourceDictionary> _dictionaryCache = new Dictionary<string, ResourceDictionary>();

        public override DataTemplate Convert(object value, CultureInfo culture)
        {
            ValidationResult errorContent;
            if (!(value is ValidationError) && !(value is ValidationResult))
            {
                throw new ArgumentException(PresentationResources.ValidationResultToTemplateConverter_MustBeValidationResultOrValidationError, "value");
            }
            ResourceDictionary dictionary = GetDictionary(this.ResourceDictionaryPath);
            if (value is ValidationError)
            {
                ValidationError error = value as ValidationError;
                if (error.Exception != null)
                {
                    return (DataTemplate)dictionary["ExceptionTemplate"];
                }
                errorContent = error.ErrorContent as ValidationResult;
                if (errorContent != null)
                {
                    if (errorContent.Severity == ValidationSeverity.Warning)
                    {
                        return (DataTemplate)dictionary["WarningsTemplate"];
                    }
                    if (errorContent.Severity == ValidationSeverity.Informational)
                    {
                        return (DataTemplate)dictionary["InfosTemplate"];
                    }
                    if (errorContent.Severity == ValidationSeverity.Error)
                    {
                        return (DataTemplate)dictionary["ErrorsTemplate"];
                    }
                }
                return (DataTemplate)dictionary["DefaultTemplate"];
            }
            errorContent = value as ValidationResult;
            if (errorContent != null)
            {
                if (errorContent.Severity == ValidationSeverity.Warning)
                {
                    return (DataTemplate)dictionary["WarningsTemplateForValidationResult"];
                }
                if (errorContent.Severity == ValidationSeverity.Informational)
                {
                    return (DataTemplate)dictionary["InfosTemplateForValidationResult"];
                }
                if (errorContent.Severity == ValidationSeverity.Error)
                {
                    return (DataTemplate)dictionary["ErrorsTemplateForValidationResult"];
                }
            }
            return (DataTemplate)dictionary["DefaultTemplateForValidationResult"];
        }

        public static ResourceDictionary GetDictionary(string dictionaryName)
        {
            ResourceDictionary resourceDictionary;
            if (!_dictionaryCache.TryGetValue(dictionaryName, out resourceDictionary))
            {
                resourceDictionary = ResourceUtilities.GetResourceDictionary(dictionaryName);
                _dictionaryCache.Add(dictionaryName, resourceDictionary);
            }
            return resourceDictionary;
        }

        public string ResourceDictionaryPath { get; set; }
    }
}
