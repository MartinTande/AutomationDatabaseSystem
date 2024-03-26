using AutomationSystem.Categories;
using AutomationSystemLibrary.Data;
using AutomationSystemLibrary.Models;
using AutomationSystemUI.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace AutomationSystemUI.ViewModels
{
    internal class AddObjectViewModel
    {
        public ICommand AddObjectCommand { get; set; }

        public int SfiNumber { get; set; }
        public string MainEqNumber { get; set; }
        public string EqNumber { get; set; }
        public string ObjectDescription { get; set; }
        public ObservableCollection<string> Hierarchy1Names { get; set; }
        public ObservableCollection<string> Hierarchy2Names { get; set; }
        public ObservableCollection<string> VduGroupNames { get; set; }
        public ObservableCollection<string> AlarmGroupNames { get; set; }
        public ObservableCollection<string> OtdNames { get; set; }
        public ObservableCollection<string> AcknowledgeAllowedLocations { get; set; }
        public ObservableCollection<string> AlwaysVisibleLocations { get; set; }
        public ObservableCollection<string> NodeNames { get; set; }
        public ObservableCollection<string> CabinetNames { get; set; }
        public string DataBlockName { get; set; }

        public AddObjectViewModel()
        {
            AddObjectCommand = new RelayCommand(AddObject, CanAddObject);
            CategoryDataManager categoryDataManager = new CategoryDataManager();

            Hierarchy1Names = new ObservableCollection<string>(categoryDataManager.GetHierarchy1Category());
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

            newTagObject.SfiNumber = SfiNumber;
            newTagObject.MainEqNumber = MainEqNumber;
            newTagObject.EqNumber = EqNumber;
            newTagObject.ObjectDescription = ObjectDescription;
            //newTagObject.Hierarchy1Name = Hierarchy1Name;
            //newTagObject.Hierarchy2Name = Hierarchy2Name;
            //newTagObject.VduGroupName = VduGroupName;
            //newTagObject.AlarmGroupName = AlarmGroupName;
            //newTagObject.OtdName = OtdName;
            //newTagObject.AlwaysVisibleLocation = AlwaysVisibleLocation;
            //newTagObject.AcknowledgeAllowedLocation = AcknowledgeAllowedLocation;
            //newTagObject.NodeName = NodeName;
            //newTagObject.CabinetName = CabinetName;
            newTagObject.DataBlockName = DataBlockName;

            dataManager.InsertTagObject(newTagObject);

        }
    }
}
