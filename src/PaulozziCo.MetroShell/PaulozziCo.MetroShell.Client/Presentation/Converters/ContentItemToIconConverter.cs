using Microsoft.LightSwitch.Details;
using Microsoft.LightSwitch.Presentation;
using Microsoft.LightSwitch.Presentation.Framework.Helpers;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace PaulozziCo.MetroShell.Presentation.Converters
{
    public class ContentItemToIconConverter : IconConverterBase, IValueConverter
    {
        #region Constants

        private const string IconDirectory = "/PaulozziCo.MetroShell.Client;component/Presentation/Icons/";

        #endregion

        #region Fields

        private readonly static Uri IconAddSmall = new Uri(IconDirectory + "AddSmall.png", UriKind.Relative);

        private readonly static Uri IconAddSmallHover = new Uri(IconDirectory + "AddSmall_Hover.png", UriKind.Relative);

        private readonly static Uri IconDeleteSmall = new Uri(IconDirectory + "DeleteSmall.png", UriKind.Relative);

        private readonly static Uri IconDeleteSmallHover = new Uri(IconDirectory + "DeleteSmall_Hover.png", UriKind.Relative);

        private readonly static Uri IconEditSmall = new Uri(IconDirectory + "EditSmall.png", UriKind.Relative);

        private readonly static Uri IconEditSmallHover = new Uri(IconDirectory + "EditSmall_Hover.png", UriKind.Relative);

        private readonly static Uri IconRefreshSmall = new Uri(IconDirectory + "RefreshSmall.png", UriKind.Relative);

        private readonly static Uri IconRefreshSmallHover = new Uri(IconDirectory + "RefreshSmall_Hover.png", UriKind.Relative);

        #endregion

        #region Public Methods

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            IContentItem contentItem = (IContentItem)value;
            if (contentItem == null)
            {
                return null;
            }
            IconConverterBase.CollectionIconVisualState visualState = IconConverterBase.GetVisualState(parameter);
            object obj2 = null;
            if (contentItem.Properties.TryGetValue("Microsoft.LightSwitch:RootControl/Image", out obj2) && (obj2 != null))
            {
                return IconConverterBase.TransformImage(ImagePropertyHelper.GetImageSource(contentItem), visualState);
            }
            Uri iconForCommand = GetIconForCommand(contentItem, visualState);
            if (null == iconForCommand)
            {
                return IconConverterBase.TransformImage(ImagePropertyHelper.GetImageSource(contentItem), visualState);
            }
            return new BitmapImage(iconForCommand) { CreateOptions = BitmapCreateOptions.None };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        #endregion

        #region Private Methods

        private static Uri GetIconForCommand(IContentItem contentItem, IconConverterBase.CollectionIconVisualState visualState)
        {
            string str;
            ICommand details = contentItem.Details as ICommand;
            if ((details != null) && ((str = details.Name) != null))
            {
                if (str == "AddAndEditNew")
                {
                    if (visualState != IconConverterBase.CollectionIconVisualState.MouseOver)
                    {
                        return IconAddSmall;
                    }
                    return IconAddSmallHover;
                }
                if (str == "AddNew")
                {
                    if (visualState != IconConverterBase.CollectionIconVisualState.MouseOver)
                    {
                        return IconAddSmall;
                    }
                    return IconAddSmallHover;
                }
                if (str == "DeleteSelected")
                {
                    if (visualState != IconConverterBase.CollectionIconVisualState.MouseOver)
                    {
                        return IconDeleteSmall;
                    }
                    return IconDeleteSmallHover;
                }
                if (str == "EditSelected")
                {
                    if (visualState != IconConverterBase.CollectionIconVisualState.MouseOver)
                    {
                        return IconEditSmall;
                    }
                    return IconEditSmallHover;
                }
                if (str == "Refresh")
                {
                    if (visualState != IconConverterBase.CollectionIconVisualState.MouseOver)
                    {
                        return IconRefreshSmall;
                    }
                    return IconRefreshSmallHover;
                }
                if (str == "RemoveSelected")
                {
                    if (visualState != IconConverterBase.CollectionIconVisualState.MouseOver)
                    {
                        return IconDeleteSmall;
                    }
                    return IconDeleteSmallHover;
                }
            }
            return null;
        }

        #endregion

    }
}
