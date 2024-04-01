using AutomationSystemLibrary.Models;
using AutomationSystemUI.ViewModels;
using System.Windows;

namespace AutomationSystemUI.Views
{
    /// <summary>
    /// Interaction logic for EditObjectWindow.xaml
    /// </summary>
    public partial class EditObjectWindow : Window
    {
        public EditObjectWindow(TagObjectModel selectedTagObject)
        {
            InitializeComponent();
            EditObjectViewModel editObjectViewModel = new EditObjectViewModel(selectedTagObject);
            this.DataContext = editObjectViewModel;
            Loaded += EditObjectWindow_Loaded;
        }

        private void EditObjectWindow_Loaded(object sender, RoutedEventArgs e)
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
