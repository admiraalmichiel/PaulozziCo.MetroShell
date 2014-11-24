using Microsoft.LightSwitch.Sdk.Proxy;
using Microsoft.VisualStudio.ExtensibilityHosting;
using System;

namespace PaulozziCo.MetroShell.Services
{
    internal static class ServiceProxy
    {
        private static IServiceProxy proxy;

        public static IServiceProxy Instance
        {
            get
            {
                if (proxy == null)
                {
                    proxy = VsExportProviderService.GetServiceFromCache<IServiceProxy>();
                }
                return proxy;
            }
        }
    }
}
