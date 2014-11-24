using PaulozziCo.MetroShell.Model;
using PaulozziCo.MetroShell.Utilities;
using System;

namespace PaulozziCo.MetroShell.Services
{
    public static class ThemeSettingsMenager
    {
        public static void RestoreUserThemeSettings()
        {
            //ThemeSettingsInfo storedThemeSettings = ServiceProxy.Instance.UserSettingsService.GetSetting<ThemeSettingsInfo>(Global.Theme.IS_UserCurrentSettingsInfo);
            RestoreThemeFromIsolatedStorage(res => 
            {
                ThemeSettings.SettingsInstance.RibbonPositionValue = res.RibbonPositionValue;
                ThemeSettings.SettingsInstance.ShowScreenTitle = res.ShowScreenTitle;
                ThemeSettings.SettingsInstance.ShowCloseEffect = res.ShowCloseEffect;
                ThemeSettings.SettingsInstance.ShowOpenEffect = res.ShowOpenEffect;
                ThemeSettings.SettingsInstance.ShowPageChangeEffect = res.ShowPageChangeEffect;
            });
        }

        public static void RestoreThemeFromIsolatedStorage(Action<ThemeSettingsInfo> successCallback)
        {
            var res = IsolatedStorageHelper<ThemeSettingsInfo>.TryGet(Global.Theme.IS_UserCurrentSettingsInfo);
            if (res != null)
            {
                successCallback(res);
            }
        }

        public static void StoreUserThemeSettings()
        {
            StoreThemeSettings(ThemeSettings.SettingsInstance);
        }

        public static void StoreThemeSettings(ThemeSettingsInfo info)
        {
            //ServiceProxy.Instance.UserSettingsService.SetSetting(Global.Theme.IS_UserCurrentSettingsInfo, info);
            IsolatedStorageHelper<ThemeSettingsInfo>.TryStore(info, Global.Theme.IS_UserCurrentSettingsInfo);
        }
    }
}