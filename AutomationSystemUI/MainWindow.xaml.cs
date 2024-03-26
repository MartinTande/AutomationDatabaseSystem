using AutomationSystemLibrary.Data;
using AutomationSystemLibrary.Models;
using AutomationSystemUI.ViewModels;
using Caliburn.Micro;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace AutomationSystemUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            this.DataContext = mainWindowViewModel;
        }
    }
}
