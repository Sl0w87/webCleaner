using webCleaner.Models;
using webCleaner.Options;

namespace webCleaner.Services
{
    public interface IConfigurationService
    {
        ConfigurationModel Load(BrowserOption browser);
        void Save(ConfigurationModel model);
    }

    public class ConfigurationService: IConfigurationService
    {
        public ConfigurationService()
        {
        }

        public ConfigurationModel Load(BrowserOption browser)
        {
            return new ConfigurationModel();
        }

        public void Save(ConfigurationModel model)
        {

        }        
    }
}