namespace webCleaner.Models
{
    public class BrowserConfigurationModel
    {
        public bool Active { get; set; }
        public bool Cookies { get; set; }
        public bool History { get; set; }
        public bool Downloads { get; set; }
        public bool FormData { get; set; }
        public bool Passwords { get; set; }
        public bool Cache { get; set; }

        public BrowserConfigurationModel()
        {
            Active = true;
            Cookies = true;
            History = true;
            Downloads = true;
            FormData = true;
            Passwords = true;
            Cache = true;
        }
    }
}