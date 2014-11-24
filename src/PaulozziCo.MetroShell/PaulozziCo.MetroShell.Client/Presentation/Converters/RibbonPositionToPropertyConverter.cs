using System;
using System.Windows.Data;
using PaulozziCo.MetroShell.Model;
using PaulozziCo.MetroShell.Utilities;

namespace PaulozziCo.MetroShell.Presentation.Converters
{
    public class RibbonPositionToPropertyConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            object result = new object();

            if (targetType == typeof(System.Int32))
            {
                if (value == null) return 2;
                else
                {
                    int gridRow = 2;

                    RibbonPosition val = (RibbonPosition)value;

                    if (val == RibbonPosition.Top)
                        gridRow = 0;

                    result = gridRow;
                }
            }

            if (targetType == typeof(System.Nullable<Boolean>))
            {
                if (value == null) return true;
                else
                {
                    Boolean boolPosition = true;
                    RibbonPosition val = (RibbonPosition)value;

                    if (val == RibbonPosition.Top)
                        boolPosition = false;

                    result = boolPosition;
                }
            }

            if (targetType == typeof(System.Windows.Thickness))
            {
                if (value == null) return new System.Windows.Thickness(0, 0, 0, 10);
                else
                {
                    System.Windows.Thickness margin = new System.Windows.Thickness(0, 0, 0, 10);
                    RibbonPosition val = (RibbonPosition)value;

                    if (val == RibbonPosition.Top)
                        margin = new System.Windows.Thickness(0, 10, 0, 0);

                    result = margin;
                }
            }

            if (targetType == typeof(System.String))
            {
                if (value == null) return String.Empty;
                else
                {
                    string text = String.Empty;
                    RibbonPosition val = (RibbonPosition)value;

                    switch (CultureHelper.CurrentCultureLenguage)
                    {
                        case CultureHelper.CultureLeguage.EN:
                            text = val == RibbonPosition.Top ? "Top" : "Button";
                            break;
                        case CultureHelper.CultureLeguage.PT:
                            text = val == RibbonPosition.Top ? "Acima" : "Abaixo";
                            break;
                        case CultureHelper.CultureLeguage.ES:
                            text = val == RibbonPosition.Top ? "Encima" : "Debajo";
                            break;
                        case CultureHelper.CultureLeguage.DE:
                            text = val == RibbonPosition.Top ? "Top" : "Taste";
                            break;
                        default:
                            text = val == RibbonPosition.Top ? "Top" : "Button";
                            break;
                    }

                    result = text;
                }
            }

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            object result = new object();

            if (targetType == typeof(RibbonPosition))
            {
                if (value == null) return true;
                else
                {
                    RibbonPosition position = RibbonPosition.Button;
                    Boolean val = (Boolean)value;

                    if (!val)
                        position = RibbonPosition.Top;

                    result = position;
                }
            }

            return result;
        }
    }
}
