using AutomationSystem.Models.DataAccess;
using AutomationSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AutomationSystem.Views
{
    /// <summary>
    /// Interaction logic for AddTagWindow.xaml
    /// </summary>
    public partial class AddTagWindow : Window
    {
        public AddTagWindow(IDataConnector dataConnector)
        {
            AddTagViewModel addTagViewModel = new AddTagViewModel(dataConnector);
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
