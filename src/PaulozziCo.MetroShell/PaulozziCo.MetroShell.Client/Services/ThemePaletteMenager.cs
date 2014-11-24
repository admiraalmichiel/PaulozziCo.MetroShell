using PaulozziCo.MetroShell.Model;
using PaulozziCo.MetroShell.Presentation.Resources;
using PaulozziCo.MetroShell.Utilities;
using System;
using System.Collections.Generic;
using System.Windows.Media;

namespace PaulozziCo.MetroShell.Services
{

    public static class ThemePaletteMenager
    {
        private static readonly string[] Keys = { "MainColor", "AccentColor", "BasicColor", "StrongColor", "MarkerColor", "ValidationColor", "NavigationAccentColor", "BackgroundAccentColor", "SecundaryAccentColor" };

        private static Dictionary<string, string>[] _ColorsArray = null;

        private static int _CurrentPaletteIndex = Global.Theme.ITN_DefaultPaletteIndex;

        private static List<Color> _DisplayColorCollection = null;

        /// <summary>
        /// Gets or sets the accent color collection.
        /// </summary>
        /// <value>
        /// The accent color collection.
        /// </value>
        public static List<Color> AccentColorCollection
        {
            get
            {
                if (_DisplayColorCollection == null)
                {
                    _DisplayColorCollection = GetColorsInThemesByKey("AccentColor");
                }
                return _DisplayColorCollection;
            }
            set { _DisplayColorCollection = value; }
        }

        /// <summary>
        /// Gets the colors array.
        /// </summary>
        /// <value>
        /// The colors array.
        /// </value>
        public static Dictionary<string, string>[] ColorsArray
        {
            get
            {
                if (_ColorsArray == null)
                    _ColorsArray = GetColorsPaleteArray();

                return _ColorsArray;
            }
        }

        public static int CurrentBackgroudStyleIndex
        {
            get { return (int)ThemeColors.PaletteInstance.BackgroudStyle; }
        }

        public static int CurrentPaletteIndex
        {
            get
            {
                return _CurrentPaletteIndex;
            }
            private set
            {
                _CurrentPaletteIndex = value;
            }
        }

        /// <summary>
        /// Gets the colors in themes by key.
        /// </summary>
        /// <exception cref="ArgumentNullException"> Thrown when one or more required arguments are null.</exception>
        /// <param name="key"> The key.</param>
        /// <returns>
        /// The colors in themes by key.
        /// </returns>
        public static List<Color> GetColorsInThemesByKey(string key)
        {
            if (String.IsNullOrEmpty(key))
                throw new ArgumentNullException("key");

            _DisplayColorCollection = new List<Color>();

            foreach (var item in ColorsArray)
            {
                String colorHaxa = null;
                if (item.TryGetValue(key, out colorHaxa))
                {
                    Color color = colorHaxa.ColorFromHexa();
                    _DisplayColorCollection.Add(color);
                }
            }

            return _DisplayColorCollection;
        }

        /// <summary>
        /// Gets the theme dictionary.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"> Thrown when one or more arguments are outside
        /// the required range.</exception>
        /// <param name="themeIndex"> Index of the theme.</param>
        /// <returns>
        /// The theme.
        /// </returns>
        public static Dictionary<string, string> GetTheme(int? themeIndex)
        {
            int val = themeIndex ?? 0;

            if (val > ColorsArray.Length - 1)
                throw new ArgumentOutOfRangeException("themeIndex");

            return ColorsArray[val];
        }

        /// <summary>
        /// Restores the theme from isolated storage.
        /// </summary>
        /// <param name="successCallback"> The success callback.</param>
        public static void RestoreThemeFromIsolatedStorage(Action<ThemeStoreInfo> successCallback)
        {
            var res = IsolatedStorageHelper<ThemeStoreInfo>.TryGet(Global.Theme.IS_UserCurrentThemeInfo);
            if (res != null)
            {
                CurrentPaletteIndex = res.CurrentPaletteIndex ?? Global.Theme.ITN_DefaultPaletteIndex;
                successCallback(res);
            }
        }

