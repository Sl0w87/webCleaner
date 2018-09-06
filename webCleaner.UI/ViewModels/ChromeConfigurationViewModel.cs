using webCleaner.Models;

namespace webCleaner.ViewModels
{
    internal class ChromeConfigurationViewModel: AbstractConfigurationViewModel<ChromeConfigruationModel>
    {
        public ChromeConfigurationViewModel()
        {
            Configuration = new ChromeConfigruationModel();
        }
    }
}
