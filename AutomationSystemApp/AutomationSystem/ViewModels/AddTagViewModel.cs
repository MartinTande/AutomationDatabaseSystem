﻿using AutomationSystem.Commands;
using AutomationSystem.MVVM;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using AutomationSystem.Models.DataManager;
using AutomationSystem.Models;
using AutomationSystem.Models.DataAccess;
using System.Data;

namespace AutomationSystem.ViewModels;

internal class AddTagViewModel : ViewModelBase, ICloseable
{
    private readonly IDataConnector _dataConnector;
    TagDataManager tagDataManager;
    CategoryDataManager categoryDataManager;
    SubCategoryDataManager subCategoryDataManager;

    #region Commands
    public ICommand AddTagCommand => new RelayCommand(execute => AddTag(), canExecute => CanAddTag());
    public ICommand CloseWindowCommand => new RelayCommand(execute => CloseWindow());
    #endregion

    // Lists of category names retrieved from database
    public ObservableCollection<ICategory> IoTypeNames { get; set; }
    public ObservableCollection<ICategory> SignalTypeNames { get; set; }

    public AddTagViewModel(IDataConnector dataConnector)
    {
        _dataConnector = dataConnector;
        tagDataManager = new TagDataManager(dataConnector);
        categoryDataManager = new CategoryDataManager(_dataConnector);
        subCategoryDataManager = new SubCategoryDataManager(_dataConnector);

        IoTypeNames = new ObservableCollection<ICategory>(categoryDataManager.GetIoTypeCategory());
        SignalTypeNames = new ObservableCollection<ICategory>();
    }

    #region Selected category names by user
    private ICategory? _selectedIoType;
    public ICategory? SelectedIoType
    {
        get { return _selectedIoType; }
        set
        {
            _selectedIoType = value;
            OnPropertyChanged();
            UpdateSignalTypes();
        }
    }

    private ICategory? _selectedSignalType;
    public ICategory? SelectedSignalType
    {
        get { return _selectedSignalType; }
        set
        {
            _selectedSignalType = value;
            OnPropertyChanged();
        }
    }
    #endregion

    #region User input parameters
    private int _eqSuffixInput;
    public int EqSuffixInput
    {
        get { return _eqSuffixInput; }
        set { _eqSuffixInput = value; }
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

    private int _highHighLimitInput;
    public int HighHighLimitInput
    {
        get { return _highHighLimitInput; }
        set { _highHighLimitInput = value; OnPropertyChanged(); }
    }

    private int _highLimitInput;
    public int HighLimitInput
    {
        get { return _highLimitInput; }
        set { _highLimitInput = value; OnPropertyChanged(); }
    }

    private int _lowLimitInput;
    public int LowLimitInput
    {
        get { return _lowLimitInput; }
        set { _lowLimitInput = value; OnPropertyChanged(); }
    }

    private int _lowLowLimitInput;
    public int LowLowLimitInput
    {
        get { return _lowLowLimitInput; }
        set { _lowLowLimitInput = value; OnPropertyChanged(); }
    }

    private int _modbusAddressInput;
    public int ModbusAddressInput
    {
        get { return _modbusAddressInput; }
        set { _modbusAddressInput = value; OnPropertyChanged(); }
    }

    private int _modbusBitInput;
    public int ModbusBitInput
    {
        get { return _modbusBitInput; }
        set { _modbusBitInput = value; OnPropertyChanged(); }
    }
    #endregion

    public void AddTag()
    {
        TagModel newTag = new TagModel
        {
            Suffix = EqSuffixInput,
            IsE0 = E0Input,
            IsVDR = VDRInput,
            Description = DescriptionInput,
            IoType = SelectedIoType.Name,
            SignalType = SelectedSignalType.Name,
            HighHighLimit = HighHighLimitInput,
            HighLimit = HighLimitInput,
            LowLimit = LowLimitInput,
            LowLowLimit = LowLimitInput,
            SWPath = SWPathInput,
            ModbusAddress = ModbusAddressInput,
            ModbusBit = ModbusBitInput
        };

        tagDataManager.InsertTag(newTag);
        CloseWindow();
    }

    public bool CanAddTag()
    {
        return true;
    }

    private void UpdateSignalTypes()
    {
        try
        {
            if (SignalTypeNames != null)
            {
                SignalTypeNames.Clear();
            }
            var updatedHierarchyName = new ObservableCollection<ICategory>(subCategoryDataManager.GetSignalTypeCategory(SelectedIoType.Name));
            foreach (ICategory item in updatedHierarchyName)
            {
                SignalTypeNames.Add(item);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error updating SignalTypeNames: {ex.Message}");
        }
    }

    private void CloseWindow()
    {
        Close.Invoke();
    }

    public Action Close { get; set; }
}
