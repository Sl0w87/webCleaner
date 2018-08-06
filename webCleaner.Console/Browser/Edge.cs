using System.Diagnostics;

namespace webCleaner.Browser
{
    public class Edge : AbstractBrowser
    {        
        public override string ProcessName()
        {
            return "MicrosoftEdge";
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
    }
}