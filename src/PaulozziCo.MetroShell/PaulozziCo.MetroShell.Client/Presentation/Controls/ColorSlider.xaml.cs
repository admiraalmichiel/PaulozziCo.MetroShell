using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Shapes;

namespace PaulozziCo.MetroShell.Presentation.Controls
{
    [ContentProperty("ColorsCollection")]
    public partial class ColorSlider : UserControl, IList<Color>
    {
        ColorSliderControl slider;

        private bool loadedControl;

        public static readonly DependencyProperty SelectedColorProperty =
                        DependencyProperty.Register("SelectedColor", typeof(Color), typeof(ColorSlider),
                        new PropertyMetadata(Colors.Transparent, OnSelectedColorChanged));

        private static void OnSelectedColorChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            ColorSlider colorSlider = o as ColorSlider;
            if (colorSlider != null)
                colorSlider.OnSelectedColorChanged((Color)e.OldValue, (Color)e.NewValue);
        }

        protected virtual void OnSelectedColorChanged(Color oldValue, Color newValue)
        {
            if (!LoadedControl) return;

            if (oldValue.Equals(this[Value]))
                LoadedControl = true;
        }

        private bool LoadedControl
        {
            get
            {
                return loadedControl;
            }
            set
            {
                if (value)
                {
                    if (Value > 0 && SelectedColor.Equals(Colors.Transparent))
                        SetValue(ColorSlider.SelectedColorProperty, this[Value]);
                    else
                    {
                        var color = this.ColorsCollection.Where(p => p == SelectedColor).FirstOrDefault();
                        if (color != null)
                            SetValue(ColorSlider.ValueProperty, this.IndexOf(color));
                    }
                }

                loadedControl = value;
            }
        }

        public Color SelectedColor
        {
            get { return (Color)GetValue(SelectedColorProperty); }
            set { SetValue(SelectedColorProperty, value); }
        }

        public static readonly DependencyProperty ValueProperty =
                        DependencyProperty.Register("Value", typeof(int), typeof(ColorSlider),
                        new PropertyMetadata(0, OnValueChanged));

