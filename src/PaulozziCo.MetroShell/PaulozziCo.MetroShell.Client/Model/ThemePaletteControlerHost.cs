using PaulozziCo.MetroShell.Services;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;

namespace PaulozziCo.MetroShell.Model
{
    public class ThemePaletteControlerHost : FrameworkElement, INotifyPropertyChanged
    {
        public ThemePaletteControlerHost()
        {
            this.Loaded += ThemePaletteControlerHost_Loaded;
        }

        private void ThemePaletteControlerHost_Loaded(object sender, RoutedEventArgs e)
        {
            InvalidateProperties();
        }

        private void InvalidateProperties()
        {
            RaisePropertyChanged("DisplayColorCollection");
            RaisePropertyChanged("SelectedColorIndex");
            RaisePropertyChanged("SelectedBackgroudIndex");
        }

        private List<Color> _DisplayColorCollection;
        private int _SelectedColorIndex;
        private int _SelectedBackgroudIndex;

        public List<Color> DisplayColorCollection
        {
            get
            {
                if (_DisplayColorCollection == null)
                {
                    _DisplayColorCollection = ThemePaletteMenager.AccentColorCollection;
                }

                return _DisplayColorCollection;
            }
            set
            {
                _DisplayColorCollection = value;
                RaisePropertyChanged("DisplayColorCollection");
            }
        }

        public int SelectedColorIndex
        {
            get { return ThemePaletteMenager.CurrentPaletteIndex; }
            set
            {
                _SelectedColorIndex = value;
                if (_SelectedColorIndex > -1)
                {
                    ThemePaletteMenager.SetTheme(_SelectedColorIndex);
                }
                RaisePropertyChanged("SelectedColorIndex");
            }
        }

        public int SelectedBackgroudIndex
        {
            get
            {
                return ThemePaletteMenager.CurrentBackgroudStyleIndex;
            }
            set
            {
                if (_SelectedBackgroudIndex == value)
                    return;
                _SelectedBackgroudIndex = value;
                ThemePaletteMenager.SetBackgroudStyle(_SelectedBackgroudIndex);
                RaisePropertyChanged("SelectedBackgroudIndex");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
