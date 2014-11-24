using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PaulozziCo.MetroShell.Presentation.Converters
{
    internal static class ImageUtilities
    {
        #region Fields

        private static int DefaultImageSize = 0x20;

        private static double DefaultOpacityMask = 1.0;

        #endregion

        #region Public Methods

        public static BitmapSource ToGrayscale(BitmapSource source)
        {
            return ToGrayscale(source, DefaultImageSize, DefaultOpacityMask);
        }

        public static BitmapSource ToGrayscale(BitmapSource source, int imageSize)
        {
            return ToGrayscale(source, imageSize, DefaultOpacityMask);
        }

        public static BitmapSource ToGrayscale(BitmapSource source, double opacityMask)
        {
            return ToGrayscale(source, DefaultImageSize, opacityMask);
        }

        #endregion

        #region Private Methods

        private static BitmapSource ToGrayscale(BitmapSource source, int imageSize, double opacityMask)
        {
            int pixelWidth = (source.PixelHeight > 0) ? source.PixelHeight : imageSize;
            int pixelHeight = (source.PixelWidth > 0) ? source.PixelWidth : imageSize;
            Image element = new Image
            {
                Opacity = opacityMask,
                Source = source
            };
            WriteableBitmap bitmap = new WriteableBitmap(pixelWidth, pixelHeight);
            bitmap.Render(element, null);
            bitmap.Invalidate();
            for (int i = 0; i < bitmap.PixelHeight; i++)
            {
                for (int j = 0; j < bitmap.PixelWidth; j++)
                {
                    int index = (i * bitmap.PixelWidth) + j;
                    int num6 = bitmap.Pixels[index];
                    Color color = Color.FromArgb((byte)((num6 >> 0x18) & 0xff), (byte)((num6 >> 0x10) & 0xff), (byte)((num6 >> 8) & 0xff), (byte)(num6 & 0xff));
                    int num7 = ((color.R + color.G) + color.B) / 3;
                    bitmap.Pixels[index] = (((color.A << 0x18) | (num7 << 0x10)) | (num7 << 8)) | num7;
                }
            }
            return bitmap;
        }

        #endregion

    }
}
