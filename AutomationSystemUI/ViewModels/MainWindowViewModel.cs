using System.Collections.ObjectModel;
using AutomationSystemLibrary.Models;
using AutomationSystemLibrary.Data;
using System.Windows.Input;
using AutomationSystemUI.Commands;
using AutomationSystemUI.Views;
using AutomationSystemUI.MVVM;
using System;
using System.ComponentModel;
using System.Windows;


namespace AutomationSystemUI.ViewModels
{

    internal class MainWindowViewModel : ViewModelBase
    {
        ObjectDataManager dataManager;
        private ObservableCollection<TagObjectModel> _tagObjects;
        public ObservableCollection<TagObjectModel> TagObjects
        {
            get { return _tagObjects; }
            set
            {
                if (_tagObjects != value && _tagObjects != null)
                {
                    _tagObjects = value;
                    OnPropertyChanged();
                }
            }
        }

        private TagObjectModel _selectedTagObject;
        public TagObjectModel SelectedTagObject
        {
            get { return _selectedTagObject; }
            set
            {
                _selectedTagObject = value;
                OnPropertyChanged();
            }
        }

        // Commands
        public ICommand ShowAddObjectWindowCommand => new RelayCommand(execute => ShowAddObjectWindow());
        public ICommand ShowEditObjectWindowCommand => new RelayCommand(execute => ShowEditObjectWindow(), canExecute => SelectedTagObject != null);
        public ICommand DeleteObjectCommand => new RelayCommand(execute => DeleteObject(), canExecute => SelectedTagObject != null);

        public MainWindowViewModel()
        {
            // Getting objects for populating datagrid
            dataManager = new ObjectDataManager();
            _tagObjects = new ObservableCollection<TagObjectModel>(dataManager.GetTagObjects());
        }

        private void ShowAddObjectWindow()
        {
            AddObjectWindow addObjectWindow = new AddObjectWindow();
            addObjectWindow.Show();
            addObjectWindow.Closed += AddObjectWindow_Closed;
        }

        private void AddObjectWindow_Closed(object sender, EventArgs e)
        {
            UpdateTagObjects();
        }

        private void ShowEditObjectWindow()
        {
            EditObjectWindow editObjectWindow = new EditObjectWindow(SelectedTagObject);
            MessageBox.Show(SelectedTagObject.ObjectDescription);
            editObjectWindow.Show();
            editObjectWindow.Closed += EditObjectWindow_Closed;
        }

        private void EditObjectWindow_Closed(object sender, EventArgs e)
        {
            UpdateTagObjects();
        }

        private void DeleteObject()
        {
            dataManager.DeleteTagObject(SelectedTagObject.ObjectId);
            MessageBox.Show(SelectedTagObject.ObjectId.ToString());
            UpdateTagObjects();
        }

        private void UpdateTagObjects()
        {
            TagObjects = new ObservableCollection<TagObjectModel>(dataManager.GetTagObjects());
        }
    } 
}
