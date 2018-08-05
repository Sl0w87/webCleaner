using System.Diagnostics;
using System.IO;
using System.ServiceProcess;

namespace webCleaner.Service
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            eventLog1.WriteEntry("Start running webCleaner.Service.", EventLogEntryType.Information);
            if (!File.Exists("webCleaner.Console.exe"))
            {
                eventLog1.WriteEntry("webCleaner.Console does not exists.", EventLogEntryType.Error);
                return;
            }
            if (!File.Exists("webCleaner.conf"))
            {
                eventLog1.WriteEntry("webCleaner.conf does not exists.", EventLogEntryType.Error);
                return;
            }
            eventLog1.WriteEntry("Reading webCleaner.conf.", EventLogEntryType.Information);

            eventLog1.WriteEntry("Executing webCleaner.Console.", EventLogEntryType.Information);

            eventLog1.WriteEntry("Finished webCleaner.Console.", EventLogEntryType.FailureAudit);
            eventLog1.WriteEntry("Finished webCleaner.Console.", EventLogEntryType.SuccessAudit);

        }

        protected override void OnStop()
        {
            eventLog1.WriteEntry("Stop running webCleaner.Service.", EventLogEntryType.Information);
        }
    }
}
