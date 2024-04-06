using AutomationSystem.Models;
using AutomationSystem.Models.DataAccess;
using AutomationSystem.ViewModels;
using System.Windows;

namespace AutomationSystem;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    MainWindowViewModel mainWindowViewModel;
    public MainWindow()
    {
        IDataConnector dataConnector = new SqlConnector(DatabaseConfig.GetConnectionString());
        mainWindowViewModel = new MainWindowViewModel(dataConnector);
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