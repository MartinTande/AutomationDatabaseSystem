using AutomationSystem.Models;
using AutomationSystem.Models.DataAccess;
using AutomationSystem.ViewModels;
using System.Windows;

namespace AutomationSystem.Views
{
    /// <summary>
    /// Interaction logic for EditTagWindow.xaml
    /// </summary>
    public partial class EditTagWindow : Window
    {
        public EditTagWindow(IDataConnector dataConnector, TagModel selectedTag)
        {
            EditTagViewModel editTagViewModel = new EditTagViewModel(dataConnector, selectedTag);
            this.DataContext = editTagViewModel;
            Loaded += EditTagWindow_Loaded;
            InitializeComponent();
        }

        private void EditTagWindow_Loaded(object sender, RoutedEventArgs e)
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
