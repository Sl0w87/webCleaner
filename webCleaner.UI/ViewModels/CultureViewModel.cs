using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using webCleaner.Mvvm;
using webCleaner.Services;

namespace webCleaner.ViewModels
{
    public class CultureViewModel: BindableBase
    {
        public CultureViewModel(ICultureService service)
        {
            _service = service;
            OnCultureClick = new DelegateCommand(OnCultureClick_Execute);
            _Cultures = new List<CultureInfo>()
            {
                new CultureInfo("de-DE"),
                new CultureInfo("en-US")
            };
        }

        private void OnCultureClick_Execute(object culture) => _service.SetCurrentCulture((CultureInfo)culture);

        private List<CultureInfo> _Cultures;
        public List<CultureInfo> Cultures { get => _Cultures; set => _Cultures = value; }

        private ICultureService _service;

        public DelegateCommand OnCultureClick { get; set; }
        
        
    }
}