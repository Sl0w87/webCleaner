namespace webCleaner.Models
{
    public class ConfigurationModel
    {
        public ConfigurationModel()
        {
            IE = new BrowserConfigurationModel();
            Edge = new BrowserConfigurationModel();
            Chrome = new BrowserConfigurationModel();
            Firefox = new BrowserConfigurationModel();
        }
        public BrowserConfigurationModel IE { get; set; }
        public BrowserConfigurationModel Edge { get; set; }
        public BrowserConfigurationModel Chrome { get; set; }
        public BrowserConfigurationModel Firefox { get; set; }
    }
}
