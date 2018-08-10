using System;
using System.Collections.Generic;
using System.Linq;
using webCleaner.Mvvm;

namespace webCleaner.ViewModels
{
    internal class ConfigurationViewModel: BindableBase
    {    

        public int SelectedCultureIndex
        {
            get
            {
                return Cultures.IndexOf(Properties.Settings.Default.Culture);
            }
            set
            {
                Properties.Settings.Default.Culture = Cultures.GetRange(value, 1).FirstOrDefault();
                Properties.Settings.Default.Save();
            }
        }

        public List<string> Cultures
        {
            get
            {
                return new List<string>()
                {
                    "de-DE",
                    "en-US"
                };
            }
        }
    }
}
