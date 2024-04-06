using AutomationSystem.Models.DataAccess;
using AutomationSystem.ViewModels;
using System.Windows;

namespace AutomationSystem.Views;

/// <summary>
/// Interaction logic for AddObjectWindow.xaml
/// </summary>
public partial class AddObjectWindow : Window
{

    public AddObjectWindow(IDataConnector dataConnector)
    {
        AddObjectViewModel addObjectViewModel = new AddObjectViewModel(dataConnector);
        this.DataContext = addObjectViewModel;
        Loaded += AddObjectWindow_Loaded;
        InitializeComponent();
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
