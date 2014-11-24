using System;
using System.Collections.Generic;

namespace PaulozziCo.MetroShell.Model
{
    public class ThemeStoreInfo
    {
        public ThemeStoreInfo()
        {
            CurrentBackgroundStyle = BackgroudColorStyle.Light;
        }

        public int? CurrentPaletteIndex { get; set; }
        public BackgroudColorStyle CurrentBackgroundStyle { get; set; }
    }
}
