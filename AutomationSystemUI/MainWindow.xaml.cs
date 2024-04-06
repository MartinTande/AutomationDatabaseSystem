using AutomationSystemUI.Models;
using AutomationSystemUI.ViewModels;
using System.Windows;


namespace AutomationSystemUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainWindowViewModel mainWindowViewModel;
        public MainWindow()
        {
            mainWindowViewModel = new MainWindowViewModel();
            this.DataContext = mainWindowViewModel;
            Activated += MainWindow_Activated;
            InitializeComponent();
        }

        private void MainWindow_Activated(object sender, System.EventArgs e)
        {
            if (DataContext is ICloseable viewModel)
            {
                viewModel.Close += () =>
                {
                    this.Close();
                };
            }
        }

        /// <summary>
        /// Gets the selected picture hierachy item and sends it to the selectedHierarchyItem in the main view model 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (e.NewValue is IItem)
            {
                mainWindowViewModel.SelectedHierarchyItem = (IItem)e.NewValue;
            }
        }
    }
}
