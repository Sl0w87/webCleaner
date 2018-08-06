using System.Diagnostics;
using System.IO;

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

        public override void deleteActiveLogins(bool force)
        {
            deleteHistory(force);
        }

        public override void deleteCache(bool force)
        {
            deleteHistory(force);
        }

        public override void deleteDownloadHistory(bool force)
        {
            deleteHistory(force);
        }

        public override void deleteTemporaryInternetFiles(bool force)
        {
            Process.Start("RundDll32.exe", "InetCpl.cpl,ClearMyTracksByProcess 8").WaitForExit();
        }

        public override void deleteCookies(bool force)
        {
            Process.Start("RundDll32.exe", "InetCpl.cpl,ClearMyTracksByProcess 2").WaitForExit();
        }

        public override void deleteFormData(bool force)
        {
            Process.Start("RundDll32.exe", "InetCpl.cpl,ClearMyTracksByProcess 16").WaitForExit();
        }

        public override void deleteHistory(bool force)
        {
            Process.Start("RundDll32.exe", "InetCpl.cpl,ClearMyTracksByProcess 1").WaitForExit();
        }

        public override void deletePasswords(bool force)
        {
            Process.Start("RundDll32.exe", "InetCpl.cpl,ClearMyTracksByProcess 32").WaitForExit();
        }

        public override string ProcessName()
        {
            return "iexplore";
        }
        
    }
}