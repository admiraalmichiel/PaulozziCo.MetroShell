using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.ComponentModel;

namespace PaulozziCo.MetroShell.Model
{
    public class ThemeColorPalette : DependencyObject, INotifyPropertyChanged
    {

        public static readonly DependencyProperty BackgroudStyleProperty =
                        DependencyProperty.Register("BackgroudStyle", typeof(BackgroudColorStyle), typeof(ThemeColorPalette),
                        new PropertyMetadata(BackgroudColorStyle.Light, OnBackgroudStyleChanged));

        private static void OnBackgroudStyleChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            ThemeColorPalette themeColorPalette = o as ThemeColorPalette;
            if (themeColorPalette != null)
                themeColorPalette.OnBackgroudStyleChanged((BackgroudColorStyle)e.OldValue, (BackgroudColorStyle)e.NewValue);
        }

        protected virtual void OnBackgroudStyleChanged(BackgroudColorStyle oldValue, BackgroudColorStyle newValue)
        {
            InvalidadeDymanicColors();
        }

        public BackgroudColorStyle BackgroudStyle
        {
            get { return (BackgroudColorStyle)GetValue(BackgroudStyleProperty); }
            set { SetValue(BackgroudStyleProperty, value); }
        }

        public static readonly DependencyProperty AccentColorProperty =
            DependencyProperty.Register("AccentColor", typeof(Color), typeof(ThemeColorPalette), new PropertyMetadata(Color.FromArgb(0xff, 0x00, 0x82, 0x87)));

        public static readonly DependencyProperty BasicColorProperty = 
            DependencyProperty.Register("BasicColor", typeof(Color), typeof(ThemeColorPalette), new PropertyMetadata(Color.FromArgb(0xff, 0xd6, 0xd4, 0xd4)));

        private static IList<DependencyProperty> colorProperties = 
            new List<DependencyProperty> 
            { 
                AccentColorProperty, 
                BasicColorProperty, 
                StrongColorProperty, 
                MainColorProperty, 
                MarkerColorProperty, 
                ValidationColorProperty,
                NavigationAccentColorProperty,
                BackgroundAccentColorProperty,
                SecundaryAccentColorProperty
            };

        public static readonly DependencyProperty MainColorProperty = 
            DependencyProperty.Register("MainColor", typeof(Color), typeof(ThemeColorPalette), new PropertyMetadata(Color.FromArgb(0xff, 0xff, 0xff, 0xff)));

        public static readonly DependencyProperty MarkerColorProperty = 
            DependencyProperty.Register("MarkerColor", typeof(Color), typeof(ThemeColorPalette), new PropertyMetadata(Color.FromArgb(0xff, 0, 0, 0)));

        public static readonly DependencyProperty StrongColorProperty = 
            DependencyProperty.Register("StrongColor", typeof(Color), typeof(ThemeColorPalette), new PropertyMetadata(Color.FromArgb(0xff, 0x76, 0x76, 0x76)));

        public static readonly DependencyProperty ValidationColorProperty = 
            DependencyProperty.Register("ValidationColor", typeof(Color), typeof(ThemeColorPalette), new PropertyMetadata(Color.FromArgb(0xff, 0xde, 0x39, 20)));

        public static readonly DependencyProperty NavigationAccentColorProperty =
            DependencyProperty.Register("NavigationAccentColor", typeof(Color), typeof(ThemeColorPalette), new PropertyMetadata(Color.FromArgb(0xff, 0x00, 0x4D, 0x60)));

        public static readonly DependencyProperty BackgroundAccentColorProperty =
            DependencyProperty.Register("BackgroundAccentColor", typeof(Color), typeof(ThemeColorPalette), new PropertyMetadata(Color.FromArgb(0xff, 0x00, 0x40, 0x50)));

        public static readonly DependencyProperty SecundaryAccentColorProperty =
            DependencyProperty.Register("SecundaryAccentColor", typeof(Color), typeof(ThemeColorPalette), new PropertyMetadata(Color.FromArgb(0xff, 0x30, 0x67, 0x72)));

