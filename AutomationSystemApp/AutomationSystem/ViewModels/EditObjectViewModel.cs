using AutomationSystem.Commands;
using AutomationSystem.Models.DataManager;
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
    SubCategoryDataManager subCategoryDataManager;

    // Lists of category names retrieved from database
    public ObservableCollection<string>? Hierarchy1Names { get; set; }
    public ObservableCollection<string>? Hierarchy2Names { get; set; }
    public ObservableCollection<string>? VduGroupNames { get; set; }
    public ObservableCollection<string>? AlarmGroupNames { get; set; }
    public ObservableCollection<string>? OtdNames { get; set; }
    public ObservableCollection<string>? AcknowledgeAllowedNames { get; set; }
    public ObservableCollection<string>? AlwaysVisibleNames { get; set; }
    public ObservableCollection<string>? NodeNames { get; set; }
    public ObservableCollection<string>? CabinetNames { get; set; }

    #region Selected category names by user 
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
            var update = new ObservableCollection<string>((IEnumerable<string>)subCategoryDataManager.GetHierarchy2Names(SelectedHierarchy1));
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
    #endregion

    #region User input parameters
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
    public string? DescriptionInput
    {
        get { return _objectDescriptionInput; }
        set
        {
            _objectDescriptionInput = value;
            OnPropertyChanged();
        }
    }
    #endregion

    public EditObjectViewModel(IDataConnector dataConnector, ObjectModel selectedObject)
    {
        _dataConnector = dataConnector;
        InputSelectedObject(selectedObject);
        categoryDataManager = new CategoryDataManager(_dataConnector);
        subCategoryDataManager = new SubCategoryDataManager(_dataConnector);

        Hierarchy1Names = new ObservableCollection<string>((IEnumerable<string>)categoryDataManager.GetHierarchy1Names());
        Hierarchy2Names = new ObservableCollection<string>((IEnumerable<string>)subCategoryDataManager.GetHierarchy2Names(SelectedHierarchy1));
        VduGroupNames = new ObservableCollection<string>((IEnumerable<string>)categoryDataManager.GetVduGroupNames());
        AlarmGroupNames = new ObservableCollection<string>((IEnumerable<string>)categoryDataManager.GetAlarmGroupNames());
        OtdNames = new ObservableCollection<string>((IEnumerable<string>)categoryDataManager.GetOtdNames());
        AcknowledgeAllowedNames = new ObservableCollection<string>((IEnumerable<string>)categoryDataManager.GetAckowledgeAllowedNames());
        AlwaysVisibleNames = new ObservableCollection<string>((IEnumerable<string>)categoryDataManager.GetAlwaysVisibleNames());
        NodeNames = new ObservableCollection<string>((IEnumerable<string>)categoryDataManager.GetNodeNames());
        CabinetNames = new ObservableCollection<string>((IEnumerable<string>)categoryDataManager.GetCabinetNames());
    }

    private void InputSelectedObject(ObjectModel selectedObject)
    {
        _objectId = selectedObject.Id;
        _sfiNumberInput = selectedObject.SfiNumber;
        _mainEqNumberInput = selectedObject.MainEqNumber;
        _eqNumberInput = selectedObject.EqNumber;
        _objectDescriptionInput = selectedObject.Description;
        _selectedHierarchy1 = selectedObject.Hierarchy1Name;
        _selectedHierarchy2 = selectedObject.Hierarchy2Name;
        _selectedVduGroup = selectedObject.VduGroupName;
        _selectedAlarmGroup = selectedObject.AlarmGroupName;
        _selectedOtd = selectedObject.OtdName;
        _selectedAcknowledgeAllowed = selectedObject.AcknowledgeAllowedName;
        _selectedAlwaysVisible = selectedObject.AlwaysVisibleName;
        _selectedNode = selectedObject.NodeName;
        _selectedCabinet = selectedObject.CabinetName;
    }

    private bool CanUpdateObject()
    {
        return true;
    }

    private void UpdateObject()
    {
        ObjectDataManager dataManager = new ObjectDataManager(_dataConnector);
        ObjectModel updatedObject = new ObjectModel();

        updatedObject.Id = _objectId;
        updatedObject.SfiNumber = SfiNumberInput;
        updatedObject.MainEqNumber = MainEqNumberInput;
        updatedObject.EqNumber = EqNumberInput;
        updatedObject.Description = DescriptionInput;
        updatedObject.Hierarchy1Name = SelectedHierarchy1;
        updatedObject.Hierarchy2Name = SelectedHierarchy2;
        updatedObject.VduGroupName = SelectedVduGroup;
        updatedObject.AlarmGroupName = SelectedAlarmGroup;
        updatedObject.OtdName = SelectedOtd;
        updatedObject.AlwaysVisibleName = SelectedAlwaysVisible;
        updatedObject.AcknowledgeAllowedName = SelectedAcknowledgeAllowed;
        updatedObject.NodeName = SelectedNode;
        updatedObject.CabinetName = SelectedCabinet;

        dataManager.UpdateObject(updatedObject);
        CloseWindow();
    }

    private void CloseWindow()
    {
        Close.Invoke();
    }

    public Action Close { get; set; }
}
