using AutomationSystemUI.ViewModels;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;

namespace AutomationSystemUI.Views
{
    /// <summary>
    /// Interaction logic for AddObjectWindow.xaml
    /// </summary>
    public partial class AddObjectWindow : Window
    {
        public AddObjectWindow()
        {
            InitializeComponent();
            AddObjectViewModel addObjectViewModel = new AddObjectViewModel();
            this.DataContext = addObjectViewModel;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
