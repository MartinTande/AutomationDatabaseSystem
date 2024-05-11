using System.Collections.ObjectModel;
using System.Windows.Input;
using AutomationSystem.Commands;
using AutomationSystem.Views;
using AutomationSystem.MVVM;
using System.Windows;
using AutomationSystem.Models;
using AutomationSystem.Models.DataAccess;
using AutomationSystem.Models.DataManager;


namespace AutomationSystem.ViewModels;


internal class MainWindowViewModel : ViewModelBase
{
    private readonly IDataConnector _dataConnector;
    ObjectDataManager objectDataManager;
    TagDataManager tagDataManager;
    CategoryDataManager categoryDataManager;
    SubCategoryDataManager subCategoryDataManager;

    #region Properties
    private ObservableCollection<Hierarchy1> _hierarchy1Names;
    public ObservableCollection<Hierarchy1> Hierarchy1Names
    {
        get { return _hierarchy1Names; }
        set
        {
            _hierarchy1Names = value;
            OnPropertyChanged();
        }
    }

    private TagModel _selectedTag;

    public TagModel SelectedTag
    {
        get { return _selectedTag; }
        set 
        { 
            _selectedTag = value;
            OnPropertyChanged();
        }
    }

    private IItem _selectedHierarchyItem;

    public IItem SelectedHierarchyItem
    {
        get { return _selectedHierarchyItem; }
        set
        {
            _selectedHierarchyItem = value;
            OnPropertyChanged();
            SelectedHierarchyName = value.Name;
        }
    }

    private string? _selectedHierarchyName;

    public string? SelectedHierarchyName
    {
        get { return _selectedHierarchyName; }
        set
        {
            if (_selectedHierarchyName != value)
            {
                _selectedHierarchyName = value;
            }
            MessageBox.Show(SelectedHierarchyItem.Id.ToString());
            OnPropertyChanged();
        }
    }

    private ObservableCollection<IItem> _pictureHierarchy;
    public ObservableCollection<IItem> PictureHierarchy
    {
        get { return _pictureHierarchy; }
        set
        {
            if (value != null)
            {
                _pictureHierarchy = value;
                OnPropertyChanged();
            }
        }
    }

    private ObservableCollection<ObjectModel> _objects;
    public ObservableCollection<ObjectModel> Objects
    {
        get { return _objects; }
        set
        {
            if (_objects != value && _objects != null)
            {
                _objects = value;
                OnPropertyChanged();
            }
        }
    }

    private ObservableCollection<TagModel> _tags;
    public ObservableCollection<TagModel> Tags
    {
        get { return _tags; }
        set 
        {
            if (_tags != value && _tags != null)
            {
                _tags = value;
                OnPropertyChanged();
            }
        }
    }

    private ObjectModel? _selectedObject;
    public ObjectModel? SelectedObject
    {
        get { return _selectedObject; }
        set
        {
            _selectedObject = value;
            OnPropertyChanged();
            if (value != null)
            {
                UpdateTags(SelectedObject.FullObjectName);
            }
        }
    }
    #endregion
    public MainWindowViewModel(IDataConnector dataConnector)
    {
        _dataConnector = dataConnector;
        objectDataManager = new ObjectDataManager(_dataConnector);
        tagDataManager = new TagDataManager(_dataConnector);
        subCategoryDataManager = new SubCategoryDataManager(_dataConnector);
        categoryDataManager = new CategoryDataManager(_dataConnector);
        _objects = new ObservableCollection<ObjectModel>(objectDataManager.GetObjects());
        _tags = new ObservableCollection<TagModel>();
        _hierarchy1Names = new ObservableCollection<Hierarchy1>(categoryDataManager.GetHierarchy1Category());
        _pictureHierarchy = new ObservableCollection<IItem>();
        GetPictureHierarchy();
    }

