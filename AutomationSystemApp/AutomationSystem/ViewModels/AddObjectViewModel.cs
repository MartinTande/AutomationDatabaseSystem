using AutomationSystem.Commands;
using AutomationSystem.MVVM;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using AutomationSystem.Models.DataManager;
using AutomationSystem.Models;
using AutomationSystem.Models.DataAccess;
using System.Collections.Generic;

namespace AutomationSystem.ViewModels;

internal class AddObjectViewModel : ViewModelBase, ICloseable
{
    private readonly IDataConnector _dataConnector;
    CategoryDataManager categoryDataManager;
    SubCategoryDataManager hierarchyDataManager;
    ObjectDataManager objectDataManager;
    TagDataManager tagDataManager;

    #region Commands
    public ICommand AddObjectCommand => new RelayCommand(execute => AddObject(), canExecute => CanAddObject());
    public ICommand CloseWindowCommand => new RelayCommand(execute => CloseWindow());
    #endregion

    // Lists of category names retrieved from database
    public ObservableCollection<ICategory> Hierarchy1Names { get; set; }
    public ObservableCollection<ICategory> Hierarchy2Names { get; set; }
    public ObservableCollection<ICategory> VduGroupNames { get; set; }
    public ObservableCollection<ICategory> AlarmGroupNames { get; set; }
    public ObservableCollection<ICategory> OtdNames { get; set; }
    public ObservableCollection<ICategory> AcknowledgeAllowedNames { get; set; }
    public ObservableCollection<ICategory> AlwaysVisibleNames { get; set; }
    public ObservableCollection<ICategory> NodeNames { get; set; }
    public ObservableCollection<ICategory> CabinetNames { get; set; }

