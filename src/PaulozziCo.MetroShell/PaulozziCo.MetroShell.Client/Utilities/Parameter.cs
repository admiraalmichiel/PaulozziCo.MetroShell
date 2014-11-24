using System;

namespace PaulozziCo.MetroShell.Utilities
{
    internal static class Parameter
    {
        public static void ThrowIfNotNullAndNotOfType<T>(object parameter, string parameterName)
        {
            if (parameter != null)
            {
                ThrowIfNotOfType<T>(parameter, parameterName);
            }
        }

        public static void ThrowIfNotOfType<T>(object parameter, string parameterName)
        {
            if (!(parameter is T))
            {
                throw new ArgumentException(parameterName);
            }
        }

        public static void ThrowIfNull(object parameter, string parameterName)
        {
            if (parameter == null)
            {
                throw new ArgumentNullException(parameterName);
            }
        }
    }
}
