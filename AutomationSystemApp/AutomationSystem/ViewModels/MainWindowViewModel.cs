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
    ObjectDataManager dataManager;
    TagDataManager tagDataManager;
    HierarchyDataManager hierarchyDataManger;

    // Properties
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

    // Commands
    public ICommand ShowAddObjectWindowCommand => new RelayCommand(execute => ShowAddObjectWindow());
    public ICommand ShowEditObjectWindowCommand => new RelayCommand(execute => ShowEditObjectWindow(), canExecute => SelectedObject != null);
    public ICommand DeleteObjectCommand => new RelayCommand(execute => DeleteObject(), canExecute => SelectedObject != null);
    public ICommand AddHierarchySubItemCommand => new RelayCommand(execute => AddHierarchySubItem(), canExecute => CanAddSubItem());
    public ICommand AddHierarchyItemCommand => new RelayCommand(execute => AddHierarchyItem());
    public ICommand EditHierarchyItemCommand => new RelayCommand(execute => EditHierarchyItem(), canExecute => SelectedHierarchyItem != null);
    public ICommand DeleteHierarchyItemCommand => new RelayCommand(execute => DeleteHierarchyItem(), canExecute => SelectedHierarchyItem != null);
    public ICommand ShowAddTagWindowCommand => new RelayCommand(execute => ShowAddTagWindow());

    private void ShowAddTagWindow()
    {
        tagDataManager.InsertTag()
    }

    public ICommand ShowEditTagWindowCommand => new RelayCommand(execute => ShowEditTagWindow(), canExecute => SelectedTag != null);

    private void ShowEditTagWindow()
    {
        throw new NotImplementedException();
    }

    public ICommand DeleteTagCommand => new RelayCommand(execute => DeleteTag(), canExecute => SelectedTag != null);

    private void DeleteTag()
    {
        tagDataManager.DeleteTag(SelectedTag.Id);
        UpdateTags(SelectedObject.FullObjectName);
    }

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
        bool isHierarchy1 = Hierarchy1Names.Any(item => item.Name == SelectedHierarchyItem.Name);
        //if (isHierarchy1Item(SelectedHierarchyItem.Name))
        //{
        //    hierarchyDataManger.EditHierarchy1Category(SelectedHierarchyItem.Id, SelectedHierarchyName);
        //}
        //else
        //{
        //    hierarchyDataManger.EditHierarchy2Category(SelectedHierarchyItem.Id, SelectedHierarchyName);
        //}
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
    private void DeleteHierarchyItem()
    {
        bool isHierarchy1 = Hierarchy1Names.Any(item => item.Name == SelectedHierarchyItem.Name);
        if (isHierarchy1)
        {
            hierarchyDataManger.DeleteHierarchy1Category(SelectedHierarchyItem.Id);
        }
        else
        {
            hierarchyDataManger.DeleteHierarchy2Category(SelectedHierarchyItem.Id);
        }
        GetPictureHierarchy();
        SelectedHierarchyName = null;
    }

    private void AddHierarchySubItem()
    {
        hierarchyDataManger.AddHierarchy2Category(SelectedHierarchyItem.Name, SelectedHierarchyName);
        GetPictureHierarchy();
    }

    private void AddHierarchyItem()
    {
        hierarchyDataManger.AddHierarchy1Category(SelectedHierarchyName);
        GetPictureHierarchy();
    }

    public MainWindowViewModel(IDataConnector dataConnector)
    {
        _dataConnector = dataConnector;
        dataManager = new ObjectDataManager(_dataConnector);
        tagDataManager = new TagDataManager(_dataConnector);
        hierarchyDataManger = new HierarchyDataManager(_dataConnector);
        _objects = new ObservableCollection<ObjectModel>(dataManager.GetObjects());
        _tags = new ObservableCollection<TagModel>();
        _hierarchy1Names = new ObservableCollection<Hierarchy1>(hierarchyDataManger.GetHierarchy1Category());
        _pictureHierarchy = new ObservableCollection<IItem>();
        GetPictureHierarchy();
    }

    private void GetPictureHierarchy()
    {
        if (PictureHierarchy != null)
        {
            PictureHierarchy.Clear();
        }
        Hierarchy1Names = new ObservableCollection<Hierarchy1>(hierarchyDataManger.GetHierarchy1Category());

        //add Root items
        foreach (Hierarchy1 hierarchy1 in Hierarchy1Names)
        {
            PictureHierarchy.Add(new HierarchyModel { Id = hierarchy1.Id, Name = hierarchy1.Name });
        }

        //add sub items
        for (int i = 0; i < PictureHierarchy.Count; i++)
        {
            string? hierarchy1Name = PictureHierarchy[i].Name;
            List<Hierarchy2> hierarchy2Category = hierarchyDataManger.GetHierarchy2Category(hierarchy1Name);
            foreach (Hierarchy2 hierarchy2 in hierarchy2Category)
            {
                PictureHierarchy[i].SubItem.Add(new HierarchyModel { Id = hierarchy2.Id, Name = hierarchy2.Name });
            }
        }
    }

    private void ShowAddObjectWindow()
    {
        AddObjectWindow addObjectWindow = new AddObjectWindow(_dataConnector);
        addObjectWindow.Show();
        addObjectWindow.Closed += AddObjectWindow_Closed;
    }

    private void AddObjectWindow_Closed(object sender, EventArgs e)
    {
        UpdateObjects();
    }

    private void ShowEditObjectWindow()
    {
        EditObjectWindow editObjectWindow = new EditObjectWindow(_dataConnector, SelectedObject);
        MessageBox.Show(SelectedObject.Description);
        editObjectWindow.Show();
        editObjectWindow.Closed += EditObjectWindow_Closed;
    }

    private void EditObjectWindow_Closed(object sender, EventArgs e)
    {
        UpdateObjects();
    }

    private void DeleteObject()
    {
        dataManager.DeleteObject(SelectedObject.Id);
        UpdateObjects();
    }

    private void UpdateObjects()
    {
        Objects = new ObservableCollection<ObjectModel>(dataManager.GetObjects());
    }
}
