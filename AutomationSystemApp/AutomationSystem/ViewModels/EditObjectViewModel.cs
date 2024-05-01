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
            var update = new ObservableCollection<string>(subCategoryDataManager.GetHierarchy2Names(SelectedHierarchy1));
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

    public EditObjectViewModel(IDataConnector dataConnector, ObjectModel selectedTagObject)
    {
        _dataConnector = dataConnector;
        InputSelectedTagObject(selectedTagObject);
        categoryDataManager = new CategoryDataManager(_dataConnector);
        subCategoryDataManager = new SubCategoryDataManager(_dataConnector);

        Hierarchy1Names = new ObservableCollection<string>(categoryDataManager.GetHierarchy1Names());
        Hierarchy2Names = new ObservableCollection<string>(subCategoryDataManager.GetHierarchy2Names(SelectedHierarchy1));
        VduGroupNames = new ObservableCollection<string>(categoryDataManager.GetVduGroupNames());
        AlarmGroupNames = new ObservableCollection<string>(categoryDataManager.GetAlarmGroupNames());
        OtdNames = new ObservableCollection<string>(categoryDataManager.GetOtdNames());
        AcknowledgeAllowedNames = new ObservableCollection<string>(categoryDataManager.GetAckowledgeAllowedNames());
        AlwaysVisibleNames = new ObservableCollection<string>(categoryDataManager.GetAlwaysVisibleNames());
        NodeNames = new ObservableCollection<string>(categoryDataManager.GetNodeNames());
        CabinetNames = new ObservableCollection<string>(categoryDataManager.GetCabinetNames());
    }

    private void InputSelectedTagObject(ObjectModel selectedTagObject)
    {
        _objectId = selectedTagObject.Id;
        _sfiNumberInput = selectedTagObject.SfiNumber;
        _mainEqNumberInput = selectedTagObject.MainEqNumber;
        _eqNumberInput = selectedTagObject.EqNumber;
        _objectDescriptionInput = selectedTagObject.Description;
        _selectedHierarchy1 = selectedTagObject.Hierarchy1Name;
        _selectedHierarchy2 = selectedTagObject.Hierarchy2Name;
        _selectedVduGroup = selectedTagObject.VduGroupName;
        _selectedAlarmGroup = selectedTagObject.AlarmGroupName;
        _selectedOtd = selectedTagObject.OtdName;
        _selectedAcknowledgeAllowed = selectedTagObject.AcknowledgeAllowedName;
        _selectedAlwaysVisible = selectedTagObject.AlwaysVisibleName;
        _selectedNode = selectedTagObject.NodeName;
        _selectedCabinet = selectedTagObject.CabinetName;
    }

    private bool CanUpdateObject()
    {
        return true;
    }

    private void UpdateObject()
    {
        ObjectDataManager dataManager = new ObjectDataManager(_dataConnector);
        ObjectModel updatedTagObject = new ObjectModel();

        updatedTagObject.Id = _objectId;
        updatedTagObject.SfiNumber = SfiNumberInput;
        updatedTagObject.MainEqNumber = MainEqNumberInput;
        updatedTagObject.EqNumber = EqNumberInput;
        updatedTagObject.Description = DescriptionInput;
        updatedTagObject.Hierarchy1Name = SelectedHierarchy1;
        updatedTagObject.Hierarchy2Name = SelectedHierarchy2;
        updatedTagObject.VduGroupName = SelectedVduGroup;
        updatedTagObject.AlarmGroupName = SelectedAlarmGroup;
        updatedTagObject.OtdName = SelectedOtd;
        updatedTagObject.AlwaysVisibleName = SelectedAlwaysVisible;
        updatedTagObject.AcknowledgeAllowedName = SelectedAcknowledgeAllowed;
        updatedTagObject.NodeName = SelectedNode;
        updatedTagObject.CabinetName = SelectedCabinet;

        dataManager.UpdateObject(updatedTagObject);
        MessageBox.Show(updatedTagObject.Description);
        CloseWindow();
    }

    private void CloseWindow()
    {
        Close.Invoke();
    }

    public Action Close { get; set; }
}