    #region Selected category names by user 
    private ICategory? _selectedHierarchy1;
    public ICategory? SelectedHierarchy1
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
            var updatedHierarchyName = new ObservableCollection<ICategory>((IEnumerable<ICategory>)hierarchyDataManager.GetHierarchy2Category(SelectedHierarchy1.Name));
            foreach (ICategory item in updatedHierarchyName)
            {
                Hierarchy2Names.Add(item);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error updating Hierarchy2Names: {ex.Message}");
        }
    }

    private ICategory? _selectedHierarchy2;
    public ICategory? SelectedHierarchy2
    {
        get { return _selectedHierarchy2; }
        set
        {
            _selectedHierarchy2 = value;
            OnPropertyChanged();
        }
    }

    private ICategory? _selectedVduGroup;
    public ICategory? SelectedVduGroup
    {
        get { return _selectedVduGroup; }
        set
        {
            _selectedVduGroup = value;
            OnPropertyChanged();
        }
    }
    private ICategory? _selectedAlarmGroup;
    public ICategory? SelectedAlarmGroup
    {
        get { return _selectedAlarmGroup; }
        set
        {
            _selectedAlarmGroup = value;
            OnPropertyChanged();
        }
    }
    private ICategory? _selectedOtd;
    public ICategory? SelectedOtd
    {
        get { return _selectedOtd; }
        set
        {
            _selectedOtd = value;
            OnPropertyChanged();
        }
    }
    private ICategory? _selectedAcknowledgeAllowed;
    public ICategory? SelectedAcknowledgeAllowed
    {
        get { return _selectedAcknowledgeAllowed; }
        set
        {
            _selectedAcknowledgeAllowed = value;
            OnPropertyChanged();
        }
    }
    private ICategory? _selectedAlwaysVisible;
    public ICategory? SelectedAlwaysVisible
    {
        get { return _selectedAlwaysVisible; }
        set
        {
            _selectedAlwaysVisible = value;
            OnPropertyChanged();
        }
    }
    private ICategory? _selectedNode;
    public ICategory? SelectedNode
    {
        get { return _selectedNode; }
        set
        {
            _selectedNode = value;
            OnPropertyChanged();
        }
    }
    private ICategory? _selectedCabinet;
    public ICategory? SelectedCabinet
    {
        get { return _selectedCabinet; }
        set
        {
            _selectedCabinet = value;
            OnPropertyChanged();
        }
    }
    #endregion

    #region User input parameters
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

    private string? _mainEqNumberInput;
    public string? MainEqNumberInput
    {
        get { return _mainEqNumberInput; }
        set
        {
            _mainEqNumberInput = value;
            OnPropertyChanged();
        }
    }

    private string? _eqNumberInput;
    public string? EqNumberInput
    {
        get { return _eqNumberInput; }
        set
        {
            _eqNumberInput = value;
            OnPropertyChanged();
        }
    }

    private string? _objectDescriptionInput;
    public string? DescriptionInput
    {
        get { return _objectDescriptionInput; }
        set
        {
            _objectDescriptionInput = value;
            OnPropertyChanged();
        }
    }

    private string _errorMessage = string.Empty;

    public string ErrorMessage
    {
        get { return _errorMessage; }
        set 
        { 
            _errorMessage = value;
            OnPropertyChanged();
        }
    }

    #endregion

    public AddObjectViewModel(IDataConnector dataConnector)
    {
        _dataConnector = dataConnector;
        categoryDataManager = new CategoryDataManager(_dataConnector);
        hierarchyDataManager = new SubCategoryDataManager(_dataConnector);
        objectDataManager = new ObjectDataManager(_dataConnector);
        tagDataManager = new TagDataManager(_dataConnector);

        Hierarchy1Names = new ObservableCollection<ICategory>((IEnumerable<ICategory>)categoryDataManager.GetHierarchy1Category());
        Hierarchy2Names = new ObservableCollection<ICategory>();
        VduGroupNames = new ObservableCollection<ICategory>((IEnumerable<ICategory>)categoryDataManager.GetVduGroupCategory());
        AlarmGroupNames = new ObservableCollection<ICategory>((IEnumerable<ICategory>)categoryDataManager.GetAlarmGroupCategory());
        OtdNames = new ObservableCollection<ICategory>((IEnumerable<ICategory>)categoryDataManager.GetOtdCategory());
        AcknowledgeAllowedNames = new ObservableCollection<ICategory>((IEnumerable<ICategory>)categoryDataManager.GetAckAllowedCategory());
        AlwaysVisibleNames = new ObservableCollection<ICategory>((IEnumerable<ICategory>)categoryDataManager.GetAlwaysVisibleCategory());
        NodeNames = new ObservableCollection<ICategory>((IEnumerable<ICategory>)categoryDataManager.GetNodeCategory());
        CabinetNames = new ObservableCollection<ICategory>((IEnumerable<ICategory>)categoryDataManager.GetCabinetCategory());
    }

    private bool CanAddObject()
    {
        return true;
    }

    private void AddObject()
    {
        ObjectModel newObject = new ObjectModel
        {
            SfiNumber = SfiNumberInput,
            MainEqNumber = MainEqNumberInput,
            EqNumber = EqNumberInput,
            Description = DescriptionInput,
            Hierarchy1Name = SelectedHierarchy1?.Name,
            Hierarchy2Name = SelectedHierarchy2?.Name,
            VduGroupName = SelectedVduGroup?.Name,
            AlarmGroupName = SelectedAlarmGroup?.Name,
            OtdName = SelectedOtd?.Name,
            AlwaysVisibleName = SelectedAlwaysVisible?.Name,
            AcknowledgeAllowedName = SelectedAcknowledgeAllowed?.Name,
            NodeName = SelectedNode?.Name,
            CabinetName = SelectedCabinet?.Name,
        };

        if (!ObjectNameIsUsed(newObject.FullObjectName))
        {
            objectDataManager.InsertObject(newObject);
            tagDataManager.AddTagsBasedOnOTD(objectDataManager.GetLastInsertedObjectId(), SelectedOtd.Name);
            CloseWindow();
        }
        else
        {
            ErrorMessage = "ObjectName is already used";
        }
        
    }

    public bool ObjectNameIsUsed(string objectName)
    {
        List<ObjectModel> objects = new List<ObjectModel>().AddRange(objectDataManager.GetObjects());
        foreach (ObjectModel obj in objects)
        {
            if (obj.FullObjectName == objectName)
            {
                return true;
            }
        }
        return false;
    }

    private void CloseWindow()
    {
        Close.Invoke();
    }

    public Action Close { get; set; }
}
