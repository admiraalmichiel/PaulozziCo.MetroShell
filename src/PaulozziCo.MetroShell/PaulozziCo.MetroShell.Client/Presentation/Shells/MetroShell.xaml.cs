using Microsoft.LightSwitch.BaseServices.Notifications;
using Microsoft.LightSwitch.Runtime.Shell;
using Microsoft.LightSwitch.Runtime.Shell.Implementation.Standard;
using PaulozziCo.MetroShell.Model;
using PaulozziCo.MetroShell.Services;
using PaulozziCo.MetroShell.Utilities;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace PaulozziCo.MetroShell.Presentation.Shells
{
    public partial class MetroShell : UserControl
    {

        #region Fields

        private bool _isCompressedViewMode;

        private int _screenCount;

        private Storyboard _StoryboardIn;

        private Storyboard _StoryboardOut;

        private Storyboard _StoryboardViewChange;

        private double mainContentGridColumn_0_Width;

        private static CompositeTransform startPosition = new CompositeTransform() { TranslateX = -30, TranslateY = 0 };

        #endregion

        #region Constructors

        public MetroShell()
        {
            InitializeComponent();

            ThemeMenager.RestoreUserConfiguration();

            ContentPresenteControl.RenderTransformOrigin = new Point(0.5, 0.5);

            CreateAnimation();

            this.chkIsCompressedViewMode.Checked += (o, t) =>
            {
                IsCompressedViewMode = this.chkIsCompressedViewMode.IsChecked.Value;
            };
            this.chkIsCompressedViewMode.Unchecked += (o, t) =>
            {
                IsCompressedViewMode = this.chkIsCompressedViewMode.IsChecked.Value;
            };

            ServiceProxy.Instance.UserSettingsService.Closing += (o, t) =>
            {
                ServiceProxy.Instance.UserSettingsService.SetSetting("IsCompressedView", IsCompressedViewMode);
            };

            this.popupSettings.Closed += (o, t) =>
            {
                ThemeMenager.SaveCurrentConfiguration();
            };

            this.chkIsCompressedViewMode.IsChecked = ServiceProxy.Instance.UserSettingsService.GetSetting<bool>("IsCompressedView");

            // Use the notification service, found on the service proxy, to subscribe to the ScreenOpened,
            // ScreenClosed, and ScreenReloaded notifications.

            ServiceProxy.Instance.NotificationService.Subscribe(typeof(ScreenOpenedNotification), this.OnScreenOpened);
            ServiceProxy.Instance.NotificationService.Subscribe(typeof(ScreenClosedNotification), this.OnScreenClosed);
            ServiceProxy.Instance.NotificationService.Subscribe(typeof(ScreenReloadedNotification), this.OnScreenRefreshed);

            ServiceProxy.Instance.ActiveScreensViewModel.PropertyChanged += (o, t) =>
            {
                ViewChangeAnimation();

                var screen = o as Microsoft.LightSwitch.Runtime.Shell.ViewModels.Implementation.ActiveScreens.ActiveScreensViewModel;
                if (screen.Current != null)
                    this.ActiveScreenDisplayName.Text = screen.Current.DisplayName;
                else
                    this.ActiveScreenDisplayName.Text = String.Empty;
            };

            this.NavigationView.GetPropertyChangedListener("IsExpanded").PropertyChanged += (o, t) =>
            {
                if (!NavigationView.IsExpanded)
                {
                    mainContentGridColumn_0_Width = mainContentGridColumn_0.ActualWidth;
                    mainContentGridColumn_0.Width = new GridLength(0, GridUnitType.Auto);
                }
                else
                {
                    if (mainContentGridColumn_0_Width > 0)
                        mainContentGridColumn_0.Width = new GridLength(mainContentGridColumn_0_Width, GridUnitType.Pixel);
                }
            };
        }

        #endregion

        #region Properties

        public bool IsCompressedViewMode
        {
            get { return _isCompressedViewMode; }
            set
            {
                _isCompressedViewMode = value;
                if (value)
                {
                    this._commandsView.Height = 53;
                }
                else
                {
                    this._commandsView.Height = 85;
                }
            }
        }

        public int ScreenCount
        {
            get { return _screenCount; }
            set { _screenCount = value; }
        }

        #endregion

        #region Public Methods

        public void OnScreenClosed(Notification n)
        {
            // A screen has been closed and therefore removed from the application's
            // collection of active screens.  In response to this, we need to do

            CloseAnimation();
            ScreenCount--;
        }

        public void OnScreenOpened(Notification n)
        {
            // This method is called when a screen has been opened by the run time.  In response to
            // this, we need to create a tab item and set its content to be the UI for the newly
            // opened screen.

            OpenAnimation();
            ScreenCount++;
        }

        public void OnScreenRefreshed(Notification n)
        {
            // When a screen is refreshed, the run time actually creates a new IScreenObject
            // for it and discards the old one.  So in response to this notification, 
            // replace the data context for the tab item that contains
            // this screen with a wrapper (MyScreenObject) for the new IScreenObject instance.

            OpenAnimation();
        }

        #endregion

        #region Private Methods

        private void CreateAnimation()
        {
            CubicEase compositeTransformEasy = new CubicEase() { EasingMode = EasingMode.EaseOut };

            DoubleAnimation opacityAnimationIn = new DoubleAnimation() { Duration = TimeSpan.FromMilliseconds(400), From = 0, To = 1 };
            DoubleAnimation opacityAnimationOut = new DoubleAnimation() { Duration = TimeSpan.FromMilliseconds(150), From = 1, To = 0 };

            DoubleAnimation opacityAnimationViewChange = new DoubleAnimation() { Duration = TimeSpan.FromMilliseconds(170), From = 1, To = 0, AutoReverse = true };

            DoubleAnimationUsingKeyFrames compositeTransformIn = new DoubleAnimationUsingKeyFrames();

            compositeTransformIn.KeyFrames.Add(new EasingDoubleKeyFrame { KeyTime = TimeSpan.Zero, Value = -30 });
            compositeTransformIn.KeyFrames.Add(new EasingDoubleKeyFrame { KeyTime = TimeSpan.FromMilliseconds(700), Value = 0, EasingFunction = compositeTransformEasy });

            DoubleAnimationUsingKeyFrames compositeTransformOut = new DoubleAnimationUsingKeyFrames();

            compositeTransformOut.KeyFrames.Add(new EasingDoubleKeyFrame { KeyTime = TimeSpan.Zero, Value = 0 });
            compositeTransformOut.KeyFrames.Add(new EasingDoubleKeyFrame { KeyTime = TimeSpan.FromMilliseconds(150), Value = -30, EasingFunction = compositeTransformEasy });

            Storyboard.SetTargetProperty(opacityAnimationIn, new PropertyPath("Opacity"));
            Storyboard.SetTarget(opacityAnimationIn, this.MainContentGrid);

            Storyboard.SetTargetProperty(compositeTransformIn, new PropertyPath("(UIElement.RenderTransform).(CompositeTransform.TranslateX)"));
            Storyboard.SetTarget(compositeTransformIn, this.MainContentGrid);

            _StoryboardIn = new Storyboard();
            _StoryboardIn.Children.Add(opacityAnimationIn);
            _StoryboardIn.Children.Add(compositeTransformIn);

            Storyboard.SetTargetProperty(opacityAnimationOut, new PropertyPath("Opacity"));
            Storyboard.SetTarget(opacityAnimationOut, this.MainContentGrid);

            Storyboard.SetTargetProperty(compositeTransformOut, new PropertyPath("(UIElement.RenderTransform).(CompositeTransform.TranslateX)"));
            Storyboard.SetTarget(compositeTransformOut, this.MainContentGrid);

            _StoryboardOut = new Storyboard();

            _StoryboardOut.Completed += (o, t) =>
            {
                MainContentGrid.RenderTransform = startPosition;
                _StoryboardIn.Begin();
            };

            _StoryboardOut.Children.Add(opacityAnimationOut);
            _StoryboardOut.Children.Add(compositeTransformOut);

            Storyboard.SetTargetProperty(opacityAnimationViewChange, new PropertyPath("Opacity"));
            Storyboard.SetTarget(opacityAnimationViewChange, this.MainContentGrid);

            _StoryboardViewChange = new Storyboard();

            _StoryboardViewChange.Children.Add(opacityAnimationViewChange);
        }

        private void OpenAnimation()
        {

            if (!ThemeSettings.SettingsInstance.ShowOpenEffect) return;

            MainContentGrid.RenderTransform = startPosition;

            _StoryboardIn.Begin();
        }

        private void CloseAnimation()
        {
            if (!ThemeSettings.SettingsInstance.ShowCloseEffect) return;

            _StoryboardOut.Begin();
        }

        private void ViewChangeAnimation()
        {
            if (!ThemeSettings.SettingsInstance.ShowPageChangeEffect) return;

            _StoryboardViewChange.Begin();
        }

        #endregion

        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            popupSettings.Show();
        }
    }
}