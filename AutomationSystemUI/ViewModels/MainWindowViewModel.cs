using System.Collections.ObjectModel;
using AutomationSystemLibrary.Models;
using AutomationSystemLibrary.Data;
using System.Windows.Input;
using AutomationSystemUI.Commands;
using AutomationSystemUI.Views;
using AutomationSystemUI.MVVM;
using System;
using System.Windows;
using AutomationSystemUI.Models;
using AutomationSystemLibrary.Categories;


namespace AutomationSystemUI.ViewModels
{

    internal class MainWindowViewModel : ViewModelBase
    {
        ObjectDataManager dataManager;
        CategoryDataManager categoryDataManager;
        
        public ObservableCollection<HierarchyModel> BilgeCollection {  get; set; } = new ObservableCollection<HierarchyModel>();
        public ObservableCollection<HierarchyModel> CoolingCollection {  get; set; } = new ObservableCollection<HierarchyModel> { };
        public ObservableCollection<HierarchyModel> FireSystemCollection { get; set; } = new ObservableCollection<HierarchyModel> { };
        public ObservableCollection<HierarchyModel> UtilitySystemsCollection {  get; set; } = new ObservableCollection<HierarchyModel> { };
        public ObservableCollection<HierarchyModel> EnginesCollection {  get; set; } = new ObservableCollection<HierarchyModel> { };
        public ObservableCollection<HierarchyModel> SystemCollection { get; set; } = new ObservableCollection<HierarchyModel> { };
        public ObservableCollection<HierarchyModel> FuelAndLubeOilCollection { get; set; } = new ObservableCollection<HierarchyModel> { };
        public ObservableCollection<HierarchyModel> HVACCollection { get; set; } = new ObservableCollection<HierarchyModel> { };
        public ObservableCollection<HierarchyModel> MiscCollection { get; set; } = new ObservableCollection<HierarchyModel> { };
        public ObservableCollection<HierarchyModel> PropulsionCollection { get; set; } = new ObservableCollection<HierarchyModel> { };
        public ObservableCollection<HierarchyModel> SwitchboardCollection { get; set; } = new ObservableCollection<HierarchyModel> { };
        public ObservableCollection<HierarchyModel> TanksCollection { get; set; } = new ObservableCollection<HierarchyModel> { };

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
            categoryDataManager = new CategoryDataManager();
            _tagObjects = new ObservableCollection<TagObjectModel>(dataManager.GetTagObjects());
            PopulateHierarchyCollections();
        }

        private void PopulateHierarchyCollections()
        {
            BilgeCollection = PopulateHierarchyCollection(BilgeCollection, "Bilge");
            CoolingCollection = PopulateHierarchyCollection(CoolingCollection, "Cooling");
            FireSystemCollection = PopulateHierarchyCollection(FireSystemCollection, "Fire System");
            UtilitySystemsCollection = PopulateHierarchyCollection(UtilitySystemsCollection, "Utility Systems");
            EnginesCollection = PopulateHierarchyCollection(EnginesCollection, "Engines");
            SystemCollection = PopulateHierarchyCollection(SystemCollection, "System");
            FuelAndLubeOilCollection = PopulateHierarchyCollection(FuelAndLubeOilCollection, "Fuel and Lube Oil");
            HVACCollection = PopulateHierarchyCollection(HVACCollection, "HVAC");
            MiscCollection = PopulateHierarchyCollection(MiscCollection, "Misc");
            PropulsionCollection = PopulateHierarchyCollection(PropulsionCollection, "Propulsion");
            SwitchboardCollection = PopulateHierarchyCollection(SwitchboardCollection, "Switchboard");
            TanksCollection = PopulateHierarchyCollection(TanksCollection, "Tanks");
        }

        private ObservableCollection<HierarchyModel> PopulateHierarchyCollection(ObservableCollection<HierarchyModel> hierarchyollection, string hierarchy1)
        {
            foreach (string hierarchy2 in categoryDataManager.GetHierarchy2Category(hierarchy1))
            {
                hierarchyollection.Add(new HierarchyModel { hierarchy1Name = hierarchy1, hierarchy2Name = hierarchy2 });
            }
            return hierarchyollection;
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
