using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using webCleaner.Mvvm;
using webCleaner.Services;

namespace webCleaner.ViewModels
{
    internal class CultureViewModel: BindableBase
    {
        public CultureViewModel()
        {
            OnCultureClick = new DelegateCommand(OnCultureClick_Execute);
            _Cultures = new List<CultureInfo>()
            {
                new CultureInfo("de-DE"),
                new CultureInfo("en-US")
            };
        }

        private void OnCultureClick_Execute(object culture) => CultureService.SetCurrentCulture((CultureInfo)culture);

        private List<CultureInfo> _Cultures;
        public List<CultureInfo> Cultures { get => _Cultures; set => _Cultures = value; }

        public DelegateCommand OnCultureClick { get; set; }
        
        
    }
}