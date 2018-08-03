using System.Diagnostics;
using System.IO;
using webCleaner.Commands;

namespace webCleaner.Browser
{
    public class IE : AbstractBrowser
    {
        public readonly string applicationData;
        public readonly string commonApplicationData;
        public IE()
        {            
            var path = @"\Microsoft\Windows\";
            applicationData = Path.Combine(ApplicationData, path);
            commonApplicationData = Path.Combine(CommonApplicationData, path);  
        }
        public override string ProcessName()
        {
            return "iexplore";
        }
        public override void Delete(DeleteOption opt, bool force = false)
        {
            CloseProcess();
            switch (opt)
            {
                
                case DeleteOption.All:                    
                    break;
                case DeleteOption.Cookies:
                    DeleteFiles(Path.Combine(applicationData, "INetCookies"), "*");
                    DeleteFiles(Path.Combine(commonApplicationData, "INetCookies"), "*");
                    break;
                case DeleteOption.FormData:                  
                    break;
                case DeleteOption.History:
                    DeleteFiles(Path.Combine(applicationData, "History"), "*");
                    DeleteFiles(Path.Combine(commonApplicationData, "History"), "*");            
                    break;                
                case DeleteOption.Passwords:                   
                    break;
                default:
                    break;
            }
        }
    }
}