    #region Commands
    public ICommand ShowAddObjectWindowCommand => new RelayCommand(execute => ShowAddObjectWindow());
    public ICommand ShowEditObjectWindowCommand => new RelayCommand(execute => ShowEditObjectWindow(), canExecute => SelectedObject != null);
    public ICommand DeleteObjectCommand => new RelayCommand(execute => DeleteObject(), canExecute => SelectedObject != null);
    public ICommand AddHierarchySubItemCommand => new RelayCommand(execute => AddHierarchySubItem(), canExecute => CanAddSubItem());
    public ICommand AddHierarchyItemCommand => new RelayCommand(execute => AddHierarchyItem());
    public ICommand EditHierarchyItemCommand => new RelayCommand(execute => EditHierarchyItem(), canExecute => SelectedHierarchyItem != null);
    public ICommand DeleteHierarchyItemCommand => new RelayCommand(execute => DeleteHierarchyItem(), canExecute => SelectedHierarchyItem != null);
    public ICommand ShowAddTagWindowCommand => new RelayCommand(execute => ShowAddTagWindow(), canExecute => SelectedObject != null);
    public ICommand ShowEditTagWindowCommand => new RelayCommand(execute => ShowEditTagWindow(), canExecute => SelectedTag != null);
    public ICommand DeleteTagCommand => new RelayCommand(execute => DeleteTag(), canExecute => SelectedTag != null);
    #endregion

    #region Tag functions
    private void ShowAddTagWindow()
    {
        AddTagWindow addTagWindow = new AddTagWindow(_dataConnector, SelectedObject.Id);
        addTagWindow.Show();
        addTagWindow.Closed += AddTagWindow_Closed;
    }

    private void AddTagWindow_Closed(object sender, EventArgs e)
    {
        UpdateTags(SelectedObject.FullObjectName);
    }

    private void AddTagsBasedOnOTD()
    {
        if (_otdTagStructure.ContainsKey(SelectedObject.OtdName))
        {
            List<TagModel> tags = _otdTagStructure[SelectedObject.OtdName];
            foreach (TagModel tag in tags)
            {
                tagDataManager.InsertTag(SelectedObject.Id, tag);
            }
        }

    }

    Dictionary<string, List<TagModel>> _otdTagStructure = new Dictionary<string, List<TagModel>>()
    {
        {
            "BO_Motor", [
                new TagModel { EqSuffix = 11, Description = "Running feedback", IoType = "DI", SignalType = "NO" },
                new TagModel { EqSuffix = 12, Description = "Local selector", IoType = "DI", SignalType = "NO" },
                new TagModel { EqSuffix = 21, Description = "Start command", IoType = "DO", SignalType = "NO" },
                new TagModel { EqSuffix = 22, Description = "Stop command", IoType = "DO", SignalType = "NO" },
                new TagModel { EqSuffix = 18, Description = "Auxiliary fault", IoType = "DI", SignalType = "NC" },
                ]
        },
        {
            "BO_MotorFC", [
                new TagModel { EqSuffix = 11, Description = "Running feedback", IoType = "DI", SignalType = "NO" },
                new TagModel { EqSuffix = 12, Description = "Local selector", IoType = "DI", SignalType = "NO" },
                new TagModel { EqSuffix = 21, Description = "Start command", IoType = "DO", SignalType = "NO" },
                new TagModel { EqSuffix = 22, Description = "Stop command", IoType = "DO", SignalType = "NO" },
                new TagModel { EqSuffix = 18, Description = "Auxiliary fault", IoType = "DI", SignalType = "NC" },
                new TagModel { EqSuffix = 61, Description = "Speed feedback", IoType = "AI", SignalType = "4-20mA, 2W" },
                new TagModel { EqSuffix = 62, Description = "Speed setpoint", IoType = "AO", SignalType = "4-20mA, 2W" },
                ]
        },
        {
            "BO_Valve", [
                new TagModel { EqSuffix = 01, Description = "Closed feedback", IoType = "DI", SignalType = "NO" },
                new TagModel { EqSuffix = 02, Description = "Opened feedback", IoType = "DI", SignalType = "NO" },
                new TagModel { EqSuffix = 03, Description = "Close command", IoType = "DO", SignalType = "NO" },
                new TagModel { EqSuffix = 04, Description = "Open command", IoType = "DO", SignalType = "NO" },
                new TagModel { EqSuffix = 07, Description = "Valve - Fault", IoType = "DO", SignalType = "NO" },
                ]
        }
    };

    private void EditTagWindow_Closed(object sender, EventArgs e)
    {
        UpdateObjects();
    }

