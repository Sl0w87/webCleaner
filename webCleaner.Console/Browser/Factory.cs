using System;
using webCleaner.Options;

namespace webCleaner.Browser
{
    internal static class Factory
    {
        public static IBrowser GetBrowser(BrowserOption browser)
        {
            switch (browser)
            {
                case BrowserOption.Chrome:
                    return new Chrome();
                case BrowserOption.Edge: 
                    return new Edge();
                case BrowserOption.FireFox:
                    return new FireFox();
                case BrowserOption.IE: 
                    return new IE();
                default: 
                    throw new ArgumentOutOfRangeException("BrowserType not valid.");
            }
        }
    }
}