using McMaster.Extensions.CommandLineUtils;
using System;
using webCleaner.Browser;
using webCleaner.Commands;

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

        public int OnExecute(IConsole console)
        {    
            BrowserType browserType;     
            DeleteOption deleteOption;   
            var validBrowser = String.Join(", ", Enum.GetNames(typeof(BrowserType)));
            var validData = String.Join(", ", Enum.GetNames(typeof(DeleteOption)));
            while (string.IsNullOrEmpty(Browser) || !Enum.TryParse<BrowserType>(Browser, true, out browserType))
                Browser = Prompt.GetString($"Choose a browser [{validBrowser}]: ");
                
            while (string.IsNullOrEmpty(Data) || !Enum.TryParse<DeleteOption>(Data, true, out deleteOption))
                Data = Prompt.GetString($"Choose data [{validData}]:");

            var browser = Factory.GetBrowser(browserType);
            if (browser == null)
                throw new ArgumentOutOfRangeException("Browser can't be created.");
            
            console.WriteLine($"Clearing {Browser} data.");
            browser.Delete(deleteOption);
            
            console.WriteLine($"Finished clearing {Browser} data.");
            return 0;
        }
    }
}
