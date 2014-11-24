using System;
using System.Globalization;
using System.Threading;
using System.Windows;

namespace PaulozziCo.MetroShell.Utilities
{
    public static class StringHelper
    {

        #region Public Methods

        /// <summary>
        /// Convert boolean to respective Thread lenguage text
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToLocalizedString(this bool value)
        {
            String result = String.Empty;
            switch (CultureHelper.CurrentCultureLenguage)
            {
                case CultureHelper.CultureLeguage.EN:
                    result = value ? "On" : "Off";
                    break;
                case CultureHelper.CultureLeguage.PT:
                    result = value ? "Ligado" : "Desligado";
                    break;
                case CultureHelper.CultureLeguage.ES:
                    result = value ? "En" : "De";
                    break;
                case CultureHelper.CultureLeguage.DE:
                    result = value ? "Auf" : "Ab";
                    break;
                default:
                    result = value ? "On" : "Off";
                    break;
            }
            return result;
        }

        public static Thickness ToThickness(this string value)
        {
            Double left = 0d, top = 0d, rigth = 0d, botton = 0d;
            string[] separators = {","," "};
            string[] split = value.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            switch (split.Length)
            {
                case 1:
                    left = top = rigth = botton = Convert.ToDouble(split[0]);
                    break;
                case 2:
                    left = rigth = Convert.ToDouble(split[0]);
                    top = botton = Convert.ToDouble(split[1]);
                    break;
                case 4:
                    left = Convert.ToDouble(split[0]);
                    top = Convert.ToDouble(split[1]);
                    rigth = Convert.ToDouble(split[2]);
                    botton = Convert.ToDouble(split[3]);
                    break;
                default:
                    break;
            }

            Thickness result = new Thickness(left, top, rigth, botton);

            return result;
        }

        #endregion

    }
}
