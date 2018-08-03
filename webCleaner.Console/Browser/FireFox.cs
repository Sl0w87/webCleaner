using System;
using System.IO;
using webCleaner.Commands;

namespace webCleaner.Browser
{
    public class FireFox : AbstractBrowser
    {
        public readonly string applicationData;
        public readonly string commonApplicationData;
        public FireFox()
        {            
            var path = Path.Combine("Mozilla", "FireFox", "Profiles");
            applicationData = Path.Combine(ApplicationData, path);
            commonApplicationData = Path.Combine(CommonApplicationData, path);  
        }
        public override string ProcessName()
        {
            return "firefox";
        }

        void deleteAll(bool force)
        {
            deleteCookies(force);
            deleteFormData(force);
            deleteHistory(force);
            deletePasswords(force);
        }

        void deleteCookies(bool force)
        {
            if (force)
            {
                DeleteFiles(applicationData, "*Cookies*");
                DeleteFiles(commonApplicationData, "*Cookies*");                    
            }
            else
            {
                DeleteSqlData(Path.Combine(applicationData, "cookies.sqlite"), "moz_cookies");
                DeleteSqlData(Path.Combine(commonApplicationData, "cookies.sqlite"), "moz_cookies");
            }
        }

        void deleteFormData(bool force)
        {
            if (force)
            {
                DeleteFiles(applicationData, "*formhistory*");
                DeleteFiles(commonApplicationData, "*formhistory*");  
            }
            else
            {

            }
        }

        void deleteHistory(bool force)
        {
            if (force)
            {
                DeleteFiles(applicationData, "*places*");
                DeleteFiles(commonApplicationData, "*places*");
            }
            else
            {

            }
        }

        void deletePasswords(bool force)
        {
            if (force)
            {
                DeleteFiles(applicationData, "*key4*");
                DeleteFiles(commonApplicationData, "*key4*");  
                DeleteFiles(applicationData, "*logins*");
                DeleteFiles(commonApplicationData, "*logins*"); 
            }
            else
            {

            }
        }

        public override void Delete(DeleteOption opt, bool force = false)
        {
            if (force)
                CloseProcess();
            switch (opt)
            {
                case DeleteOption.All: 
                    deleteAll(force);                   
                    break;
                case DeleteOption.Cookies:
                    deleteCookies(force);
                    break;
                case DeleteOption.FormData:    
                    deleteFormData(force);               
                    break;
                case DeleteOption.History:
                    deleteHistory(force);                
                    break;                
                case DeleteOption.Passwords:   
                    deletePasswords(force);                 
                    break;
                default:
                    break;
            }
        }
    }
}