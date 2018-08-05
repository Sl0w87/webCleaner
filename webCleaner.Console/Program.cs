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
        public string Browser { get; set; }
        [Option(Description = "Defines what data to delete.")]
        public string Data { get; set; }

        private IBrowser getBrowser()
        {
            if (string.IsNullOrEmpty(Browser))
                return null;
            BrowserOptions browserOption;
            if (!Enum.TryParse<BrowserOptions>(Browser, true, out browserOption))
                return null; 
            return Factory.GetBrowser(browserOption);
        }

        private DeleteOption getDeleteOption()
        {
            if (string.IsNullOrEmpty(Data))
                return DeleteOption.Undefined;
            DeleteOption deleteOption;
            if (!Enum.TryParse<DeleteOption>(Browser, true, out deleteOption))
                return DeleteOption.Undefined;
            return deleteOption;
        }

        public int OnExecute(IConsole console)
        {
            var browser = getBrowser();
            if (browser == null)
            {
                var validBrowser = String.Join(", ", Enum.GetNames(typeof(BrowserOptions)));
                Console.Write($"No valid browser is set. Valid options [{validBrowser}]");                   
                return 1;
            }

            var option = getDeleteOption();
            if (option == DeleteOption.Undefined)
            {
                var validOption = String.Join(", ", Enum.GetNames(typeof(DeleteOption)));
                validOption.Remove(0);
                Console.Write($"No valid data is set. Valid options [{validOption}]");
                return 2;
            }
              
            console.WriteLine($"Clearing {Browser} data.");
            browser.Delete(option);
            
            console.WriteLine($"Finished clearing {Browser} data.");
            return 0;
        }
    }
}
