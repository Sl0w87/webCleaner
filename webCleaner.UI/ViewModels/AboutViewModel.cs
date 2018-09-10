using System.Reflection;
using webCleaner.Mvvm;

namespace webCleaner.ViewModels
{
    public class AboutViewModel : BindableBase
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
