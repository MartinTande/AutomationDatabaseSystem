using AutomationSystem.Commands;
using AutomationSystem.Models;
using AutomationSystem.Models.DataAccess;
using AutomationSystem.Models.DataManager;
using AutomationSystem.MVVM;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace AutomationSystem.ViewModels;

internal class EditTagViewModel : ViewModelBase, ICloseable
{
    private readonly IDataConnector _dataConnector;
    
    CategoryDataManager categoryDataManager;
    SubCategoryDataManager subCategoryDataManager;

    #region Commands
    public ICommand EditTagCommand => new RelayCommand(execute => EditTag(), canExecute => CanEditTag());
    public ICommand CloseWindowCommand => new RelayCommand(execute => CloseWindow());
    #endregion

    #region Properties
    private int _tagId;

    public int TagId
    {
        get { return _tagId; }
        set { _tagId = value; OnPropertyChanged(); }
    }

    private int? _eqSuffixInput;
    public int? EqSuffixInput
    {
        get { return _eqSuffixInput; }
        set { _eqSuffixInput = value; OnPropertyChanged(); }
    }

    private string? _descriptionInput;
    public string? DescriptionInput
    {
        get { return _descriptionInput; }
        set { _descriptionInput = value; OnPropertyChanged(); }
    }

    private bool _e0Input;
    public bool E0Input
    {
        get { return _e0Input; }
        set { _e0Input = value; OnPropertyChanged(); }
    }

    private bool _vdrInput;
    public bool VDRInput
    {
        get { return _vdrInput; }
        set { _vdrInput = value; OnPropertyChanged(); }
    }

    private string? _swPathInput;
    public string? SWPathInput
    {
        get { return _swPathInput; }
        set { _swPathInput = value; OnPropertyChanged(); }
    }

    private string? _engUnitInput;

    public string? EngUnitInput
    {
        get { return _engUnitInput; }
        set { _engUnitInput = value; OnPropertyChanged(); }
    }

    private string? _dbNameInput;
    public string? DBNameInput
    {
        get { return _dbNameInput; }
        set { _dbNameInput = value; OnPropertyChanged(); }
    }

    private int? _rangeLowInput;
    public int? RangeLowInput
    {
        get { return _rangeLowInput; }
        set { _rangeLowInput = value; OnPropertyChanged(); }
    }

    private int? _rangeHighInput;
    public int? RangeHighInput
    {
        get { return _rangeHighInput; }
        set { _rangeHighInput = value; OnPropertyChanged(); }
    }

    private int? _highHighLimitInput;
    public int? HighHighLimitInput
    {
        get { return _highHighLimitInput; }
        set { _highHighLimitInput = value; OnPropertyChanged(); }
    }

    private int? _highLimitInput;
    public int? HighLimitInput
    {
        get { return _highLimitInput; }
        set { _highLimitInput = value; OnPropertyChanged(); }
    }

    private int? _lowLimitInput;
    public int? LowLimitInput
    {
        get { return _lowLimitInput; }
        set { _lowLimitInput = value; OnPropertyChanged(); }
    }

    private int? _lowLowLimitInput;
    public int? LowLowLimitInput
    {
        get { return _lowLowLimitInput; }
        set { _lowLowLimitInput = value; OnPropertyChanged(); }
    }

    private int? _modbusAddressInput;
    public int? ModbusAddressInput
    {
        get { return _modbusAddressInput; }
        set { _modbusAddressInput = value; OnPropertyChanged(); }
    }

    private int? _modbusBitInput;
    public int? ModbusBitInput
    {
        get { return _modbusBitInput; }
        set { _modbusBitInput = value; OnPropertyChanged(); }
    }
    private string? _absoluteAddressInput;

    public string? AbsoluteAddressInput
    {
        get { return _absoluteAddressInput; }
        set { _absoluteAddressInput = value; OnPropertyChanged(); }
    }
    private int? _slotInput;

    public int? SlotInput
    {
        get { return _slotInput; }
        set { _slotInput = value; OnPropertyChanged(); }
    }

