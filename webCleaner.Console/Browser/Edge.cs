using System;
using System.Diagnostics;
using System.IO;
using webCleaner.Commands;

namespace webCleaner.Browser
{
    public class Edge : AbstractBrowser
    {        
        public override string ProcessName()
        {
            return "MicrosoftEdge";
        }
        public override void Delete(DeleteOption opt, bool force = false)
        {
            CloseProcess();
            switch (opt)
            {
                case DeleteOption.All:
                    Process.Start("RundDll32.exe", "InetCpl.cpl,ClearMyTracksByProcess 255").WaitForExit();
                    break;
                case DeleteOption.Cookies:
                    Process.Start("RundDll32.exe", "InetCpl.cpl,ClearMyTracksByProcess 2").WaitForExit();
                    break;
                case DeleteOption.FormData:
                    Process.Start("RundDll32.exe", "InetCpl.cpl,ClearMyTracksByProcess 16").WaitForExit();
                    break;
                case DeleteOption.History:
                    Process.Start("RundDll32.exe", "InetCpl.cpl,ClearMyTracksByProcess 1").WaitForExit();
                    break;                
                case DeleteOption.Passwords:
                    Process.Start("RundDll32.exe", "InetCpl.cpl,ClearMyTracksByProcess 32").WaitForExit();
                    break;
                default:
                    break;
            }
        }
    }
}