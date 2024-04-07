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
    CategoryDataManager categoryDataManager;
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

    private ObservableCollection<ObjectModel> _tagObjects;
    public ObservableCollection<ObjectModel> TagObjects
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

    private ObjectModel? _selectedTagObject;
    public ObjectModel? SelectedTagObject
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
    public ICommand AddHierarchySubItemCommand => new RelayCommand(execute => AddHierarchySubItem(), canExecute => CanAddSubItem());
    public ICommand AddHierarchyItemCommand => new RelayCommand(execute => AddHierarchyItem());
    public ICommand EditHierarchyItemCommand => new RelayCommand(execute => EditHierarchyItem(), canExecute => SelectedHierarchyItem != null);
    public ICommand DeleteHierarchyItemCommand => new RelayCommand(execute => DeleteHierarchyItem(), canExecute => SelectedHierarchyItem != null);

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
        //bool isHierarchy1 = Hierarchy1Names.Any(item => item.Name == SelectedHierarchyItem.Name);
        if (isHierarchy1Item(SelectedHierarchyItem.Name))
        {
            hierarchyDataManger.EditHierarchy1Category(SelectedHierarchyItem.Id, SelectedHierarchyName);
        }
        else
        {
            hierarchyDataManger.EditHierarchy2Category(SelectedHierarchyItem.Id, SelectedHierarchyName);
        }
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
        categoryDataManager = new CategoryDataManager(_dataConnector);
        hierarchyDataManger = new HierarchyDataManager(_dataConnector);
        _tagObjects = new ObservableCollection<ObjectModel>(dataManager.GetObjects());
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
        UpdateTagObjects();
    }

    private void ShowEditObjectWindow()
    {
        EditObjectWindow editObjectWindow = new EditObjectWindow(_dataConnector, SelectedTagObject);
        MessageBox.Show(SelectedTagObject.Description);
        editObjectWindow.Show();
        editObjectWindow.Closed += EditObjectWindow_Closed;
    }

    private void EditObjectWindow_Closed(object sender, EventArgs e)
    {
        UpdateTagObjects();
    }

    private void DeleteObject()
    {
        dataManager.DeleteObject(SelectedTagObject.Id);
        MessageBox.Show(SelectedTagObject.Id.ToString());
        UpdateTagObjects();
    }

    private void UpdateTagObjects()
    {
        TagObjects = new ObservableCollection<ObjectModel>(dataManager.GetObjects());
    }
}
