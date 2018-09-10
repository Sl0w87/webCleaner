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
    }
}
