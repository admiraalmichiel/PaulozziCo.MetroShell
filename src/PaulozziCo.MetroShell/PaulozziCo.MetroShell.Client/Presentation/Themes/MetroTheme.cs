using System;
using System.ComponentModel.Composition;

using Microsoft.LightSwitch.Theming;
using Microsoft.LightSwitch.Sdk.Proxy;
using Microsoft.VisualStudio.ExtensibilityHosting;
using System.Windows;
using System.Threading;
using System.Windows.Threading;

namespace PaulozziCo.MetroShell.Presentation.Themes
{
    [Export(typeof(ITheme))]
    [Theme(MetroTheme.ThemeId, MetroTheme.ThemeVersion)]
    public class MetroTheme : ITheme
    {
        #region ITheme Members

        public string Id
        {
            get { return MetroTheme.ThemeId; }
        }

        public string Version
        {
            get { return MetroTheme.ThemeVersion; }
        }

        public Uri ColorAndFontScheme
        {
            get { return new Uri(@"/PaulozziCo.MetroShell.Client;component/Presentation/Themes/MetroTheme.xaml", UriKind.Relative); }
        }

        #endregion

        #region Constants
        
        internal const string ThemeId = "PaulozziCo.MetroShell:MetroTheme";
        internal const string ThemeVersion = "2.0";

        #endregion
    }
}