        private static void OnValueChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            ColorSlider colorSlider = o as ColorSlider;
            if (colorSlider != null)
            {
                int NVal = (int)e.NewValue;
                int OVal = (int)e.OldValue;

                if (colorSlider.ValidateRange(NVal))
                    colorSlider.OnValueChanged(OVal, NVal);
            }
        }

        private bool ValidateRange(int value)
        {
            bool isValidRange = true;

            if (!LoadedControl)
                return isValidRange;

            int NVal = value;

            if (NVal < 0)
            {
                isValidRange = false;
                SetValue(ColorSlider.ValueProperty, 0);
            }

            if (NVal > this.MaxIndex)
            {
                isValidRange = false;
                SetValue(ColorSlider.ValueProperty, this.MaxIndex);
            }

            return isValidRange;
        }

        protected virtual void OnValueChanged(int oldValue, int newValue)
        {
            if (slider != null)
            {
                slider.IndexValue = newValue;
                SelectedColor = this[newValue];
            }
        }

        public int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public static readonly DependencyProperty ColorsCollectionProperty =
                        DependencyProperty.Register("ColorsCollection", typeof(List<Color>), typeof(ColorSlider),
                        new PropertyMetadata(new List<Color>(), OnColorsCollectionChanged));

        private static void OnColorsCollectionChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            ColorSlider colorSlider = o as ColorSlider;
            if (colorSlider != null)
                colorSlider.OnColorsCollectionChanged((List<Color>)e.OldValue, (List<Color>)e.NewValue);
        }

        protected virtual void OnColorsCollectionChanged(List<Color> oldValue, List<Color> newValue)
        {
            if (newValue != null)
            {
                this.BuildControl();
            }
        }

        public List<Color> ColorsCollection
        {
            get { return (List<Color>)GetValue(ColorsCollectionProperty); }
            set { SetValue(ColorsCollectionProperty, value); }
        }

        private static GridLength DefaulGridLength
        {
            get { return new GridLength(1d, GridUnitType.Star); }
        }

        private static ColumnDefinition DefaultColumnDefinition
        {
            get { return new ColumnDefinition() { Width = DefaulGridLength }; }
        }

        private void BuildControl()
        {
            if (this.contentHost.Content != null)
                this.contentHost.Content = null;

            Grid content = new Grid();

            slider = new ColorSliderControl();
            slider.Style = this.Resources["ColorSliderStyle"] as Style;
            slider.Value = 0;
            slider.SmallChange = 1d;
            slider.Maximum = this.Count * 2;
            slider.IndexChanged += (s, e) =>
            {
                Value = Convert.ToInt32(e.NewValue);
            };
            slider.IndexValue = Value;

            Grid colorsGrid = GetGrid();
            colorsGrid.Margin = new Thickness(7, 2, 6, 2);

            content.Children.Add(colorsGrid);
            content.Children.Add(slider);

            contentHost.Content = content;
        }

        private int MaxIndex
        {
            get
            {
                if (this.Count == 0)
                    return 0;
                return this.Count - 1;
            }
        }

        private Grid GetGrid()
        {
            Grid colorsGrid = new Grid();

            for (int i = 0; i < this.Count; i++)
            {
                colorsGrid.ColumnDefinitions.Add(DefaultColumnDefinition);
                this.BuildRetangle(i, colorsGrid);
            }

            return colorsGrid;
        }

        private void BuildRetangle(int index, Grid grid)
        {
            Rectangle rectangle = new Rectangle();
            rectangle.Fill = new SolidColorBrush(ColorsCollection[index]);
            Grid.SetColumn(rectangle, index);
            grid.Children.Add(rectangle);
        }

        public ColorSlider()
        {
            InitializeComponent();

            this.Loaded += ColorSlider_Loaded;
        }

        private void ColorSlider_Loaded(object sender, RoutedEventArgs e)
        {
            this.BuildControl();
            this.LoadedControl = true;
        }

        #region IList Members

        public int IndexOf(Color item)
        {
            return this.ColorsCollection.IndexOf(item);
        }

        public void Insert(int index, Color item)
        {
            this.ColorsCollection.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            this.ColorsCollection.RemoveAt(index);
        }

        public Color this[int index]
        {
            get
            {
                if (index == -1)
                    return Colors.Transparent;
                return this.ColorsCollection[index];
            }
            set { ColorsCollection[index] = value; }
        }

        public void Add(Color item)
        {
            this.ColorsCollection.Add(item);
        }

        public void Clear()
        {
            this.ColorsCollection.Clear();
        }

        public bool Contains(Color item)
        {
            return this.ColorsCollection.Contains(item);
        }

        public void CopyTo(Color[] array, int arrayIndex)
        {
            this.ColorsCollection.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get
            {
                if (this.ColorsCollection == null)
                    return 0;
                return this.ColorsCollection.Count;
            }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(Color item)
        {
            return this.ColorsCollection.Remove(item);
        }

        public IEnumerator<Color> GetEnumerator()
        {
            return this.ColorsCollection.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.ColorsCollection.GetEnumerator();
        }

        #endregion

        protected class ColorSliderControl : Slider
        {
            public event RoutedPropertyChangedEventHandler<double> IndexChanged;

            protected virtual void OnIndexChanged(double oldValue, double newValue)
            {
                RoutedPropertyChangedEventHandler<double> valueChanged = this.IndexChanged;
                if (valueChanged != null)
                {
                    valueChanged(this, new RoutedPropertyChangedEventArgs<double>(oldValue, newValue));
                }
            }

            public ColorSliderControl()
            {
                this.MouseWheel += ColorSliderControl_MouseWheel;
            }

            public static readonly DependencyProperty IndexValueProperty = DependencyProperty.Register(
                      "IndexValue",
                      typeof(Double),
                      typeof(ColorSliderControl),
                      new PropertyMetadata(0.0, OnIndexValueChanged));

            private Thumb _HorizontalThumb;

            private RepeatButton left;

            private RepeatButton right;

            public Double IndexValue
            {
                get { return (Double)GetValue(IndexValueProperty); }
                set { SetValue(IndexValueProperty, value); }
            }

            public override void OnApplyTemplate()
            {
                base.OnApplyTemplate();

                _HorizontalThumb = GetTemplateChild("HorizontalThumb") as Thumb;

                left = GetTemplateChild("HorizontalTrackLargeChangeIncreaseRepeatButton") as RepeatButton;
                right = GetTemplateChild("HorizontalTrackLargeChangeDecreaseRepeatButton") as RepeatButton;

                if (left != null) left.AddHandler(MouseLeftButtonDownEvent, new MouseButtonEventHandler(OnMoveThumbToMouse), true);
                if (right != null) right.AddHandler(MouseLeftButtonDownEvent, new MouseButtonEventHandler(OnMoveThumbToMouse), true);

                _HorizontalThumb.MouseLeftButtonUp += new MouseButtonEventHandler(_HorizontalThumb_MouseLeftButtonUp);

                UpadateValue();
            }


            protected override void OnKeyUp(KeyEventArgs e)
            {
                
            }

            protected override void OnKeyDown(KeyEventArgs e)
            {
                base.OnKeyDown(e);

                if (this.Value == 2 && e.Key == Key.Left)
                {
                    this.Value = 1;
                }

                if (e.Key == Key.Left || e.Key == Key.Right)
                {
                    UpadateValue();
                }
            }

            private void ColorSliderControl_MouseWheel(object sender, MouseWheelEventArgs e)
            {
                if (e.Delta > 0)
                {
                    this.Value += this.SmallChange * GetScrollFactorByDelta(e.Delta);
                }
                else
                {
                    this.Value -= this.SmallChange * GetScrollFactorByDelta(e.Delta);
                }

                UpadateValue();
            }

            private int GetScrollFactorByDelta(int delta)
            {
                int deltaAbs = Math.Abs(delta);

                if (deltaAbs <= 20)
                    return 0;

                if (deltaAbs <= 35)
                    return 2;

                return 2;
            }

            protected override void OnValueChanged(double oldValue, double newValue)
            {

                base.OnValueChanged(oldValue, newValue);
                double minimum = Minimum;

                double maximum = Maximum;
                double smallChange = SmallChange;

                double value = Value;
                double snapValue = 0;

                if (SmallChange != 0)
                {
                    double valueTest = ((Math.Ceiling((value - minimum - 1) / smallChange) * smallChange) + minimum);

                    if (valueTest % 2 == 0)
                    {
                        snapValue = valueTest / 2;
                    }
                    else
                    {
                        snapValue = ((valueTest - 1) / 2);
                    }

                    if (snapValue == 0)
                        snapValue = valueTest;

                    if (snapValue < 0)
                        snapValue = 0;

                    SetValue(IndexValueProperty, snapValue);
                }

                if (value < minimum)
                {
                    SetValue(ValueProperty, minimum);
                }

                if (value > maximum)
                {
                    SetValue(ValueProperty, maximum);
                }

            }

            private void _HorizontalThumb_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
            {
                UpadateValue();
            }

            private static void OnIndexValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                ColorSliderControl obj = d as ColorSliderControl;
                obj.UpadateValueByIndex((Double)e.NewValue);
                obj.OnIndexChanged((Double)e.OldValue, (Double)e.NewValue);
            }

            private void OnMoveThumbToMouse(object sender, MouseButtonEventArgs e)
            {
                Point p = e.GetPosition(this);

                Value = (p.X - (_HorizontalThumb.ActualWidth / 2)) / (ActualWidth - _HorizontalThumb.ActualWidth) * Maximum;

                UpadateValue();
            }

            private void UpadateValue()
            {
                double minimum = Minimum;

                double maximum = Maximum;
                double smallChange = SmallChange;

                double value = Value;
                double snapValue = 0;

                double valueTest = (Math.Floor((value - minimum) / smallChange) * smallChange) + minimum;

                if (valueTest % 2 != 0)
                {
                    snapValue = valueTest;
                }
                else
                {
                    if ((valueTest + 1) < maximum)
                        snapValue = valueTest + 1;
                    else
                        snapValue = valueTest - 1;
                }

                SetValue(ValueProperty, snapValue);
            }

            private void UpadateValueByIndex(double value)
            {
                double snapValue = 0;

                double valueTest = Math.Ceiling(value);

                snapValue = ((valueTest * 2) + 1);

                SetValue(ValueProperty, snapValue);
            }
        }
    }
}
