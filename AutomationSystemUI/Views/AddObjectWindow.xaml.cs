using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace AutomationSystemUI.Views
{
    /// <summary>
    /// Interaction logic for AddObjectWindow.xaml
    /// </summary>
    public partial class AddObjectWindow : Window, INotifyPropertyChanged
    {
        public AddObjectWindow()
        {
            DataContext = this;
            InitializeComponent();
        }

        private string boundText;

        public event PropertyChangedEventHandler PropertyChanged;


        public string BoundText
        {
            get { return boundText; }
            set
            {
                boundText = value;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs("BoundText"));

            }
        }

    }
}
