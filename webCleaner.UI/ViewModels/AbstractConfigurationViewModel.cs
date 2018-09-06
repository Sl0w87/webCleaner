using webCleaner.Models;
using webCleaner.Mvvm;

namespace webCleaner.ViewModels
{
    abstract class AbstractConfigurationViewModel<T> : BindableBase where T: AbstractConfigurationModel
    {
        public AbstractConfigurationModel Configuration { get; set; }
        public bool Active
        {
            get
            {
                return Configuration.Active;
            }
            set
            {
                Configuration.Active = value;
            }
        }
    }
}
