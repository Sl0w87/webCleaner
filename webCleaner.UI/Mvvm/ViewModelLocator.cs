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
            _container.RegisterType<INotifyPropertyChanged, AboutViewModel>();
            _container.RegisterType<INotifyPropertyChanged, CultureViewModel>();
        }

        public AboutViewModel About
        {
            get { return _container.Resolve<AboutViewModel>(); }
        }

        public CultureViewModel Culture
        {
            get { return _container.Resolve<CultureViewModel>(); }
        }
    }
}