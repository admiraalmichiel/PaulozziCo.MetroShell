using System.Diagnostics.CodeAnalysis;

namespace PaulozziCo.MetroShell.Model
{
    public class ThemeSettings
    {
        private static ThemeSettingsInfo palette;

        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        public ThemeSettingsInfo Settings
        {
            get
            {
                return SettingsInstance;
            }
        }

        public static ThemeSettingsInfo SettingsInstance
        {
            get
            {
                if (palette == null)
                {
                    palette = new ThemeSettingsInfo();
                }
                return palette;
            }
        }
    }
}
