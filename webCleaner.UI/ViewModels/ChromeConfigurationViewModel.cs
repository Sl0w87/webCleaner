using webCleaner.Models;
using webCleaner.Mvvm;
using webCleaner.Services;

namespace webCleaner.ViewModels
{
    public class ChromeConfigurationViewModel: BindableBase
    {
        private readonly IConfigurationService _service;
        private ConfigurationModel model;

        public ChromeConfigurationViewModel(IConfigurationService service)
        {
            _service = service;
            model = _service.Load(Options.BrowserOption.Chrome);
        }
        
        public bool IsActive
        {
            get { return model.Active; }
            set
            {
                model.Active = value;
                _service.Save(model);
            }
        }

        public bool Cache
        {
            get { return model.Cache; }
            set
            {
                model.Cache = value;
                _service.Save(model);
            }
        }
        
        public bool Cookies
        {
            get { return model.Cookies; }
            set
            {
                model.Cookies = value;
                _service.Save(model);
            }
        }
    }
}
