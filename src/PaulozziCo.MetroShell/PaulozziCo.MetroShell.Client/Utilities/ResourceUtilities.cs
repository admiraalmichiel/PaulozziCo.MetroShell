using System;
using System.Windows;
using System.Reflection;
using System.IO;
using System.Windows.Markup;

namespace PaulozziCo.MetroShell.Utilities
{
    internal static class ResourceUtilities
    {
        #region Public Methods

        public static T GetResource<T>(string path, string name)
        {
            return (T)GetResourceDictionary(path)[name];
        }

        public static ResourceDictionary GetResourceDictionary(string path)
        {
            string xaml = null;
            using (StreamReader reader = new StreamReader(GetStream(path)))
            {
                xaml = reader.ReadToEnd();
            }
            return (ResourceDictionary)XamlReader.Load(xaml);
        }

        public static Stream GetStream(string path)
        {
            return Application.GetResourceStream(GetUri(path)).Stream;
        }

        public static Uri GetUri(Assembly assembly, string path)
        {
            AssemblyName name = new AssemblyName(assembly.FullName);
            return new Uri(String.Format("/{0};component/{1}", name.Name, path), UriKind.Relative);
        }

        public static Uri GetUri(string path)
        {
            return GetUri(Assembly.GetCallingAssembly(), path);
        }

        #endregion

    }
}