        public static void SaveCurrentThemeInIsulatedStarage()
        {
            SaveThemeInIsolatedStorage(CurrentPaletteIndex, ThemeColors.PaletteInstance.BackgroudStyle);
        }

        /// <summary>
        /// Saves the theme in isolated storage.
        /// </summary>
        /// <param name="themeIndex"> Index of the theme.</param>
        public static void SaveThemeInIsolatedStorage(int? themeIndex, BackgroudColorStyle backgroundStyle = BackgroudColorStyle.Light)
        {
            var info = new ThemeStoreInfo() { CurrentPaletteIndex = themeIndex, CurrentBackgroundStyle = backgroundStyle };

            SaveThemeInIsolatedStorage(info);
        }

        public static void SaveThemeInIsolatedStorage(ThemeStoreInfo info)
        {
            IsolatedStorageHelper<ThemeStoreInfo>.TryStore(info, Global.Theme.IS_UserCurrentThemeInfo);
        }

        public static void SetBackgroudStyle(int backgroudStyleIndex)
        {
            ThemeColors.PaletteInstance.BackgroudStyle = (BackgroudColorStyle)backgroudStyleIndex;
        }

        public static void SetBackgroudStyle(BackgroudColorStyle backgroudStyle)
        {
            ThemeColors.PaletteInstance.BackgroudStyle = backgroudStyle;
        }

        /// <summary>
        /// Sets the current theme by isolated storage.
        /// </summary>
        public static void SetCurrentThemeByIsolatedStorage()
        {
            RestoreThemeFromIsolatedStorage(result =>
            {
                SetTheme(result.CurrentPaletteIndex);
                SetBackgroudStyle(result.CurrentBackgroundStyle);
            });
        }

        /// <summary>
        /// Sets the theme by index.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"> Thrown when one or more arguments are outside
        /// the required range.</exception>
        /// <param name="index"> The index.</param>
        public static void SetTheme(int? index)
        {
            int val = index ?? Global.Theme.ITN_DefaultPaletteIndex;

            if (val > ColorsArray.Length - 1)
                throw new ArgumentOutOfRangeException("index");

            SetTheme(ColorsArray[val]);
            CurrentPaletteIndex = val;
        }

        private static Dictionary<string, string>[] GetColorsPaleteArray()
        {
            ThemeResources themeResources = new ThemeResources();
            return themeResources.GetDictionariesCollection();
        }

        /// <summary>
        /// Sets the theme by dictionary.
        /// </summary>
        /// <exception cref="ArgumentNullException"> Thrown when one or more required arguments are null.</exception>
        /// <param name="themeDictionary"> The theme dictionary.</param>
        private static void SetTheme(Dictionary<string, string> themeDictionary)
        {
            if (themeDictionary == null)
                throw new ArgumentNullException("themeDictionary");

            ThemeColors.PaletteInstance.MainColor = themeDictionary[Keys[0]].ColorFromHexa();
            ThemeColors.PaletteInstance.AccentColor = themeDictionary[Keys[1]].ColorFromHexa();
            ThemeColors.PaletteInstance.BasicColor = themeDictionary[Keys[2]].ColorFromHexa();
            ThemeColors.PaletteInstance.StrongColor = themeDictionary[Keys[3]].ColorFromHexa();
            ThemeColors.PaletteInstance.MarkerColor = themeDictionary[Keys[4]].ColorFromHexa();
            ThemeColors.PaletteInstance.ValidationColor = themeDictionary[Keys[5]].ColorFromHexa();
            ThemeColors.PaletteInstance.NavigationAccentColor = themeDictionary[Keys[6]].ColorFromHexa();
            ThemeColors.PaletteInstance.BackgroundAccentColor = themeDictionary[Keys[7]].ColorFromHexa();
            ThemeColors.PaletteInstance.SecundaryAccentColor = themeDictionary[Keys[8]].ColorFromHexa();
        }

    }
}
