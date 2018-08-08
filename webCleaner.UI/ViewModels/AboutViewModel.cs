using System.Reflection;
using webCleaner.Mvvm;

namespace webCleaner.ViewModels
{
    internal class AboutViewModel : BindableBase
    {
        public string Version
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }
    }
}
