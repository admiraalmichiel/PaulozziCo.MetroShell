using System;
using System.Threading;
using System.Globalization;

namespace PaulozziCo.MetroShell.Utilities
{
    public static class CultureHelper
    {
        #region Enums

        public enum CultureLeguage { EN, PT, ES, DE };

        #endregion

        #region Properties

        public static CultureInfo CurrentThreadCulture
        {
            get { return Thread.CurrentThread.CurrentUICulture; }
        }

        public static int CurrentCultureIndex
        {
            get { return GetCurrenteCultureIndex(); }
        }

        public static CultureLeguage CurrentCultureLenguage
        {
            get { return GetCurrentCultureLenguage(); }
        }

        public static string CurrentCultureTwoLetterISO
        {
            get { return CurrentThreadCulture.TwoLetterISOLanguageName.ToLower(); }
        }

        #endregion

        #region Private Methods

        private static CultureLeguage GetCurrentCultureLenguage()
        {
            CultureLeguage result = CultureLeguage.EN;
            switch (CultureHelper.CurrentCultureTwoLetterISO)
            {
                case "":
                case "en":
                    result = CultureLeguage.EN;
                    break;
                case "pt":
                    result = CultureLeguage.PT;
                    break;
                case "es":
                    result = CultureLeguage.ES;
                    break;
                case "de":
                    result = CultureLeguage.DE;
                    break;
                default:
                    result = CultureLeguage.EN;
                    break;
            }
            return result;
        }

        private static int GetCurrenteCultureIndex()
        {
            int result = 0;
            switch (CurrentCultureLenguage)
            {
                case CultureLeguage.EN:
                    result = 0;
                    break;
                case CultureLeguage.PT:
                    result = 1;
                    break;
                case CultureLeguage.ES:
                    result = 2;
                    break;
                case CultureLeguage.DE:
                    result = 3;
                    break;
                default:
                    result = 0;
                    break;
            }
            return result;
        }

        #endregion

    }
}
