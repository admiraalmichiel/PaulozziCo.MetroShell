using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Media.Animation;
using Microsoft.LightSwitch.Runtime.Shell.Implementation;

namespace PaulozziCo.MetroShell.Presentation.Controls
{
    /// <summary>
    /// Defines a wrapper for the <see cref="Popup"/> class that implements the <see cref="IWindow"/> interface.
    /// </summary>
    [TemplatePart(Name = "CloseButtonTemplate", Type = typeof(Button))]
    public class PopupWrapper : Control
    {
        public static readonly DependencyProperty CloseButtonMarginProperty =
                        DependencyProperty.Register("CloseButtonMargin", typeof(Thickness), typeof(PopupWrapper),
                        new PropertyMetadata(new Thickness(36, 36, 0, 0), OnCloseButtonMarginChanged));

        private static void OnCloseButtonMarginChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            PopupWrapper popupWrapper = o as PopupWrapper;
            if (popupWrapper != null)
                popupWrapper.OnCloseButtonMarginChanged((Thickness)e.OldValue, (Thickness)e.NewValue);
        }

        protected virtual void OnCloseButtonMarginChanged(Thickness oldValue, Thickness newValue)
        {
            if (newValue != null && closeButton != null)
            {
                closeButton.Margin = newValue;
            }
        }

        public Thickness CloseButtonMargin
        {
            get { return (Thickness)GetValue(CloseButtonMarginProperty); }
            set { SetValue(CloseButtonMarginProperty, value); }
        }
        
        

        #region Fields

        private readonly Grid _outsideGrid;

        private Storyboard _storyboardAfterIn;

        private Storyboard _StoryboardIn;

        private Button closeButton;

        private readonly ContentControl container;

        private FrameworkElement owner;

        private readonly Popup popUp;

        private ContentControl splash;

        private readonly static PlaneProjection startProjection = new PlaneProjection() { CenterOfRotationX = 1, RotationX = 0, RotationY = 45 };

        #endregion

        #region Events

