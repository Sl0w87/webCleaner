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

        public bool Active
        {
            get { return (bool)GetValue(ActiveProperty); }
            set { SetValue(ActiveProperty, value); }
        }
        public static readonly DependencyProperty ActiveProperty = DependencyProperty.Register("Active", typeof(bool), typeof(ConfigUserControl), null);
    }
}
