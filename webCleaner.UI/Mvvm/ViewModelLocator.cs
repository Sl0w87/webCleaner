using System.ComponentModel;
using Unity;
using webCleaner.Services;
using webCleaner.ViewModels;

namespace webCleaner.Mvvm
{
    public class ViewModelLocator
    {
        private readonly UnityContainer _container;
        public ViewModelLocator()
        {
            _container = new UnityContainer();
            _container.RegisterType<ICultureService, CultureService>();
            _container.RegisterType<IConfigurationService, ConfigurationService>();
            _container.RegisterType<INotifyPropertyChanged, AboutViewModel>();
            _container.RegisterType<INotifyPropertyChanged, CultureViewModel>();
            _container.RegisterType<INotifyPropertyChanged, ChromeConfigurationViewModel>();
            _container.RegisterType<INotifyPropertyChanged, FirefoxConfigurationViewModel>();
            _container.RegisterType<INotifyPropertyChanged, IEConfigurationViewModel>();
            _container.RegisterType<INotifyPropertyChanged, EdgeConfigurationViewModel>();
        }

        public AboutViewModel About
        {
            get { return _container.Resolve<AboutViewModel>(); }
        }

        public CultureViewModel Culture
        {
            get { return _container.Resolve<CultureViewModel>(); }
        }

        public ChromeConfigurationViewModel ChromeConfig
        {
            get { return _container.Resolve<ChromeConfigurationViewModel>(); }
        }

        public FirefoxConfigurationViewModel FirefoxConfig
        {
            get { return _container.Resolve<FirefoxConfigurationViewModel>(); }
        }

        public IEConfigurationViewModel IEConfig
        {
            get { return _container.Resolve<IEConfigurationViewModel>(); }
        }

        public EdgeConfigurationViewModel EdgeConfig
        {
            get { return _container.Resolve<EdgeConfigurationViewModel>(); }
        }
    }
}