        /// <summary>
        /// Ocurrs when the <see cref="Popup"/> is closed.
        /// </summary>
        public event EventHandler Closed
        {
            add { this.popUp.Closed += value; }
            remove { this.popUp.Closed -= value; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of <see cref="PopupWrapper"/>.
        /// </summary>
        public PopupWrapper()
        {
            this.container = new ContentControl()
            {
                VerticalContentAlignment = System.Windows.VerticalAlignment.Stretch,
                HorizontalContentAlignment = System.Windows.HorizontalAlignment.Stretch
            };

            splash = new ContentControl()
            {
                VerticalAlignment = System.Windows.VerticalAlignment.Stretch,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch,
                VerticalContentAlignment = System.Windows.VerticalAlignment.Stretch,
                HorizontalContentAlignment = System.Windows.HorizontalAlignment.Stretch,
                RenderTransformOrigin = new Point(0.5, 0.5)
            };

            closeButton = new Button()
            {
                VerticalAlignment = System.Windows.VerticalAlignment.Top,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Left,
                Height = 40,
                Width = 40,
                Margin = CloseButtonMargin
            };

            closeButton.Click += (o, t) => { this.Close(); };

            _outsideGrid = new Grid();
            _outsideGrid.Children.Add(container);
            _outsideGrid.Children.Add(closeButton);
            _outsideGrid.Children.Add(splash);

            this.popUp = new Popup()
            {
                Child = _outsideGrid
            };

            App.Current.Host.Content.Resized += (s, e) => { UpdateSize(); };

            CreateAnimation();

            UpdateSize();
        }

        #endregion

        #region Properties

        public ControlTemplate CloseButtonTemplate
        {
            get
            {
                return this.closeButton.Template;
            }
            set
            {
                if (value != null)
                    this.closeButton.Template = value;
            }
        }

        /// <summary>
        /// Gets or Sets the content for the <see cref="Popup"/>.
        /// </summary>
        public object Content
        {
            get
            {
                return this.container.Content;
            }

            set
            {
                if (value != null)
                {
                    this.container.Content = value;
                }
                else
                {
                    this.container.Content = null;
                    this.popUp.Child = null;
                }
            }
        }

        /// <summary>
        /// Gets or sets the owner of the <see cref="Popup"/> which is used for resizing.
        /// </summary>
        public object Owner
        {
            get { return this.owner; }

            set
            {
                if (this.owner != null)
                {
                    this.owner.SizeChanged -= this.OwnerSizeChanged;
                }

                this.owner = value as FrameworkElement;
                if (this.owner != null)
                {
                    UpdateSize();
                    this.owner.SizeChanged += this.OwnerSizeChanged;
                }
            }
        }

        public object SplashContent
        {
            get { return this.splash.Content; }

            set
            {
                if (value != null)
                {
                    this.splash.Content = value;
                }
                else
                {
                    this.splash.Content = null;
                }
            }
        }

        /// <summary>
        /// Gets or Sets the <see cref="FrameworkElement.Style"/> to apply to the <see cref="Popup"/>.
        /// </summary>
        public Style Style
        {
            get { return this.container.Style; }
            set { this.container.Style = value; }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Closes the <see cref="Popup"/>.
        /// </summary>
        public void Close()
        {
            this.popUp.IsOpen = false;
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            closeButton = base.GetTemplateChild("CloseButtonTemplate") as Button;
        }

        /// <summary>
        /// Opens the <see cref="Popup"/>.
        /// </summary>
        public void Show()
        {
            this.popUp.IsOpen = true;
            ShowSplash();
        }

        #endregion

        #region Private Methods

        private void CreateAnimation()
        {
            CircleEase _CircleEase = new CircleEase() { EasingMode = EasingMode.EaseInOut };

            DoubleAnimationUsingKeyFrames compositeTransformIn = new DoubleAnimationUsingKeyFrames();
            compositeTransformIn.KeyFrames.Add(new EasingDoubleKeyFrame { KeyTime = TimeSpan.Zero, Value = 45 });
            compositeTransformIn.KeyFrames.Add(new EasingDoubleKeyFrame { KeyTime = TimeSpan.FromMilliseconds(600), Value = 0, EasingFunction = _CircleEase });

            Storyboard.SetTargetProperty(compositeTransformIn, new PropertyPath("(UIElement.Projection).(PlaneProjection.RotationY)"));
            Storyboard.SetTarget(compositeTransformIn, splash);

            DoubleAnimation opacityAnimationAfterIn = new DoubleAnimation() { Duration = TimeSpan.FromMilliseconds(200), From = 1, To = 0 };
            Storyboard.SetTargetProperty(opacityAnimationAfterIn, new PropertyPath("Opacity"));
            Storyboard.SetTarget(opacityAnimationAfterIn, splash);

            _StoryboardIn = new Storyboard();
            _storyboardAfterIn = new Storyboard();

            _StoryboardIn.Children.Add(compositeTransformIn);
            _storyboardAfterIn.Children.Add(opacityAnimationAfterIn);

            _StoryboardIn.Completed += (o, t) =>
            {
                container.Opacity = 1;
                closeButton.Opacity = 1;
                _storyboardAfterIn.Begin();
            };

            _storyboardAfterIn.Completed += (o, t) =>
            {
                this.splash.Visibility = System.Windows.Visibility.Collapsed;
            };
        }

        private void OwnerSizeChanged(object sender, SizeChangedEventArgs e)
        {
            UpdateSize();
        }

        private void ShowSplash()
        {
            container.Opacity = 0;
            closeButton.Opacity = 0;
            splash.Visibility = System.Windows.Visibility.Visible;
            splash.Opacity = 1;
            splash.Projection = startProjection;
            this._StoryboardIn.Begin();
        }

        private void UpdateSize()
        {
            if (this.container != null)
            {
                this.container.Width = App.Current.Host.Content.ActualWidth;
                this.container.Height = App.Current.Host.Content.ActualHeight;
            }
        }

        #endregion

    }
}
