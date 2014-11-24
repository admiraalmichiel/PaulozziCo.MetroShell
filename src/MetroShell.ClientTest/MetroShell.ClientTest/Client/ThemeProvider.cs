using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace LightSwitchApplication
{
    public class ShellProvider : ExtensionsMadeEasy.ClientAPI.Shell.EasyShellExporter<PaulozziCo.MetroShell.Presentation.Shells.Components.MetroShell> { }
    public class ThemeProvider : ExtensionsMadeEasy.ClientAPI.Theme.EasyThemeWithExtensionsExporter<PaulozziCo.MetroShell.Presentation.Themes.MetroTheme, PaulozziCo.MetroShell.Presentation.Themes.MetroStyles> { }
}
