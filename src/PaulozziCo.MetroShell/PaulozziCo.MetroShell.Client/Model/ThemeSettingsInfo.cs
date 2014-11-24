using System;
using System.Windows;

namespace PaulozziCo.MetroShell.Model
{
    public class ThemeSettingsInfo : DependencyObject
    {
        public static readonly DependencyProperty RibbonPositionValueProperty =
                                DependencyProperty.Register("RibbonPositionValue",
                                typeof(RibbonPosition), typeof(ThemeSettingsInfo),
                                new PropertyMetadata(RibbonPosition.Button));

        public static readonly DependencyProperty ShowCloseEffectProperty =
                                DependencyProperty.Register("ShowCloseEffect",
                                typeof(bool), typeof(ThemeSettingsInfo),
                                new PropertyMetadata(true));

        public static readonly DependencyProperty ShowOpenEffectProperty =
                                DependencyProperty.Register("ShowOpenEffect",
                                typeof(bool), typeof(ThemeSettingsInfo),
                                new PropertyMetadata(true));

        public static readonly DependencyProperty ShowPageChangeEffectProperty =
                                DependencyProperty.Register("ShowPageChangeEffect",
                                typeof(bool), typeof(ThemeSettingsInfo),
                                new PropertyMetadata(true));

        public static readonly DependencyProperty ShowScreenTitleProperty =
                                DependencyProperty.Register("ShowScreenTitle",
                                typeof(bool), typeof(ThemeSettingsInfo),
                                new PropertyMetadata(true));

        /// <summary>
        /// Initializes a new instance of the SerializebleThemeServices class.
        /// </summary>
        public ThemeSettingsInfo()
        {

        }

        /// <summary>
        /// Initializes a new instance of the SerializebleThemeServices class.
        /// </summary>
        /// <param name="_ribbonPosition"></param>
        /// <param name="currentTheme"></param>
        /// <param name="showPageChangeEffect"></param>
        /// <param name="showCloseEffect"></param>
        /// <param name="showOpenEffect"></param>
        /// <param name="showScreenTitle"></param>
        /// <param name="themeBackgroudStyleIndex"></param>
        public ThemeSettingsInfo(RibbonPosition ribbonPosition,
            bool showPageChangeEffect,
            bool showCloseEffect,
            bool showOpenEffect,
            bool showScreenTitle)
        {
            RibbonPositionValue = ribbonPosition;
            ShowPageChangeEffect = showPageChangeEffect;
            ShowCloseEffect = showCloseEffect;
            ShowOpenEffect = showOpenEffect;
            ShowScreenTitle = showScreenTitle;
        }

        public RibbonPosition RibbonPositionValue
        {
            get
            {
                try
                {
                    return (RibbonPosition)GetValue(RibbonPositionValueProperty);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return RibbonPosition.Button;
                }
            }
            set { SetValue(RibbonPositionValueProperty, value); }
        }

        public bool ShowCloseEffect
        {
            get { return (bool)GetValue(ShowCloseEffectProperty); }
            set { SetValue(ShowCloseEffectProperty, value); }
        }

        public bool ShowOpenEffect
        {
            get { return (bool)GetValue(ShowOpenEffectProperty); }
            set { SetValue(ShowOpenEffectProperty, value); }
        }

        public bool ShowPageChangeEffect
        {
            get { return (bool)GetValue(ShowPageChangeEffectProperty); }
            set { SetValue(ShowPageChangeEffectProperty, value); }
        }

        public bool ShowScreenTitle
        {
            get { return (bool)GetValue(ShowScreenTitleProperty); }
            set { SetValue(ShowScreenTitleProperty, value); }
        }

    }
}
