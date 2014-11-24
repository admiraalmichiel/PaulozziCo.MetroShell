using Microsoft.LightSwitch.Presentation.Implementation.Controls;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace PaulozziCo.MetroShell.Presentation.Converters
{
    public class ExtendedCommandToIconConverter : IconConverterBase, IValueConverter
    {
        private const string IconDirectory = "/PaulozziCo.MetroShell.Client;component/Presentation/Icons/";
        private readonly static Uri IconExcelSmall = new Uri(IconDirectory + "ExcelSmall.png", UriKind.Relative);
        private readonly static Uri IconExcelSmallHover = new Uri(IconDirectory + "ExcelSmall_Hover.png", UriKind.Relative);

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            IControlExtendedCommand command = value as IControlExtendedCommand;
            if (command == null)
            {
                return null;
            }
            IconConverterBase.CollectionIconVisualState visualState = IconConverterBase.GetVisualState(parameter);
            if (command is ExportCollectionDataCommand)
            {
                return new BitmapImage((visualState == IconConverterBase.CollectionIconVisualState.MouseOver) ? IconExcelSmallHover : IconExcelSmall) { CreateOptions = BitmapCreateOptions.None };
            }
            return IconConverterBase.TransformImage(command.Image, visualState);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
