using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PaulozziCo.MetroShell.Presentation.Converters
{
    public abstract class IconConverterBase
    {
        #region Enums

        protected enum CollectionIconVisualState
        {
            Normal,
            MouseOver,
            Disabled
        }

        #endregion

        #region Constructors

        protected IconConverterBase() { }

        #endregion

        #region Protected Methods

        protected static CollectionIconVisualState GetVisualState(object parameter)
        {
            CollectionIconVisualState state;
            if (!Enum.TryParse<CollectionIconVisualState>(parameter as string, true, out state))
            {
                return CollectionIconVisualState.Normal;
            }
            return state;
        }

        protected static ImageSource TransformImage(ImageSource image, CollectionIconVisualState state)
        {
            switch (state)
            {
                case CollectionIconVisualState.Normal:
                    return ToGrayscale(image, 1.0);

                case CollectionIconVisualState.MouseOver:
                    return image;

                case CollectionIconVisualState.Disabled:
                    return ToGrayscale(image, 0.5);
            }
            return image;
        }

        #endregion

        #region Private Methods

        private static ImageSource ToGrayscale(ImageSource image, double opacity)
        {
            BitmapSource source = image as BitmapSource;
            if (source != null)
            {
                return ImageUtilities.ToGrayscale(source, opacity);
            }
            return image;
        }

        #endregion

    }
}
