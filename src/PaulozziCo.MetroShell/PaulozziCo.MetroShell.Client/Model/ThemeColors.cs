using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace PaulozziCo.MetroShell.Model
{
    public class ThemeColors
    {
        public static readonly DependencyProperty ColorProperty =
            DependencyProperty.RegisterAttached("Color", typeof(ThemeColorType), typeof(ThemeColors),
            new PropertyMetadata(ThemeColorType.NonWindows8, new PropertyChangedCallback(ThemeColors.OnColorPropertyChanged)));

        private static ThemeColorPalette palette;

        public static ThemeColorType GetColor(DependencyObject obj)
        {
            return (ThemeColorType)obj.GetValue(ColorProperty);
        }

        private static DependencyProperty GetColorProeprty(DependencyObject freezable)
        {
            DependencyProperty colorProperty = null;
            if (freezable is SolidColorBrush)
            {
                return SolidColorBrush.ColorProperty;
            }
            if (freezable is GradientStop)
            {
                colorProperty = GradientStop.ColorProperty;
            }
            return colorProperty;
        }

        private static void OnColorPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs args)
        {
            ThemeColorType oldValue = (ThemeColorType)args.OldValue;
            ThemeColorType newValue = (ThemeColorType)args.NewValue;
            if (oldValue != ThemeColorType.NonWindows8)
            {
                throw new InvalidOperationException();
            }
            Update(d, (ThemeColorType)args.NewValue);
        }

        public static void SetColor(DependencyObject obj, ThemeColorType value)
        {
            obj.SetValue(ColorProperty, value);
        }

        private static void Update(DependencyObject dependencyObject, ThemeColorType color)
        {
            try
            {
                if (color != ThemeColorType.BoundColor)
                {
                    GetColorProeprty(dependencyObject);
                    Binding binding = new Binding(color.ToString() + "Color")
                    {
                        Source = PaletteInstance
                    };
                    BindingOperations.SetBinding(dependencyObject, SolidColorBrush.ColorProperty, binding);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        public ThemeColorPalette Palette
        {
            get
            {
                return PaletteInstance;
            }
        }

        public static ThemeColorPalette PaletteInstance
        {
            get
            {
                if (palette == null)
                {
                    palette = new ThemeColorPalette();
                }
                return palette;
            }
        }
    }
}
