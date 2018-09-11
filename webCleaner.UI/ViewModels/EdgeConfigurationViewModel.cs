using webCleaner.Models;
using webCleaner.Mvvm;
using webCleaner.Services;

namespace webCleaner.ViewModels
{
    public class EdgeConfigurationViewModel: BindableBase
    {
        private readonly IConfigurationService _service;
        private ConfigurationModel model;

        public EdgeConfigurationViewModel(IConfigurationService service)
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
            get { return model.Edge.Active; }
            set
            {
                model.Edge.Active = value;
                Save();
            }
        }

        public bool Cache
        {
            get { return model.Edge.Cache; }
            set
            {
                model.Edge.Cache = value;
                Save();
            }
        }

        public bool Cookies
        {
            get { return model.Edge.Cookies; }
            set
            {
                model.Edge.Cookies = value;
                Save();
            }
        }

        public bool Downloads
        {
            get { return model.Edge.Downloads; }
            set
            {
                model.Edge.Downloads = value;
                Save();
            }
        }

        public bool FormData
        {
            get { return model.Edge.FormData; }
            set
            {
                model.Edge.FormData = value;
                Save();
            }
        }

        public bool History
        {
            get { return model.Edge.History; }
            set
            {
                model.Edge.History = value;
                Save();
            }
        }

        public bool Passwords
        {
            get { return model.Edge.Passwords; }
            set
            {
                model.Edge.Passwords = value;
                Save();
            }
        }
    }
}
