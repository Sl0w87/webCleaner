using System.IO;
using webCleaner.Options;

namespace webCleaner.Browser
{
    public class Chrome : AbstractBrowser
    {
        public readonly string applicationData;
        public readonly string commonApplicationData;
        public Chrome()
        {
            var path = @"Google\Chrome\User Data\Default\";
            applicationData = Path.Combine(ApplicationData, path);
            commonApplicationData = Path.Combine(CommonApplicationData, path);
        }
        public override string ProcessName()
        {
            return "chrome";
        }
        public override void Delete(DeleteOption opt, bool force = false)
        {
            CloseProcess();
            switch (opt)
            {
                case DeleteOption.Cookies:
                    DeleteFiles(applicationData, "*Cookies*");
                    DeleteFiles(commonApplicationData, "*Cookies*");
                    break;
                case DeleteOption.FormData:                    
                    break;
                case DeleteOption.History:
                    DeleteFiles(applicationData, "*History*");
                    DeleteFiles(commonApplicationData, "*History*");                
                    break;                
                case DeleteOption.Passwords:                    
                    break;
                default:
                    break;
            }
        }
    }
}