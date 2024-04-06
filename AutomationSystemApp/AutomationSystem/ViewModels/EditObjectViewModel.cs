using AutomationSystem.Commands;
using AutomationSystem.DataManager;
using AutomationSystem.Models;
using AutomationSystem.Models.DataAccess;
using AutomationSystem.MVVM;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace AutomationSystem.ViewModels;

internal class EditObjectViewModel : ViewModelBase, ICloseable
{
    private readonly IDataConnector _dataConnector;
    public ICommand UpdateObjectCommand => new RelayCommand(execute => UpdateObject(), canExecute => CanUpdateObject());
    public ICommand CloseWindowCommand => new RelayCommand(execute => CloseWindow());

    CategoryDataManager categoryDataManager;

    // Lists of category names retrieved from database
    public ObservableCollection<string>? Hierarchy1Names { get; set; }
    public ObservableCollection<string>? Hierarchy2Names { get; set; }
    public ObservableCollection<string>? VduGroupNames { get; set; }
    public ObservableCollection<string>? AlarmGroupNames { get; set; }
    public ObservableCollection<string>? OtdNames { get; set; }
    public ObservableCollection<string>? AcknowledgeAllowedLocations { get; set; }
    public ObservableCollection<string>? AlwaysVisibleLocations { get; set; }
    public ObservableCollection<string>? NodeNames { get; set; }
    public ObservableCollection<string>? CabinetNames { get; set; }

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
    private int _objectId;
    public int ObjectId
    {
        get { return _objectId; }
        set
        {
            _objectId = value;
            OnPropertyChanged();
        }
    }
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
    public string? ObjectDescriptionInput
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

    public EditObjectViewModel(IDataConnector dataConnector, TagObjectModel selectedTagObject)
    {
        _dataConnector = dataConnector;
        InputSelectedTagObject(selectedTagObject);
        categoryDataManager = new CategoryDataManager(_dataConnector);

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

    private void InputSelectedTagObject(TagObjectModel selectedTagObject)
    {
        _objectId = selectedTagObject.ObjectId;
        _sfiNumberInput = selectedTagObject.SfiNumber;
        _mainEqNumberInput = selectedTagObject.MainEqNumber;
        _eqNumberInput = selectedTagObject.EqNumber;
        _objectDescriptionInput = selectedTagObject.ObjectDescription;
        _selectedHierarchy1 = selectedTagObject.Hierarchy1Name;
        _selectedHierarchy2 = selectedTagObject.Hierarchy2Name;
        _selectedVduGroup = selectedTagObject.VduGroupName;
        _selectedAlarmGroup = selectedTagObject.AlarmGroupName;
        _selectedOtd = selectedTagObject.OtdName;
        _selectedAcknowledgeAllowed = selectedTagObject.AcknowledgeAllowedLocation;
        _selectedAlwaysVisible = selectedTagObject.AlwaysVisibleLocation;
        _selectedNode = selectedTagObject.NodeName;
        _selectedCabinet = selectedTagObject.CabinetName;
        _dataBlockInput = selectedTagObject.DataBlockName;
    }

    private bool CanUpdateObject()
    {
        return true;
    }

    private void UpdateObject()
    {
        ObjectDataManager dataManager = new ObjectDataManager(_dataConnector);
        TagObjectModel updatedTagObject = new TagObjectModel();

        updatedTagObject.ObjectId = _objectId;
        updatedTagObject.SfiNumber = SfiNumberInput;
        updatedTagObject.MainEqNumber = MainEqNumberInput;
        updatedTagObject.EqNumber = EqNumberInput;
        updatedTagObject.ObjectDescription = ObjectDescriptionInput;
        updatedTagObject.Hierarchy1Name = SelectedHierarchy1;
        updatedTagObject.Hierarchy2Name = SelectedHierarchy2;
        updatedTagObject.VduGroupName = SelectedVduGroup;
        updatedTagObject.AlarmGroupName = SelectedAlarmGroup;
        updatedTagObject.OtdName = SelectedOtd;
        updatedTagObject.AlwaysVisibleLocation = SelectedAlwaysVisible;
        updatedTagObject.AcknowledgeAllowedLocation = SelectedAcknowledgeAllowed;
        updatedTagObject.NodeName = SelectedNode;
        updatedTagObject.CabinetName = SelectedCabinet;
        updatedTagObject.DataBlockName = DataBlockInput;

        dataManager.UpdateTagObject(updatedTagObject);
        MessageBox.Show(updatedTagObject.ObjectDescription);
        CloseWindow();
    }

    private void CloseWindow()
    {
        Close.Invoke();
    }

    public Action Close { get; set; }
}