        internal ThemeColorPalette()
        {
        }

        internal static DependencyProperty GetColorProperty(ThemeColorType color)
        {
            return colorProperties[(int) color];
        }
        
        public Color AccentColor
        {
            get
            {
                return (Color) base.GetValue(AccentColorProperty);
            }
            set
            {
                base.SetValue(AccentColorProperty, value);
                InvalidadeDymanicColors();
            }
        }
        
        public Color BasicColor
        {
            get
            {
                return (Color) base.GetValue(BasicColorProperty);
            }
            set
            {
                base.SetValue(BasicColorProperty, value);
            }
        }
        
        public Color MainColor
        {
            get
            {
                return (Color) base.GetValue(MainColorProperty);
            }
            set
            {
                base.SetValue(MainColorProperty, value);
                InvalidadeDymanicColors();
            }
        }
        
        public Color MarkerColor
        {
            get
            {
                return (Color) base.GetValue(MarkerColorProperty);
            }
            set
            {
                base.SetValue(MarkerColorProperty, value);
                InvalidadeDymanicColors();
            }
        }
        
        public Color StrongColor
        {
            get
            {
                return (Color) base.GetValue(StrongColorProperty);
            }
            set
            {
                base.SetValue(StrongColorProperty, value);
            }
        }
        
        public Color ValidationColor
        {
            get
            {
                return (Color) base.GetValue(ValidationColorProperty);
            }
            set
            {
                base.SetValue(ValidationColorProperty, value);
            }
        }

        public Color NavigationAccentColor
        {
            get
            {
                return (Color)base.GetValue(NavigationAccentColorProperty);
            }
            set
            {
                base.SetValue(NavigationAccentColorProperty, value);
                InvalidadeDymanicColors();
            }
        }

        public Color BackgroundAccentColor
        {
            get
            {
                return (Color)base.GetValue(BackgroundAccentColorProperty);
            }
            set
            {
                base.SetValue(BackgroundAccentColorProperty, value);
                InvalidadeDymanicColors();
            }
        }

        public Color SecundaryAccentColor
        {
            get
            {
                return (Color)base.GetValue(SecundaryAccentColorProperty);
            }
            set
            {
                base.SetValue(SecundaryAccentColorProperty, value);
                InvalidadeDymanicColors();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected new virtual void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private void InvalidadeDymanicColors()
        {
            RaisePropertyChanged("DynamicBackgroundColor");
            RaisePropertyChanged("DynamicNavigationColor");
            RaisePropertyChanged("DynamicMarkerColor");
            RaisePropertyChanged("DynamicControlBackgroundColor");
        }

        public Color DynamicBackgroundColor
        {
            get
            {
                switch (BackgroudStyle)
                {
                    case BackgroudColorStyle.Light:
                        return this.MainColor;
                    case BackgroudColorStyle.Dark:
                        return this.BackgroundAccentColor;
                }

                return this.MainColor;
            }
        }

        public Color DynamicControlBackgroundColor
        {
            get
            {
                switch (BackgroudStyle)
                {
                    case BackgroudColorStyle.Light:
                        return this.MainColor;
                    case BackgroudColorStyle.Dark:
                        return this.SecundaryAccentColor;
                }

                return this.MainColor;
            }
        }

        public Color DynamicNavigationColor
        {
            get
            {
                switch (BackgroudStyle)
                {
                    case BackgroudColorStyle.Light:
                        return this.MainColor;
                    case BackgroudColorStyle.Dark:
                        return this.NavigationAccentColor;
                }

                return this.MainColor;
            }
        }

        public Color DynamicMarkerColor
        {
            get
            {
                switch (BackgroudStyle)
                {
                    case BackgroudColorStyle.Light:
                        return this.MarkerColor;
                    case BackgroudColorStyle.Dark:
                        return this.MainColor;
                }

                return this.MainColor;
            }
        }
    }
}