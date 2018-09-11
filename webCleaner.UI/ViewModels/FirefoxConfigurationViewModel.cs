using webCleaner.Models;
using webCleaner.Mvvm;
using webCleaner.Services;

namespace webCleaner.ViewModels
{
    public class FirefoxConfigurationViewModel: BindableBase
    {
        private readonly IConfigurationService _service;
        private ConfigurationModel model;

        public FirefoxConfigurationViewModel(IConfigurationService service)
        {
            _service = service;
            model = _service.Load();
        }

        private void Save()
        {
            _service.Save(model);
        }
        
        public bool IsActive
        {
            get { return model.Firefox.Active; }
            set
            {
                model.Firefox.Active = value;
                Save();
            }
        }

        public bool Cache
        {
            get { return model.Firefox.Cache; }
            set
            {
                model.Firefox.Cache = value;
                Save();
            }
        }

        public bool Cookies
        {
            get { return model.Firefox.Cookies; }
            set
            {
                model.Firefox.Cookies = value;
                Save();
            }
        }

        public bool Downloads
        {
            get { return model.Firefox.Downloads; }
            set
            {
                model.Firefox.Downloads = value;
                Save();
            }
        }

        public bool FormData
        {
            get { return model.Firefox.FormData; }
            set
            {
                model.Firefox.FormData = value;
                Save();
            }
        }

        public bool History
        {
            get { return model.Firefox.History; }
            set
            {
                model.Firefox.History = value;
                Save();
            }
        }

        public bool Passwords
        {
            get { return model.Firefox.Passwords; }
            set
            {
                model.Firefox.Passwords = value;
                Save();
            }
        }
    }
}
