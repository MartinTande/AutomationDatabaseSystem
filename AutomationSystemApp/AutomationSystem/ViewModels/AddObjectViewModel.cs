using AutomationSystem.Commands;
using AutomationSystem.MVVM;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using AutomationSystem.Models.DataManager;
using AutomationSystem.Models;
using AutomationSystem.Models.DataAccess;

namespace AutomationSystem.ViewModels;

internal class AddObjectViewModel : ViewModelBase, ICloseable
{
    private readonly IDataConnector _dataConnector;
    CategoryDataManager categoryDataManager;
    HierarchyDataManager hierarchyDataManager;


    // Commands
    public ICommand AddObjectCommand => new RelayCommand(execute => AddObject(), canExecute => CanAddObject());
    public ICommand CloseWindowCommand => new RelayCommand(execute => CloseWindow());


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

    // Selected category names by user 
    private string? _selectedHierarchy1;
    public string? SelectedHierarchy1
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
            var updatedHierarchyName = new ObservableCollection<ICategory>(hierarchyDataManager.GetHierarchy2Category(SelectedHierarchy1));
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

    private string? _selectedHierarchy2;
    public string? SelectedHierarchy2
    {
        get { return _selectedHierarchy2; }
        set
        {
            _selectedHierarchy2 = value;
            OnPropertyChanged();
        }
    }

    private string? _selectedVduGroup;
    public string? SelectedVduGroup
    {
        get { return _selectedVduGroup; }
        set
        {
            _selectedVduGroup = value;
            OnPropertyChanged();
        }
    }
    private string? _selectedAlarmGroup;
    public string? SelectedAlarmGroup
    {
        get { return _selectedAlarmGroup; }
        set
        {
            _selectedAlarmGroup = value;
            OnPropertyChanged();
        }
    }
    private string? _selectedOtd;
    public string? SelectedOtd
    {
        get { return _selectedOtd; }
        set
        {
            _selectedOtd = value;
            OnPropertyChanged();
        }
    }
    private string? _selectedAcknowledgeAllowed;
    public string? SelectedAcknowledgeAllowed
    {
        get { return _selectedAcknowledgeAllowed; }
        set
        {
            _selectedAcknowledgeAllowed = value;
            OnPropertyChanged();
        }
    }
    private string? _selectedAlwaysVisible;
    public string? SelectedAlwaysVisible
    {
        get { return _selectedAlwaysVisible; }
        set
        {
            _selectedAlwaysVisible = value;
            OnPropertyChanged();
        }
    }
    private string? _selectedNode;
    public string? SelectedNode
    {
        get { return _selectedNode; }
        set
        {
            _selectedNode = value;
            OnPropertyChanged();
        }
    }
    private string? _selectedCabinet;
    public string? SelectedCabinet
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
    private string? _dataBlockInput;
    public string? DataBlockInput
    {
        get { return _dataBlockInput; }
        set
        {
            _dataBlockInput = value;
            OnPropertyChanged();
        }
    }

    public AddObjectViewModel(IDataConnector dataConnector)
    {
        _dataConnector = dataConnector;
        categoryDataManager = new CategoryDataManager(_dataConnector);
        hierarchyDataManager = new HierarchyDataManager(_dataConnector);

        Hierarchy1Names = new ObservableCollection<ICategory>(hierarchyDataManager.GetHierarchy1Category());
        Hierarchy2Names = new ObservableCollection<ICategory>();
        VduGroupNames = new ObservableCollection<ICategory>(categoryDataManager.GetVduGroupCategory());
        AlarmGroupNames = new ObservableCollection<ICategory>(categoryDataManager.GetAlarmGroupCategory());
        OtdNames = new ObservableCollection<ICategory>(categoryDataManager.GetOtdCategory());
        AcknowledgeAllowedNames = new ObservableCollection<ICategory>(categoryDataManager.GetAckAllowedCategory());
        AlwaysVisibleNames = new ObservableCollection<ICategory>(categoryDataManager.GetAlwaysVisibleCategory());
        NodeNames = new ObservableCollection<ICategory>(categoryDataManager.GetNodeCategory());
        CabinetNames = new ObservableCollection<ICategory>(categoryDataManager.GetCabinetCategory());
    }

    private bool CanAddObject()
    {
        return true;
    }

    private void AddObject()
    {
        ObjectDataManager dataManager = new ObjectDataManager(_dataConnector);
        ObjectModel newTagObject = new ObjectModel();

        newTagObject.SfiNumber = SfiNumberInput;
        newTagObject.MainEqNumber = MainEqNumberInput;
        newTagObject.EqNumber = EqNumberInput;
        newTagObject.Description = DescriptionInput;
        newTagObject.Hierarchy1Name = SelectedHierarchy1;
        newTagObject.Hierarchy2Name = SelectedHierarchy2;
        newTagObject.VduGroupName = SelectedVduGroup;
        newTagObject.AlarmGroupName = SelectedAlarmGroup;
        newTagObject.OtdName = SelectedOtd;
        newTagObject.AlwaysVisibleName = SelectedAlwaysVisible;
        newTagObject.AcknowledgeAllowedName = SelectedAcknowledgeAllowed;
        newTagObject.NodeName = SelectedNode;
        newTagObject.CabinetName = SelectedCabinet;
        newTagObject.DataBlockName = DataBlockInput;

        dataManager.InsertObject(newTagObject);
        CloseWindow();
    }

    private void CloseWindow()
    {
        Close.Invoke();
    }

    public Action Close { get; set; }
}
