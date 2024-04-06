using AutomationSystem.Models;
using AutomationSystem.Models.DataAccess;
using AutomationSystem.ViewModels;
using System.Windows;

namespace AutomationSystem.Views;

/// <summary>
/// Interaction logic for EditObjectWindow.xaml
/// </summary>
public partial class EditObjectWindow : Window
{
    public EditObjectWindow(IDataConnector dataConnector, ObjectModel selectedTagObject)
    {
        EditObjectViewModel editObjectViewModel = new EditObjectViewModel(dataConnector, selectedTagObject);
        this.DataContext = editObjectViewModel;
        Loaded += EditObjectWindow_Loaded;
        InitializeComponent();
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
