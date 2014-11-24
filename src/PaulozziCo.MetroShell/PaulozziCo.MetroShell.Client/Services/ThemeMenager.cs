
namespace PaulozziCo.MetroShell.Services
{
    public static class ThemeMenager
    {
        public static void SaveCurrentConfiguration()
        {
            ThemeSettingsMenager.StoreUserThemeSettings();
            ThemePaletteMenager.SaveCurrentThemeInIsulatedStarage();
        }

        public static void RestoreUserConfiguration()
        {
            ThemeSettingsMenager.RestoreUserThemeSettings();
            ThemePaletteMenager.SetCurrentThemeByIsolatedStorage();
        }
    }
}
