using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Reflection;
using System.Resources;

using Microsoft.LightSwitch.Model;

using PaulozziCo.MetroShell.Resources;

namespace PaulozziCo.MetroShell.Metadata
{
    [Export(typeof(IModuleDefinitionLoader))]
    [ModuleDefinitionLoader("PaulozziCo.MetroShell")]
    internal class ModuleLoader :
        IModuleDefinitionLoader
    {
        #region IModuleDefinitionLoader Members

        ResourceManager IModuleDefinitionLoader.GetModelResourceManager()
        {
            return ModuleResources.ResourceManager;
        }

        IEnumerable<Stream> IModuleDefinitionLoader.LoadModelFragments()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            IList<Stream> fragmentStreams = new List<Stream>();

            foreach (string resourceName in assembly.GetManifestResourceNames())
            {
                if (resourceName.EndsWith(".lsml", StringComparison.Ordinal))
                {
                    fragmentStreams.Add(assembly.GetManifestResourceStream(resourceName));
                }
            }

            return fragmentStreams;
        }

        #endregion
    }
}