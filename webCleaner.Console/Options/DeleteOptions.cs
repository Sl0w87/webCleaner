using System.ComponentModel;

namespace webCleaner.Options
{
    public enum DeleteOption
    {
        [Description("Cache")]
        Cache,
        [Description("Cookies")]
        Cookies,
        [Description("History")]
        History,
        [Description("Downloads")]
        Downloads,
        [Description("Passwords")]
        Passwords,
        [Description("Form Data")]
        FormData
    }
}

