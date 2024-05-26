using AutomationSystem.Models;
using AutomationSystem.Models.DataAccess;
using AutomationSystem.ViewModels;
using System.Windows;
using System.Windows.Controls;

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

    private void DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
    {
        if (e.EditingElement is TextBox textBox) // Assuming you're editing a TextBox
        {
            string editedValue = textBox.Text;
            MessageBox.Show($"Edited value: {editedValue}");
        }
    }

    // Row edit trigger event that executes Edit Command in ViewModel
    private void DataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
    {
        if (e.EditAction == DataGridEditAction.Commit)
        {
            mainWindowViewModel.RowEditEndingCommand.Execute(e.Row.DataContext);
            ObjectModel editedObject = e.Row.DataContext as ObjectModel;
        }
    }

    private void TreeView_SelectedSignalItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
    {
        if (e.NewValue is IItem)
        {
            mainWindowViewModel.SelectedHierarchyItem = (IItem)e.NewValue; 
        }
    }

}