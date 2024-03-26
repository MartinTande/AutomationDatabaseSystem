using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AutomationSystemUI.Views.UserControls
{
    /// <summary>
    /// Interaction logic for ComboboxWithLabel.xaml
    /// </summary>
    public partial class ComboboxWithLabel : UserControl
    {
        public ComboboxWithLabel()
        {
            InitializeComponent();
        }

        // Define the dependency property
        public static readonly DependencyProperty LabelTextProperty =
            DependencyProperty.Register("LabelText", typeof(string), typeof(ComboboxWithLabel), new PropertyMetadata(""));


        // Public property to get/set the label text
        public string LabelText
        {
            get { return (string)GetValue(LabelTextProperty); }
            set { SetValue(LabelTextProperty, value); }
        }
    }
}
