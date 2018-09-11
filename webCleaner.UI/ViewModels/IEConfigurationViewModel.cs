using webCleaner.Models;
using webCleaner.Mvvm;
using webCleaner.Services;

namespace webCleaner.ViewModels
{
    public class IEConfigurationViewModel: BindableBase
    {
        private readonly IConfigurationService _service;
        private ConfigurationModel model;

        public IEConfigurationViewModel(IConfigurationService service)
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
            get { return model.IE.Active; }
            set
            {
                model.IE.Active = value;
                Save();
            }
        }

        public bool Cache
        {
            get { return model.IE.Cache; }
            set
            {
                model.IE.Cache = value;
                Save();
            }
        }

        public bool Cookies
        {
            get { return model.IE.Cookies; }
            set
            {
                model.IE.Cookies = value;
                Save();
            }
        }

        public bool Downloads
        {
            get { return model.IE.Downloads; }
            set
            {
                model.IE.Downloads = value;
                Save();
            }
        }

        public bool FormData
        {
            get { return model.IE.FormData; }
            set
            {
                model.IE.FormData = value;
                Save();
            }
        }

        public bool History
        {
            get { return model.IE.History; }
            set
            {
                model.IE.History = value;
                Save();
            }
        }

        public bool Passwords
        {
            get { return model.IE.Passwords; }
            set
            {
                model.IE.Passwords = value;
                Save();
            }
        }
    }
}
