using System;
using System.Globalization;
using System.Threading;

namespace HumanitarianProjectManagement.UI
{
    public static class ApplicationStyleManager
    {
        public static event EventHandler LanguageChanged;

        public static void SetLanguage(string cultureName)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureName);
            OnLanguageChanged();
        }

        private static void OnLanguageChanged()
        {
            LanguageChanged?.Invoke(null, EventArgs.Empty);
        }
    }
}
