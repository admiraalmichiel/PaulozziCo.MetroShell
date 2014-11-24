using System;
using System.Windows.Data;
using PaulozziCo.MetroShell.Utilities;

namespace PaulozziCo.MetroShell.Presentation.Converters
{
    public class LocalizedStringsConverter : IValueConverter
    {
        #region Constants

        private const string STR_Settings = "settings";
        private const string STR_ThemeColors = "theme colors";
        private const string STR_Effects = "effects";
        private const string STR_ShowOpenEffect = "Show open effect";
        private const string STR_ShowScreenTitle = "Show screen title";
        private const string STR_ShowCloseEffect = "Show close effect";
        private const string STR_ShowPageChangeEffect = "Show page change effect";
        private const string STR_Colors = "Colors";
        private const string STR_BackgroundColors = "Background colors";
        private const string STR_More = "More";
        private const string STR_RibbonPosition = "Ribbon position";
        private const string STR_ChangePassword = "Change Password";

        #endregion

        #region Readonly

        private static readonly string[] ColorsText = { STR_Colors, "Cores", "Colores", "Farben" };

        private static readonly string[] BackgroudColorsText = { STR_BackgroundColors, "Cores de fundo", "Colores de fondo", "Hintergrundfarben" };

        private static readonly string[] HeaderEffectsText = { "layout and effects", "layout e efeitos", "diseño y efectos", "layout und effekten" };

        private static readonly string[] HeaderThemeColorsText = { STR_ThemeColors, "cores do tema", "colores del tema", "designfarben" };

        private static readonly string[] RibbonPositionText = { STR_RibbonPosition, "Posição da barra", "Posición de la barra", "Bar possition" };

        private static readonly string[] MainHeaderText = { "Settings", "Configurações", "Ajustes", "Einstellungen" };

        private static readonly string[] ShowCloseEffectText = { "Display animation when closing", "Exibir animação ao fechar", "Visualización de animaciones al cierre", "Anzeige animation beim Schließen" };

        private static readonly string[] ShowOpenEffectText = { "Display animation when opening", "Exibir animação ao abrir", "Visualización de animaciones al abrir", "Anzeige animation beim Öffnen" };

        private static readonly string[] ShowPageChangeEffectText = { "Display animation when switching page", "Exibir animação ao mudar de página", "Visualización de animaciones al cambiar de página", "Anzeige animation beim einschalten seite" };

        private static readonly string[] ShowScreenTitleText = { STR_ShowScreenTitle, "Exibir título da tela", "Ver la pantalla de título", "Alle Titel-Bildschirm" };

        private static readonly string[] MoreText = { STR_More, "Mais", "Más", "Mehr" };

        private static readonly string[] ChangePasswordText = { "Change Password", "Alterar senha", "Cambiar contraseña", "Kennwort ändern" };

        #endregion

        #region Public Methods

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            String val = value.ToString();
            String result = String.Empty;

            switch (val)
            {
                case STR_Settings:
                    result = MainHeaderText[CultureHelper.CurrentCultureIndex];
                    break;
                case STR_ThemeColors:
                    result = HeaderThemeColorsText[CultureHelper.CurrentCultureIndex];
                    break;
                case STR_Effects:
                    result = HeaderEffectsText[CultureHelper.CurrentCultureIndex];
                    break;
                case STR_RibbonPosition:
                    result = RibbonPositionText[CultureHelper.CurrentCultureIndex];
                    break;
                case STR_ShowOpenEffect:
                    result = ShowOpenEffectText[CultureHelper.CurrentCultureIndex];
                    break;
                case STR_ShowScreenTitle:
                    result = ShowScreenTitleText[CultureHelper.CurrentCultureIndex];
                    break;
                case STR_ShowCloseEffect:
                    result = ShowCloseEffectText[CultureHelper.CurrentCultureIndex];
                    break;
                case STR_ShowPageChangeEffect:
                    result = ShowPageChangeEffectText[CultureHelper.CurrentCultureIndex];
                    break;
                case STR_Colors:
                    result = ColorsText[CultureHelper.CurrentCultureIndex];
                    break;
                case STR_BackgroundColors:
                    result = BackgroudColorsText[CultureHelper.CurrentCultureIndex];
                    break;
                case STR_More:
                    result = MoreText[CultureHelper.CurrentCultureIndex];
                    break;
                case STR_ChangePassword:
                    result = ChangePasswordText[CultureHelper.CurrentCultureIndex];
                    break;
                default:
                    result = val;
                    break;
            }

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException("The LocalizedStringsConverter.ConvertBack method is not supported.");
        }

        #endregion

    }
}
