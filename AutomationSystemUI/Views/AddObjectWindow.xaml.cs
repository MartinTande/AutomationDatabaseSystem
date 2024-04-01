using AutomationSystemUI.Commands;
using AutomationSystemUI.ViewModels;
using System.Windows;
using System.Windows.Input;

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
            Loaded += AddObjectWindow_Loaded;
        }

        private void AddObjectWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (DataContext is ICloseable viewModel)
            {
                viewModel.Close += () =>
                {
                    this.Close();
                };
            }
        }
    }
}
