using System;
using webCleaner.Options;

namespace webCleaner.Browser
{
    internal static class Factory
    {
        public static IBrowser GetBrowser(BrowserOptions browser)
        {
            switch (browser)
            {
                case BrowserOptions.Chrome:
                    return new Chrome();
                case BrowserOptions.Edge: 
                    return new Edge();
                case BrowserOptions.FireFox:
                    return new FireFox();
                case BrowserOptions.IE: 
                    return new IE();
                default: 
                    throw new ArgumentOutOfRangeException("BrowserType not valid.");
            }
        }
    }
}