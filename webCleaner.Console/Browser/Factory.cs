using System;

namespace webCleaner.Browser
{
    internal static class Factory
    {
        public static IBrowser GetBrowser(BrowserType type)
        {
            switch (type)
            {
                case BrowserType.Chrome:
                    return new Chrome();
                case BrowserType.Edge: 
                    return new Edge();
                case BrowserType.FireFox:
                    return new FireFox();
                case BrowserType.IE: 
                    return new IE();
                default: 
                    throw new ArgumentOutOfRangeException("BrowserType not valid.");
            }
        }
    }
}