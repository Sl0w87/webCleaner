using System.IO;

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

        public override void deleteActiveLogins(bool force)
        {
            if (force)
            {
                DeleteFiles(applicationData, "*Login Data*");
                DeleteFiles(commonApplicationData, "*Login Data*");
            }
            else
            {
                DeleteSqlData(Path.Combine(applicationData, "Login Data"), "logins");
                DeleteSqlData(Path.Combine(commonApplicationData, "Login Data"), "logins");
            }
        }

        public override void deleteCache(bool force)
        {
            DeleteFiles(applicationData, "*Cache*");
            DeleteFiles(commonApplicationData, "*Cache*");
            DeleteFiles(applicationData, "*Application Cache\\Cache*");
            DeleteFiles(commonApplicationData, "*Application Cache\\Cache*");
            DeleteFiles(applicationData, "*Media Cache*");
            DeleteFiles(commonApplicationData, "*Media Cache*");
            DeleteFiles(applicationData, "*GPUCache*");
            DeleteFiles(commonApplicationData, "*GPUCache*");
        }

        public override void deleteCookies(bool force)
        {
            if (force)
            {
                DeleteFiles(applicationData, "*Cookies*");
                DeleteFiles(commonApplicationData, "*Cookies*");
            }
            else
            {
                DeleteSqlData(Path.Combine(applicationData, "Cookies"), "Cookies");
                DeleteSqlData(Path.Combine(commonApplicationData, "Cookies"), "Cookies");
            }            
        }

        public override void deleteDownloadHistory(bool force)
        {
            DeleteSqlData(Path.Combine(applicationData, "History"), "downloads");
            DeleteSqlData(Path.Combine(commonApplicationData, "History"), "downloads");                            
        }

        public override void deleteFormData(bool force)
        {
            if (force)
            {
                DeleteFiles(applicationData, "*Web Data*");
                DeleteFiles(commonApplicationData, "*Web Data*");
            }
            else
            {
                DeleteSqlData(Path.Combine(applicationData, "Web Data"), "autofill");
                DeleteSqlData(Path.Combine(commonApplicationData, "Web Data"), "autofill");
                DeleteSqlData(Path.Combine(applicationData, "Web Data"), "autofill_model_type_state");
                DeleteSqlData(Path.Combine(commonApplicationData, "Web Data"), "autofill_model_type_state");
                DeleteSqlData(Path.Combine(applicationData, "Web Data"), "autofill_profile_emails");
                DeleteSqlData(Path.Combine(commonApplicationData, "Web Data"), "autofill_profile_emails");
                DeleteSqlData(Path.Combine(applicationData, "Web Data"), "autofill_profile_phones");
                DeleteSqlData(Path.Combine(commonApplicationData, "Web Data"), "autofill_profile_phones");
                DeleteSqlData(Path.Combine(applicationData, "Web Data"), "autofill_profiles");
                DeleteSqlData(Path.Combine(commonApplicationData, "Web Data"), "autofill_profiles");
                DeleteSqlData(Path.Combine(applicationData, "Web Data"), "autofill_profiles_trash");
                DeleteSqlData(Path.Combine(commonApplicationData, "Web Data"), "autofill_profiles_trash");
                DeleteSqlData(Path.Combine(applicationData, "Web Data"), "autofill_sync_metadata");
                DeleteSqlData(Path.Combine(commonApplicationData, "Web Data"), "autofill_sync_metadata");
                DeleteSqlData(Path.Combine(applicationData, "Web Data"), "creditcards");
                DeleteSqlData(Path.Combine(commonApplicationData, "Web Data"), "creditcards");
                DeleteSqlData(Path.Combine(applicationData, "Web Data"), "ie7_logins");
                DeleteSqlData(Path.Combine(commonApplicationData, "Web Data"), "ie7_logins");
                DeleteSqlData(Path.Combine(applicationData, "Web Data"), "keywords");
                DeleteSqlData(Path.Combine(commonApplicationData, "Web Data"), "keywords");
                DeleteSqlData(Path.Combine(applicationData, "Web Data"), "masked_credit_cards");
                DeleteSqlData(Path.Combine(commonApplicationData, "Web Data"), "masked_credit_cards");
                DeleteSqlData(Path.Combine(applicationData, "Web Data"), "server_addresses");
                DeleteSqlData(Path.Combine(commonApplicationData, "Web Data"), "server_addresses");
            }
        }

        public override void deleteHistory(bool force)
        {
            if (force)
            {
                DeleteFiles(applicationData, "*History*");
                DeleteFiles(commonApplicationData, "*History*");
            }
            else
            {
                DeleteSqlData(Path.Combine(applicationData, "History"), "downloads");
                DeleteSqlData(Path.Combine(commonApplicationData, "History"), "downloads");
                DeleteSqlData(Path.Combine(applicationData, "History"), "keyword_search_terms");
                DeleteSqlData(Path.Combine(commonApplicationData, "History"), "keyword_search_terms");
                DeleteSqlData(Path.Combine(applicationData, "History"), "urls");
                DeleteSqlData(Path.Combine(commonApplicationData, "History"), "urls");
                DeleteSqlData(Path.Combine(applicationData, "History"), "visits");
                DeleteSqlData(Path.Combine(commonApplicationData, "History"), "visits");
                DeleteSqlData(Path.Combine(applicationData, "History"), "visit_source");
                DeleteSqlData(Path.Combine(commonApplicationData, "History"), "visit_source");
            }
        }

        public override void deletePasswords(bool force)
        {
            deleteActiveLogins(force);
        }

        public override void deleteTemporaryInternetFiles(bool force)
        {
            deleteCache(force);
        }

        public override string ProcessName()
        {
            return "chrome";
        }
    }
}