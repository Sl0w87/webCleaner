using System.Windows;
using System.Windows.Controls;

namespace webCleaner.Controls
{
    /// <summary>
    /// Interaktionslogik für ConfigUserControl.xaml
    /// </summary>
    public partial class ConfigUserControl : UserControl
    {
        public ConfigUserControl()
        {
            InitializeComponent();
        }

        public bool IsActive
        {
            get { return (bool)GetValue(IsActiveProperty); }
            set { SetValue(IsActiveProperty, value); }
        }
        public static readonly DependencyProperty IsActiveProperty = DependencyProperty.Register("IsActive", typeof(bool), typeof(ConfigUserControl), null);

        public bool Cache
        {
            get { return (bool)GetValue(CacheProperty); }
            set { SetValue(CacheProperty, value); }
        }
        public static readonly DependencyProperty CacheProperty = DependencyProperty.Register("Cache", typeof(bool), typeof(ConfigUserControl), null);

        public bool Cookies
        {
            get { return (bool)GetValue(CookiesProperty); }
            set { SetValue(CookiesProperty, value); }
        }
        public static readonly DependencyProperty CookiesProperty = DependencyProperty.Register("Cookies", typeof(bool), typeof(ConfigUserControl), null);

        public bool Downloads
        {
            get { return (bool)GetValue(DownloadsProperty); }
            set { SetValue(DownloadsProperty, value); }
        }
        public static readonly DependencyProperty DownloadsProperty = DependencyProperty.Register("Downloads", typeof(bool), typeof(ConfigUserControl), null);

        public bool FormData
        {
            get { return (bool)GetValue(FormDataProperty); }
            set { SetValue(FormDataProperty, value); }
        }
        public static readonly DependencyProperty FormDataProperty = DependencyProperty.Register("FormData", typeof(bool), typeof(ConfigUserControl), null);

        public bool History
        {
            get { return (bool)GetValue(HistoryProperty); }
            set { SetValue(HistoryProperty, value); }
        }
        public static readonly DependencyProperty HistoryProperty = DependencyProperty.Register("History", typeof(bool), typeof(ConfigUserControl), null);

        public bool Passwords
        {
            get { return (bool)GetValue(PasswordsProperty); }
            set { SetValue(PasswordsProperty, value); }
        }
        public static readonly DependencyProperty PasswordsProperty = DependencyProperty.Register("Passwords", typeof(bool), typeof(ConfigUserControl), null);
    }
}
