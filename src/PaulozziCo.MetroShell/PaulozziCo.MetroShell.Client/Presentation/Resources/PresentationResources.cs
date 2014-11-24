using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace PaulozziCo.MetroShell.Presentation.Resources
{
    [DebuggerNonUserCode, GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0"), CompilerGenerated]
    internal class PresentationResources
    {
        private static CultureInfo resourceCulture;
        private static System.Resources.ResourceManager resourceMan;

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal PresentationResources()
        {
        }

        internal static string ChangePassword_Description
        {
            get
            {
                return ResourceManager.GetString("ChangePassword_Description", resourceCulture);
            }
        }

        internal static string ChangePassword_DisplayName
        {
            get
            {
                return ResourceManager.GetString("ChangePassword_DisplayName", resourceCulture);
            }
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static CultureInfo Culture
        {
            get
            {
                return resourceCulture;
            }
            set
            {
                resourceCulture = value;
            }
        }

        internal static string NavigationOverflowButton_Description
        {
            get
            {
                return ResourceManager.GetString("NavigationOverflowButton_Description", resourceCulture);
            }
        }

        internal static string NavigationOverflowButton_DisplayName
        {
            get
            {
                return ResourceManager.GetString("NavigationOverflowButton_DisplayName", resourceCulture);
            }
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static System.Resources.ResourceManager ResourceManager
        {
            get
            {
                if (object.ReferenceEquals(resourceMan, null))
                {
                    System.Resources.ResourceManager manager = new System.Resources.ResourceManager("PaulozziCo.MetroShell.Presentation.Resources.PresentationResources", typeof(PresentationResources).Assembly);
                    resourceMan = manager;
                }
                return resourceMan;
            }
        }

        internal static string ScreenCommandsOverflowButton_Description
        {
            get
            {
                return ResourceManager.GetString("ScreenCommandsOverflowButton_Description", resourceCulture);
            }
        }

        internal static string ScreenCommandsOverflowButton_DisplayName
        {
            get
            {
                return ResourceManager.GetString("ScreenCommandsOverflowButton_DisplayName", resourceCulture);
            }
        }

        internal static string ScreensOverflowButton_Description
        {
            get
            {
                return ResourceManager.GetString("ScreensOverflowButton_Description", resourceCulture);
            }
        }

        internal static string ScreensOverflowButton_DisplayName
        {
            get
            {
                return ResourceManager.GetString("ScreensOverflowButton_DisplayName", resourceCulture);
            }
        }

        internal static string ScreenValidationViewer_ResultDisplayString
        {
            get
            {
                return ResourceManager.GetString("ScreenValidationViewer_ResultDisplayString", resourceCulture);
            }
        }

        internal static string ScreenValidationViewer_ResultDisplayStringWithSummaryProperty
        {
            get
            {
                return ResourceManager.GetString("ScreenValidationViewer_ResultDisplayStringWithSummaryProperty", resourceCulture);
            }
        }

        internal static string ScreenValidationViewer_ServerErrorsTitle
        {
            get
            {
                return ResourceManager.GetString("ScreenValidationViewer_ServerErrorsTitle", resourceCulture);
            }
        }

        internal static string ScreenValidationViewer_SummaryDisplayString
        {
            get
            {
                return ResourceManager.GetString("ScreenValidationViewer_SummaryDisplayString", resourceCulture);
            }
        }

        internal static string TerminateScreen_Command_Description
        {
            get
            {
                return ResourceManager.GetString("TerminateScreen_Command_Description", resourceCulture);
            }
        }

        internal static string TerminateScreen_ConfirmDialog_Caption
        {
            get
            {
                return ResourceManager.GetString("TerminateScreen_ConfirmDialog_Caption", resourceCulture);
            }
        }

        internal static string TerminateScreen_ConfirmDialog_Close
        {
            get
            {
                return ResourceManager.GetString("TerminateScreen_ConfirmDialog_Close", resourceCulture);
            }
        }

        internal static string TerminateScreen_ConfirmDialog_Message
        {
            get
            {
                return ResourceManager.GetString("TerminateScreen_ConfirmDialog_Message", resourceCulture);
            }
        }

        internal static string TerminateScreen_ConfirmDialog_Wait
        {
            get
            {
                return ResourceManager.GetString("TerminateScreen_ConfirmDialog_Wait", resourceCulture);
            }
        }

        internal static string ValidationResultToTemplateConverter_MustBeValidationResultOrValidationError
        {
            get
            {
                return ResourceManager.GetString("ValidationResultToTemplateConverter_MustBeValidationResultOrValidationError", resourceCulture);
            }
        }
    }
}
