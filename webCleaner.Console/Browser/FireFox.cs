using System.IO;

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

        public override void deleteCache(bool force)
        {
            deleteHistory(force);
        }

        public override void deleteDownloads(bool force)
        {
            DeleteFiles(applicationData, "*handlers*");
            DeleteFiles(commonApplicationData, "*handlers*");
        }

        public override void deleteCookies(bool force)
        {
            if (force)
            {
                DeleteFiles(applicationData, "*Cookies*");
                DeleteFiles(commonApplicationData, "*Cookies*");
                DeleteFiles(applicationData, "*webappsstore*");
                DeleteFiles(commonApplicationData, "*webappsstore*");
            }
            else
            {
                DeleteSqlData(Path.Combine(applicationData, "cookies.sqlite"), "moz_cookies");
                DeleteSqlData(Path.Combine(commonApplicationData, "cookies.sqlite"), "moz_cookies");
                DeleteSqlData(Path.Combine(applicationData, "webappsstore.sqlite"), "moz_webappsstore");
                DeleteSqlData(Path.Combine(commonApplicationData, "webappsstore.sqlite"), "moz_webappsstore");
            }
        }

        public override void deleteFormData(bool force)
        {
            if (force)
            {
                DeleteFiles(applicationData, "*formhistory*");
                DeleteFiles(commonApplicationData, "*formhistory*");
            }
            else
            {
                DeleteSqlData(Path.Combine(applicationData, "formhistory.sqlite"), "moz_formhistory");
                DeleteSqlData(Path.Combine(commonApplicationData, "formhistory.sqlite"), "moz_formhistory");
            }
        }

        public override void deleteHistory(bool force)
        {
            if (force)
            {
                DeleteFiles(applicationData, "*places*");
                DeleteFiles(commonApplicationData, "*places*");
            }
            else
            {
                DeleteSqlData(Path.Combine(applicationData, "places.sqlite"), "moz_historyvisits");
                DeleteSqlData(Path.Combine(commonApplicationData, "places.sqlite"), "moz_historyvisits");
            }
        }

        public override void deletePasswords(bool force)
        {
            DeleteFiles(applicationData, "*key4*");
            DeleteFiles(commonApplicationData, "*key4*");
            DeleteFiles(applicationData, "*logins*");
            DeleteFiles(commonApplicationData, "*logins*");            
        }
    }
}