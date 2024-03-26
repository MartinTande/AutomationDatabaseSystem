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
    /// Interaction logic for TextboxWithLabel.xaml
    /// </summary>
    public partial class TextboxWithLabel : UserControl
    {
        public TextboxWithLabel()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Clear();
            txtInput.Focus();
        }

        public static readonly DependencyProperty LabelTextProperty =
            DependencyProperty.Register("LabelText", typeof(string), typeof(TextboxWithLabel), new PropertyMetadata(""));


        public string LabelText
        {
            get { return (string)GetValue(LabelTextProperty); }
            set { SetValue(LabelTextProperty, value); }
        }


        public string TextboxContent
        {
            get { return (string)GetValue(TextboxContentProperty); }
            set { SetValue(TextboxContentProperty, value); }
        }

        public static readonly DependencyProperty TextboxContentProperty =
            DependencyProperty.Register("TextboxContent", typeof(string), typeof(TextboxWithLabel), new PropertyMetadata(""));

    }
}
