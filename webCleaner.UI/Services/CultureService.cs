using System;
using System.Globalization;
using System.Windows;

namespace webCleaner.Services
{
    public interface ICultureService
    {
        void SetCurrentCulture(CultureInfo culture);
        void LoadCulture();
    }

    public class CultureService: ICultureService
    {
        public CultureService()
        {
            LoadCulture();
        }
        public void SetCurrentCulture(CultureInfo culture)
        {
            Properties.Settings.Default.Culture = culture.ToString();
            Properties.Settings.Default.Save();
            LoadCulture();
        }

        public void LoadCulture()
        {
            var culture = Properties.Settings.Default.Culture;
            ResourceDictionary dict = new ResourceDictionary();
            switch (culture.ToString())
            {
                case "de-DE":
                    dict.Source = new Uri("..\\Resources\\Strings.de-DE.xaml",
                                  UriKind.Relative);
                    break;
                default:
                    dict.Source = new Uri("..\\Resources\\Strings.xaml",
                                      UriKind.Relative);
                    break;
            }
            Application.Current.Resources.MergedDictionaries.Add(dict);
        }
    }
}
