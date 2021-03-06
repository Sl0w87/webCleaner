﻿using webCleaner.Models;
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
            model = _service.Load();
        }

        private void Save()
        {
            _service.Save(model);
        }
        
        public bool IsActive
        {
            get { return model.Chrome.Active; }
            set
            {
                model.Chrome.Active = value;
                Save();
            }
        }

        public bool Cache
        {
            get { return model.Chrome.Cache; }
            set
            {
                model.Chrome.Cache = value;
                Save();
            }
        }

        public bool Cookies
        {
            get { return model.Chrome.Cookies; }
            set
            {
                model.Chrome.Cookies = value;
                Save();
            }
        }

        public bool Downloads
        {
            get { return model.Chrome.Downloads; }
            set
            {
                model.Chrome.Downloads = value;
                Save();
            }
        }

        public bool FormData
        {
            get { return model.Chrome.FormData; }
            set
            {
                model.Chrome.FormData = value;
                Save();
            }
        }

        public bool History
        {
            get { return model.Chrome.History; }
            set
            {
                model.Chrome.History = value;
                Save();
            }
        }

        public bool Passwords
        {
            get { return model.Chrome.Passwords; }
            set
            {
                model.Chrome.Passwords = value;
                Save();
            }
        }
    }
}
