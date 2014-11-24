using Microsoft.LightSwitch.Details.Client;
using Microsoft.LightSwitch.Runtime.Shell.ViewModels.Commands;
using Microsoft.LightSwitch.Runtime.Shell.ViewModels.Implementation.Commands;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PaulozziCo.MetroShell.Presentation.Converters
{
    /// <summary>
    /// Utility converter that replaces the built-in ribbon icons with metro-styled images. The converter
    /// also converts images into a disabled state as appropriate since LightSwitch does not provide developers
    /// with a way to provide their own icons for disabled states.
    /// </summary>
    public class RibbonIconConverter : IValueConverter
    {
        #region Enums

        private enum ImageStates
        {
            Normal,
            Small,
            MouseOver,
            SmallMouseOver,
            Disabled,
            SmallDisabled
        }

        #endregion

        #region Constants

        private const string IconDirectory = "/PaulozziCo.MetroShell.Client;component/Presentation/Icons/";

        #endregion

        #region Fields

        private readonly static double DefaultOpacityMask = 0.5;

        private readonly static Uri IconCustomizeLarge = new Uri(IconDirectory + "CustomizeScreenLarge.png", UriKind.Relative);

        private readonly static Uri IconCustomizeLargeHover = new Uri(IconDirectory + "CustomizeScreenLarge_Hover.png", UriKind.Relative);

        private readonly static Uri IconCustomizeSmall = new Uri(IconDirectory + "CustomizeScreenSmall.png", UriKind.Relative);

        private readonly static Uri IconCustomizeSmallHover = new Uri(IconDirectory + "CustomizeScreenSmall_Hover.png", UriKind.Relative);

        private readonly static Uri IconPlaceholderLarge = new Uri(IconDirectory + "PlaceholderLarge.png", UriKind.Relative);

        private readonly static Uri IconPlaceholderLargeHover = new Uri(IconDirectory + "PlaceholderLarge_Hover.png", UriKind.Relative);

        private readonly static Uri IconPlaceholderSmall = new Uri(IconDirectory + "PlaceholderSmall.png", UriKind.Relative);

        private readonly static Uri IconPlaceholderSmallHover = new Uri(IconDirectory + "PlaceholderSmall_Hover.png", UriKind.Relative);

        private readonly static Uri IconRefreshLarge = new Uri(IconDirectory + "RefreshLarge.png", UriKind.Relative);

        private readonly static Uri IconRefreshLargeHover = new Uri(IconDirectory + "RefreshLarge_Hover.png", UriKind.Relative);

        private readonly static Uri IconRefreshSmall = new Uri(IconDirectory + "RefreshSmall.png", UriKind.Relative);

        private readonly static Uri IconRefreshSmallHover = new Uri(IconDirectory + "RefreshSmall_Hover.png", UriKind.Relative);

        private readonly static Uri IconSaveLarge = new Uri(IconDirectory + "SaveLarge.png", UriKind.Relative);

        private readonly static Uri IconSaveLargeHover = new Uri(IconDirectory + "SaveLarge_Hover.png", UriKind.Relative);

        private readonly static Uri IconSaveSmall = new Uri(IconDirectory + "SaveSmall.png", UriKind.Relative);

        private readonly static Uri IconSaveSmallHover = new Uri(IconDirectory + "SaveSmallHover.png", UriKind.Relative);

        private readonly static List<string> methosNames = new List<string>() { "Save", "Refresh", "CustomizeScreen" };

        #endregion

        #region Public Methods

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ImageStates imageState = ParseImageState(parameter);
            IShellCommand shellCommand = value as IShellCommand;

            object obj2 = DetermineImageSourceForCommand(shellCommand, imageState);

            switch (imageState)
            {
                case ImageStates.MouseOver:
                case ImageStates.SmallMouseOver:
                    return obj2;
            }

            //double opacityMask = ((imageState == ImageStates.Disabled) || (imageState == ImageStates.SmallDisabled)) ? DefaultOpacityMask : 1.0;
            Uri uriSource = obj2 as Uri;
            if (uriSource != null)
            {
                BitmapImage image = new BitmapImage(uriSource)
                {
                    CreateOptions = BitmapCreateOptions.None
                };
                //return ImageUtilities.ToGrayscale(image, opacityMask);
                return image;
            }
            BitmapSource source = obj2 as BitmapSource;
            if (source != null)
            {
                //return ImageUtilities.ToGrayscale(source, opacityMask);
                return source;
            }
            return obj2;
        }

        #endregion

        #region Private Methods

        private static object DetermineImageSourceForCommand(IShellCommand shellCommand, ImageStates imageState)
        {
            PlaceholderCommand command = shellCommand as PlaceholderCommand;
            if (command != null)
            {
                return GetIconUriForMethod(command.ScreenMethodName, shellCommand, imageState);
            }
            if (shellCommand == null)
            {
                return null;
            }
            IScreenCommand executableObject = shellCommand.ExecutableObject as IScreenCommand;
            if (executableObject != null)
            {
                return GetIconUriForMethod(executableObject.GetModel().Name, shellCommand, imageState);
            }
            if (shellCommand.Group == ShellCommandGroupNames.Customize)
            {
                return GetIconUriForMethod("CustomizeScreen", shellCommand, imageState);
            }
            if (shellCommand.Image == null)
            {
                return GetIconUriForMethod("Placeholder", shellCommand, imageState);
            }
            return shellCommand.Image;
        }

        private static object GetIconUriForMethod(string methodName, IShellCommand command, ImageStates imageState)
        {
            switch (methodName)
            {
                case "Save":
                    if (imageState == ImageStates.MouseOver)
                    {
                        return IconSaveLargeHover;
                    }
                    if (imageState == ImageStates.SmallMouseOver)
                    {
                        return IconSaveSmallHover;
                    }
                    if ((imageState != ImageStates.Small) && (imageState != ImageStates.SmallDisabled))
                    {
                        return IconSaveLarge;
                    }
                    return IconSaveSmall;

                case "Refresh":
                    if (imageState == ImageStates.MouseOver)
                    {
                        return IconRefreshLargeHover;
                    }
                    if (imageState == ImageStates.SmallMouseOver)
                    {
                        return IconRefreshSmallHover;
                    }
                    if ((imageState != ImageStates.Small) && (imageState != ImageStates.SmallDisabled))
                    {
                        return IconRefreshLarge;
                    }
                    return IconRefreshSmall;

                case "CustomizeScreen":
                    if (imageState == ImageStates.MouseOver)
                    {
                        return IconCustomizeLargeHover;
                    }
                    if (imageState == ImageStates.SmallMouseOver)
                    {
                        return IconCustomizeSmallHover;
                    }
                    if ((imageState != ImageStates.Small) && (imageState != ImageStates.SmallDisabled))
                    {
                        return IconCustomizeLarge;
                    }
                    return IconCustomizeSmall;
            }
            if (command.Image != null)
            {
                return command.Image;
            }
            if (imageState == ImageStates.MouseOver)
            {
                return IconPlaceholderLargeHover;
            }
            if (imageState == ImageStates.SmallMouseOver)
            {
                return IconPlaceholderSmallHover;
            }
            if ((imageState != ImageStates.Small) && (imageState != ImageStates.SmallDisabled))
            {
                return IconPlaceholderLarge;
            }
            return IconPlaceholderSmall;
        }

        private static ImageStates ParseImageState(object parameter)
        {
            if (parameter != null)
            {
                switch (parameter.ToString().ToUpperInvariant())
                {
                    case "MOUSEOVER":
                        return ImageStates.MouseOver;

                    case "NORMAL":
                        return ImageStates.Normal;

                    case "DISABLED":
                        return ImageStates.Disabled;

                    case "SMALL":
                        return ImageStates.Small;

                    case "SMALLMOUSEOVER":
                        return ImageStates.SmallMouseOver;

                    case "SMALLDISABLED":
                        return ImageStates.SmallDisabled;
                }
            }
            return ImageStates.Normal;
        }

        #endregion

    }
}