    private void UpdateTags(string? objectName)
    {
        try
        {
            Tags = new ObservableCollection<TagModel>(tagDataManager.GetTagsByObjectId(SelectedObject.Id));
            foreach (TagModel tag in Tags)
            {
                tag.ObjectName = objectName; 
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error updating Tags: {ex.Message}");
        }
    }

    private void ShowEditTagWindow()
    {
        throw new NotImplementedException();
    }

    private void DeleteTag()
    {
        tagDataManager.DeleteTag(SelectedTag.Id);
        UpdateTags(SelectedObject.FullObjectName);
    }
    #endregion

    #region Hierarchy functions
    private bool CanAddSubItem()
    {
        if (SelectedHierarchyItem == null)
        {
            return false;
        }
        return isHierarchy1Item(SelectedHierarchyItem.Name);
    }
    private void EditHierarchyItem()
    {
        // bool isHierarchy1 = Hierarchy1Names.Any(item => item.Name == SelectedHierarchyItem.Name);
        if (isHierarchy1Item(SelectedHierarchyItem.Name))
        {
            categoryDataManager.EditHierarchy1Category(SelectedHierarchyItem.Id, SelectedHierarchyName);
        }
        else
        {
            subCategoryDataManager.EditHierarchy2Category(SelectedHierarchyItem.Id, SelectedHierarchyName);
        }
        GetPictureHierarchy();
    }

    private void DeleteHierarchyItem()
    {
        bool isHierarchy1 = Hierarchy1Names.Any(item => item.Name == SelectedHierarchyItem.Name);
        if (isHierarchy1)
        {
            categoryDataManager.DeleteHierarchy1Category(SelectedHierarchyItem.Id);
        }
        else
        {
            subCategoryDataManager.DeleteHierarchy2Category(SelectedHierarchyItem.Id);
        }
        GetPictureHierarchy();
        SelectedHierarchyName = null;
    }

    private void AddHierarchySubItem()
    {
        subCategoryDataManager.AddHierarchy2Category(SelectedHierarchyItem.Name, SelectedHierarchyName);
        GetPictureHierarchy();
    }

    private void AddHierarchyItem()
    {
        categoryDataManager.AddHierarchy1Category(SelectedHierarchyName);
        GetPictureHierarchy();
    }

    private bool isHierarchy1Item(string selectedItem)
    {
        if (selectedItem == null)
        {
            return false;
        }
        return Hierarchy1Names.Any(item => item.Name == selectedItem);
    }
    private void GetPictureHierarchy()
    {
        if (PictureHierarchy != null)
        {
            PictureHierarchy.Clear();
        }
        Hierarchy1Names = new ObservableCollection<Hierarchy1>(categoryDataManager.GetHierarchy1Category());

        //add Root items
        foreach (Hierarchy1 hierarchy1 in Hierarchy1Names)
        {
            PictureHierarchy.Add(new HierarchyModel { Id = hierarchy1.Id, Name = hierarchy1.Name });
        }

        //add sub items
        for (int i = 0; i < PictureHierarchy.Count; i++)
        {
            string? hierarchy1Name = PictureHierarchy[i].Name;
            List<Hierarchy2> hierarchy2Category = subCategoryDataManager.GetHierarchy2Category(hierarchy1Name);
            foreach (Hierarchy2 hierarchy2 in hierarchy2Category)
            {
                PictureHierarchy[i].SubItem.Add(new HierarchyModel { Id = hierarchy2.Id, Name = hierarchy2.Name });
            }
        }
    }

    #endregion

    #region Object functions
    private void ShowAddObjectWindow()
    {
        AddObjectWindow addObjectWindow = new AddObjectWindow(_dataConnector);
        addObjectWindow.Show();
        addObjectWindow.Closed += AddObjectWindow_Closed;
    }
    private void ShowEditObjectWindow()
    {
        EditObjectWindow editObjectWindow = new EditObjectWindow(_dataConnector, SelectedObject);
        MessageBox.Show(SelectedObject.Description);
        editObjectWindow.Show();
        editObjectWindow.Closed += EditObjectWindow_Closed;
    }

    private void DeleteObject()
    {
        objectDataManager.DeleteObject(SelectedObject.Id);
        UpdateObjects();
    }

    private void UpdateObjects()
    {
        Objects = new ObservableCollection<ObjectModel>(objectDataManager.GetObjects());
    }
    private void AddObjectWindow_Closed(object sender, EventArgs e)
    {
        UpdateObjects();
    }


    private void EditObjectWindow_Closed(object sender, EventArgs e)
    {
        UpdateObjects();
    }
    #endregion

}