    private string? _selectedIoType;
    public string? SelectedIoType
    {
        get { return _selectedIoType; }
        set
        {
            _selectedIoType = value;
            OnPropertyChanged();
            UpdateSignalTypes();
            OnPropertyChanged(nameof(SignalTypes));
        }
    }

    private string? _selectedSignalType;
    public string? SelectedSignalType
    {
        get { return _selectedSignalType; }
        set
        {
            _selectedSignalType = value;
            OnPropertyChanged();
        }
    }

    private string? _selectedEngUnit;

    public string? SelectedEngUnit
    {
        get { return _selectedEngUnit; }
        set { _selectedEngUnit = value; OnPropertyChanged(); }
    }
    #endregion

    private void CloseWindow()
    {
        Close.Invoke();
    }
    public Action Close { get; set; }

    public ObservableCollection<string> IoTypes { get; set; }
    public ObservableCollection<string> SignalTypes { get; set; }
    public ObservableCollection<string> EngUnits { get; set; }

    public EditTagViewModel(IDataConnector dataConnector, TagModel selectedTag)
    {
        _dataConnector = dataConnector;
        categoryDataManager = new CategoryDataManager(_dataConnector);
        subCategoryDataManager = new SubCategoryDataManager(_dataConnector);

        InputSelectedTag(selectedTag);
        IoTypes = new ObservableCollection<string>(categoryDataManager.GetIoTypeNames());
        SignalTypes = new ObservableCollection<string>(subCategoryDataManager.GetSignalTypeNames(SelectedIoType));
        EngUnits = new ObservableCollection<string>(categoryDataManager.GetEngUnitNames());
    }

    private void InputSelectedTag(TagModel selectedTag)
    {
        _tagId = selectedTag.Id;
        _eqSuffixInput = selectedTag.EqSuffix;
        _e0Input = selectedTag.IsE0;
        _vdrInput = selectedTag.IsVDR;
        _descriptionInput = selectedTag.Description;
        _selectedIoType = selectedTag.IoType;
        _selectedSignalType = selectedTag.SignalType;
        _selectedEngUnit = selectedTag.EngUnit;
        _highHighLimitInput = selectedTag.HighHighLimit;
        _highLimitInput = selectedTag.HighLimit;
        _lowLimitInput = selectedTag.LowLimit;
        _lowLowLimitInput = selectedTag.LowLimit;
        _swPathInput = selectedTag.SWPath;
        _dbNameInput = selectedTag.DBName;
        _modbusAddressInput = selectedTag.ModbusAddress;
        _modbusBitInput = selectedTag.ModbusBit;
    }

    private bool CanEditTag()
    {
        return true;
    }

    private void EditTag()
    {
        TagDataManager tagDataManager = new TagDataManager(_dataConnector);
        TagModel updatedTag = new TagModel()
        {
            Id = _tagId,
            EqSuffix = _eqSuffixInput,
            Description = _descriptionInput,
            IoType = _selectedIoType,
            SignalType = _selectedSignalType,
            EngUnit = _selectedEngUnit,
            LowLimit = _lowLimitInput,
            LowLowLimit = _lowLowLimitInput,
            HighLimit = _highLimitInput,
            HighHighLimit = _highHighLimitInput,
            RangeLow = _rangeLowInput,
            RangeHigh = _rangeHighInput,
            Slot = _slotInput,
            AbsoluteAddress = _absoluteAddressInput,
            SWPath = _swPathInput,
            DBName = _dbNameInput,
            ModbusAddress = _modbusAddressInput,
            ModbusBit = _modbusBitInput,
        };

        tagDataManager.UpdateTag(updatedTag);
        CloseWindow();
    }

    private void UpdateSignalTypes()
    {
        try
        {
            if (SignalTypes != null)
            {
                SignalTypes.Clear();
            }
            var updatedsignalTypes = new ObservableCollection<string>(subCategoryDataManager.GetSignalTypeNames(SelectedIoType));
            foreach (string item in updatedsignalTypes)
            {
                SignalTypes.Add(item);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error updating SignalTypeNames: {ex.Message}");
        }
    }
}
