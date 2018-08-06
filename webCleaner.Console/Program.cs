using McMaster.Extensions.CommandLineUtils;
using System;
using webCleaner.Browser;
using webCleaner.Options;

namespace webCleaner
{
    [Command(
        Name = "webCleaner",
        ThrowOnUnexpectedArgument = false
    )]
    [HelpOption]
    class Program
    {
        static void Main(string[] args) => CommandLineApplication.Execute<Program>(args);

        [Option(Description = "Defines the browser.")]
        [BrowserAttribute]
        public (bool HasValue, BrowserOption option) Browser { get; set; }
        [Option(Description = "Defines what data to delete.")]
        public (bool HaseValue, DeleteOption option) Data { get; set; }
        
        public int OnExecute(CommandLineApplication app, IConsole console)
        {
            if (!Browser.HasValue && !Data.HaseValue)
            {
                app.ShowHelp();
                return 0;
            }

            app.HelpOption(inherited: true);
            if (!Browser.HasValue)
            {
                var validBrowser = String.Join(", ", Enum.GetNames(typeof(BrowserOption)));
                console.Error.Write($"No valid browser is set. Valid options [{validBrowser}]");
                app.ShowHelp();
                return 1;
            }

            if (!Data.HaseValue)
            {
                var validOption = String.Join(", ", Enum.GetNames(typeof(DeleteOption)));
                console.Write($"No valid data is set. Valid options [{validOption}]");
                app.ShowHelp();
                return 2;
            }

            IBrowser browser = Factory.GetBrowser(Browser.option);
            console.WriteLine($"Clearing {Browser.option} ({Data.option}).");
            browser.Delete(Data.option);

            console.WriteLine($"Finished clearing {Browser.option} ({Data.option}).");
            return 0;
        }
    }
}
