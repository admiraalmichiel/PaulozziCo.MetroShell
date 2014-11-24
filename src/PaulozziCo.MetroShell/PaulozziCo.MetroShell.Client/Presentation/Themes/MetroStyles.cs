using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using Microsoft.LightSwitch.Model;
using Microsoft.LightSwitch.Theming;

namespace PaulozziCo.MetroShell.Presentation.Themes
{
    /// <summary>
    /// The ITheme extension allows a theme to extend the built-in styles for LightSwitch built-in and 3rd party controls. The
    /// Uri's returned by GetControlStyleResources will be used in place of the built-in styles.  If LightSwitch cannot find 
    /// a style key in the theme extension, it will use the default (built-in) style.
    /// </summary>
    [Export(typeof(IThemeExtension))]
    [ThemeExtension(MetroTheme.ThemeId)]
    public class MetroStyles :
        IThemeExtension
    {
        IEnumerable<Uri> IThemeExtension.GetControlStyleResources(string themeId, string themeVersion, IEnumerable<IModuleDefinition> modules)
        {
            yield return new Uri(@"/PaulozziCo.MetroShell.Client;component/Presentation/Themes/MetroStyles.xaml", UriKind.Relative);
        }
    }
}
