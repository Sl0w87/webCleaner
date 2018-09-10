namespace webCleaner.Models
{
    public class ConfigurationModel
    {
        public bool Active { get; set; }        
        public bool TemporaryInternetFiles { get; set; }
        public bool Cookies { get; set; }
        public bool History { get; set; }
        public bool DownloadHistory { get; set; }
        public bool FormData { get; set; }
        public bool Passwords { get; set; }
        public bool Cache { get; set; }
        public bool ActiveLogins { get; set; }

        public ConfigurationModel()
        {
            Active = true;
            TemporaryInternetFiles = true;
            Cookies = true;
            History = true;
            DownloadHistory = true;
            FormData = true;
            Passwords = true;
            Cache = true;
            ActiveLogins = true;
        }        
    }
}
