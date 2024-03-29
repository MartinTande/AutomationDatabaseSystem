using AutomationSystemLibrary.Data;
using AutomationSystemLibrary.Models;
using AutomationSystemUI.Commands;
using AutomationSystemUI.MVVM;
using AutomationSystemUI.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace AutomationSystemUI.ViewModels
{
    internal class AddObjectViewModel : ViewModelBase
    {
        public ICommand AddObjectCommand { get; set; }
        CategoryDataManager categoryDataManager;

        // Lists of category names retrieved from database
        public ObservableCollection<string> Hierarchy1Names { get; set; }
        public ObservableCollection<string> Hierarchy2Names { get; set; }
        public ObservableCollection<string> VduGroupNames { get; set; }
        public ObservableCollection<string> AlarmGroupNames { get; set; }
        public ObservableCollection<string> OtdNames { get; set; }
        public ObservableCollection<string> AcknowledgeAllowedLocations { get; set; }
        public ObservableCollection<string> AlwaysVisibleLocations { get; set; }
        public ObservableCollection<string> NodeNames { get; set; }
        public ObservableCollection<string> CabinetNames { get; set; }

        // Selected category names by user 
        private string _selectedHierarchy1;
        public string SelectedHierarchy1
        {
            get { return _selectedHierarchy1; }
            set
            {
                _selectedHierarchy1 = value;
                OnPropertyChanged();
                UpdateHierarchy2Names();
            }
        }
        private void UpdateHierarchy2Names()
        {
            try
            {
                if (Hierarchy2Names != null)
                {
                    Hierarchy2Names.Clear();
                }
                var update = new ObservableCollection<string>(categoryDataManager.GetHierarchy2Category(SelectedHierarchy1));
                foreach (var item in update)
                {
                    Hierarchy2Names.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating Hierarchy2Names: {ex.Message}");
            }
        }

        private string _selectedHierarchy2;
        public string SelectedHierarchy2
        {
            get { return _selectedHierarchy2; }
            set 
            { 
                _selectedHierarchy2 = value;
                OnPropertyChanged();
            }
        }

        private string _selectedVduGroup;
        public string SelectedVduGroup
        {
            get { return _selectedVduGroup; }
            set 
            { 
                _selectedVduGroup = value; 
                OnPropertyChanged();
            }
        }
        private string _selectedAlarmGroup;
        public string SelectedAlarmGroup
        {
            get { return _selectedAlarmGroup; }
            set 
            { 
                _selectedAlarmGroup = value; 
                OnPropertyChanged();
            }
        }
        private string _selectedOtd;
        public string SelectedOtd
        {
            get { return _selectedOtd; }
            set 
            { 
                _selectedOtd = value;
                OnPropertyChanged();
            }
        }
        private string _selectedAcknowledgeAllowed;
        public string SelectedAcknowledgeAllowed
        {
            get { return _selectedAcknowledgeAllowed; }
            set 
            { 
                _selectedAcknowledgeAllowed = value; 
                OnPropertyChanged();
            }
        }
        private string _selectedAlwaysVisible;
        public string SelectedAlwaysVisible
        {
            get { return _selectedAlwaysVisible; }
            set 
            { 
                _selectedAlwaysVisible = value; 
                OnPropertyChanged();
            }
        }
        private string _selectedNode;
        public string SelectedNode
        {
            get { return _selectedNode; }
            set 
            { 
                _selectedNode = value; 
                OnPropertyChanged();
            }
        }
        private string _selectedCabinet;
        public string SelectedCabinet
        {
            get { return _selectedCabinet; }
            set 
            { 
                _selectedCabinet = value; 
                OnPropertyChanged();
            }
        }

        // User input parameters
        private int _sfiNumberInput;
        public int SfiNumberInput
        {
            get { return _sfiNumberInput; }
            set
            {
                _sfiNumberInput = value;
                OnPropertyChanged();
            }
        }

        private string _mainEqNumberInput;
        public string MainEqNumberInput
        {
            get { return _mainEqNumberInput; }
            set
            {
                _mainEqNumberInput = value;
                OnPropertyChanged();
            }
        }

        private string _eqNumberInput;
        public string EqNumberInput
        {
            get { return _eqNumberInput; }
            set
            {
                _eqNumberInput = value;
                OnPropertyChanged();
            }
        }

        private string _objectDescriptionInput;
        public string ObjectDescriptionInput
        {
            get { return _objectDescriptionInput; }
            set
            {
                _objectDescriptionInput = value;
                OnPropertyChanged();
            }
        }
        private string _dataBlockInput;
        public string DataBlockInput
        {
            get { return _dataBlockInput; }
            set 
            { 
                _dataBlockInput = value; 
                OnPropertyChanged();
            }
        }

        public AddObjectViewModel()
        {
            AddObjectCommand = new RelayCommand(AddObject, CanAddObject);
            categoryDataManager = new CategoryDataManager();

            Hierarchy1Names = new ObservableCollection<string>(categoryDataManager.GetHierarchy1Category());
            Hierarchy2Names = new ObservableCollection<string>();
            VduGroupNames = new ObservableCollection<string>(categoryDataManager.GetVduGroupCategory());
            AlarmGroupNames = new ObservableCollection<string>(categoryDataManager.GetAlarmGroupCategory());
            OtdNames = new ObservableCollection<string>(categoryDataManager.GetOtdCategory());
            AcknowledgeAllowedLocations = new ObservableCollection<string>(categoryDataManager.GetAckAllowedCategory());
            AlwaysVisibleLocations = new ObservableCollection<string>(categoryDataManager.GetAlwaysVisibleCategory());
            NodeNames = new ObservableCollection<string>(categoryDataManager.GetNodeCategory());
            CabinetNames = new ObservableCollection<string>(categoryDataManager.GetCabinetCategory());
        }

        private bool CanAddObject(object obj)
        {
            return true;
        }

        private void AddObject(object obj)
        {
            ObjectDataManager dataManager = new ObjectDataManager();
            TagObjectModel newTagObject = new TagObjectModel();

            newTagObject.SfiNumber = SfiNumberInput;
            newTagObject.MainEqNumber = MainEqNumberInput;
            newTagObject.EqNumber = EqNumberInput;
            newTagObject.ObjectDescription = ObjectDescriptionInput;
            newTagObject.Hierarchy1Name = SelectedHierarchy1;
            newTagObject.Hierarchy2Name = SelectedHierarchy2;
            newTagObject.VduGroupName = SelectedVduGroup;
            newTagObject.AlarmGroupName = SelectedAlarmGroup;
            newTagObject.OtdName = SelectedOtd;
            newTagObject.AlwaysVisibleLocation = SelectedAlwaysVisible;
            newTagObject.AcknowledgeAllowedLocation = SelectedAcknowledgeAllowed;
            newTagObject.NodeName = SelectedNode;
            newTagObject.CabinetName = SelectedCabinet;
            newTagObject.DataBlockName = DataBlockInput;

            dataManager.InsertTagObject(newTagObject);
        }
    }
}
