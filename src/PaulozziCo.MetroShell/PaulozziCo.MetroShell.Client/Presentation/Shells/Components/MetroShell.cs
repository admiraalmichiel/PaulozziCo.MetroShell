using System;
using System.ComponentModel.Composition;

using Microsoft.LightSwitch.Runtime.Shell;

namespace PaulozziCo.MetroShell.Presentation.Shells.Components
{
    [Export(typeof(IShell))]
    [Shell(MetroShell.ShellId)]
    public class MetroShell : IShell
    {
        #region IShell Members

        public string Name
        {
            get { return MetroShell.ShellId; }
        }

        public Uri ShellUri
        {
            get { return new Uri(@"/PaulozziCo.MetroShell.Client;component/Presentation/Shells/MetroShell.xaml", UriKind.Relative); }
        }

        #endregion

        #region Constants

        private const string ShellId = "PaulozziCo.MetroShell:MetroShell";

        #endregion
    }
}
