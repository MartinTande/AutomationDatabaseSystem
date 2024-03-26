using System.Collections.ObjectModel;
using AutomationSystemLibrary.Models;
using AutomationSystemLibrary.Data;
using System.Windows.Input;
using AutomationSystemUI.Commands;
using System;
using AutomationSystemUI.Views;


namespace AutomationSystemUI.ViewModels
{

    internal class MainWindowViewModel
    {

        public ObservableCollection<TagObjectModel> TagObjects { get; set; }

        public ICommand ShowAddObjectWindowCommand { get; set; }

        public MainWindowViewModel()
        {
            DataManager dataManager = new DataManager();
            TagObjects = new ObservableCollection<TagObjectModel>(dataManager.GetTagObjects());

            ShowAddObjectWindowCommand = new RelayCommand(ShowAddObjectWindow, CanShowAddObjectWindow);
            
        }

        private bool CanShowAddObjectWindow(object obj)
        {
            return true;
        }

        private void ShowAddObjectWindow(object obj)
        {
            AddObjectWindow addObjectWindow = new AddObjectWindow();
            addObjectWindow.Show();
        }
    } 
}
