using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;
using System.Windows.Media.Animation;
using System.Windows.Media;

namespace PaulozziCo.MetroShell.Presentation.Behaviors
{
    /// <summary>
    /// Adds mouse wheel scroll to scroll viewers
    /// </summary>
    /// <remarks>
    /// <code>
    /// &lt;ScrollViewer&gt;
    ///		&lt;i:Interaction.Behaviors&gt;
    ///			<behaviors:MouseScrollViewer /&gt;
    ///		&lt;/i:Interaction.Behaviors&gt;
    /// &lt;/ScrollViewer&gt;
    /// </code>
    /// </remarks>
    public class MouseScrollViewer : Behavior<ScrollViewer>
    {
        #region Readonly

        internal static readonly DependencyProperty OffsetMediatorProperty =
                    DependencyProperty.Register("OffsetMediator", typeof(double), typeof(MouseScrollViewer), new PropertyMetadata(0.0, OnOffsetMediatorPropertyChanged));

        public static readonly DependencyProperty ScrollAmountProperty =
                    DependencyProperty.Register("ScrollAmount", typeof(double), typeof(MouseScrollViewer), new PropertyMetadata(50.0));

        #endregion

        #region Fields

        private DoubleAnimation animation;

        int direction;

        private Storyboard storyboard;

        double target = 0;

        #endregion

        #region Properties

        internal double OffsetMediator
        {
            get { return (double)GetValue(OffsetMediatorProperty); }
            set { SetValue(OffsetMediatorProperty, value); }
        }

        /// <summary>
        /// Gets or sets the scroll amount.
        /// </summary>
        /// <value>The scroll amount.</value>
        /// <remarks>Defaults to 50.</remarks>
        public double ScrollAmount
        {
            get { return (double)GetValue(ScrollAmountProperty); }
            set { SetValue(ScrollAmountProperty, value); }
        }

        #endregion

        #region Protected Methods

        protected override void OnAttached()
        {
            AssociatedObject.Loaded += AssociatedObject_Loaded;
            AssociatedObject.Unloaded += AssociatedObject_Unloaded;

            if (AssociatedObject.Background == null)
                AssociatedObject.Background = new SolidColorBrush(Colors.Transparent);

            AssociatedObject.MouseWheel += AssociatedObject_MouseWheel;
            CreateStoryBoard();
            base.OnAttached();
        }

        protected override void OnDetaching()
        {
            AssociatedObject.MouseWheel -= AssociatedObject_MouseWheel;
            storyboard = null;
            base.OnDetaching();
        }

        #endregion

        #region Private Methods

        private bool Animate(double offset)
        {
            storyboard.Pause();
            if (Math.Sign(offset) != direction)
            {   //scroll direction reversed while animating. Flip around immediately
                target = AssociatedObject.VerticalOffset;
                direction = Math.Sign(offset);
            }
            target += offset;
            target = Math.Max(Math.Min(target, AssociatedObject.ScrollableHeight), 0);
            animation.To = target;
            animation.From = AssociatedObject.VerticalOffset;

            if (animation.From != animation.To)
            {
                storyboard.Begin();
                return true;
            }
            else
            {
                if (animation.To > 0d)
                    animation.From -= 10;
                else
                    animation.From += 10;

                storyboard.Begin();
                return false;
            }
        }

        void AssociatedObject_Loaded(object sender, RoutedEventArgs e)
        {
            Dispatcher.BeginInvoke(() => {
                    if (VisualTreeHelper.GetChildrenCount(sender as FrameworkElement) > 0)
                    {
                        FrameworkElement element = VisualTreeHelper.GetChild((sender as FrameworkElement), 0) as FrameworkElement;
                        element.MouseWheel += AssociatedObject_MouseWheel;
                    }
            });
        }

        private void AssociatedObject_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (Animate(-Math.Sign(e.Delta) * ScrollAmount))
            {
                e.Handled = true;
            }
        }

        private void AssociatedObject_Unloaded(object sender, RoutedEventArgs e)
        {
            Dispatcher.BeginInvoke(() => (VisualTreeHelper.GetChild((sender as FrameworkElement), 0) as FrameworkElement).MouseWheel -= AssociatedObject_MouseWheel);
        }

        private void CreateStoryBoard()
        {

            storyboard = new Storyboard();
            animation = new DoubleAnimation()
            {
                Duration = TimeSpan.FromSeconds(.5),
                EasingFunction = new ExponentialEase() { EasingMode = EasingMode.EaseOut }
            };

            animation.SetValue(Storyboard.TargetPropertyProperty, new PropertyPath("OffsetMediator"));
            Storyboard.SetTarget(animation, this);

            storyboard.Children.Add(animation);
            storyboard.Completed += (s, e) => { direction = 0; };
        }

        private static void OnOffsetMediatorPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MouseScrollViewer msv = d as MouseScrollViewer;
            if (msv != null && msv.AssociatedObject != null)
            {
                msv.AssociatedObject.ScrollToVerticalOffset((double)e.NewValue);
            }
        }

        #endregion

    }
}
