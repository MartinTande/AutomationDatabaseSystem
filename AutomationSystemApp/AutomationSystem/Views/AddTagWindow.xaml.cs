using AutomationSystem.Models.DataAccess;
using AutomationSystem.ViewModels;
using System.Windows;

namespace AutomationSystem.Views
{
    /// <summary>
    /// Interaction logic for AddTagWindow.xaml
    /// </summary>
    public partial class AddTagWindow : Window
    {
        public AddTagWindow(IDataConnector dataConnector, int objectId)
        {
            AddTagViewModel addTagViewModel = new AddTagViewModel(dataConnector, objectId);
            this.DataContext = addTagViewModel;
            Loaded += AddTagWindow_Loaded;
            InitializeComponent();
        }

        private void AddTagWindow_Loaded(object sender, RoutedEventArgs e)
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
