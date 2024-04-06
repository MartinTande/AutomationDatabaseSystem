using System.Collections.ObjectModel;
using System.Windows.Input;
using AutomationSystem.Commands;
using AutomationSystem.Views;
using AutomationSystem.MVVM;
using System.Windows;
using AutomationSystem.Models;
using AutomationSystem.DataManager;
using AutomationSystem.Models.DataAccess;


namespace AutomationSystem.ViewModels;


internal class MainWindowViewModel : ViewModelBase
{
    private readonly IDataConnector _dataConnector;
    ObjectDataManager dataManager;
    CategoryDataManager categoryDataManager;

    // Properties
    private ObservableCollection<string> _hierarchy1Names;
    public ObservableCollection<string> Hierarchy1Names
    {
        get { return _hierarchy1Names; }
        set
        {
            _hierarchy1Names = value;
            OnPropertyChanged();
        }
    }
    private string? _selectedItem;

    public string? SelectedItem
    {
        get { return _selectedItem; }
        set
        {
            _selectedItem = value;
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

    private string textBound;

    public string TextBound
    {
        get { return textBound; }
        set { textBound = value; OnPropertyChanged(); }
    }

    private List<IItem> _pictureHierarchy;
    public List<IItem> PictureHierarchy
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

    private ObservableCollection<TagObjectModel> _tagObjects;
    public ObservableCollection<TagObjectModel> TagObjects
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

    private TagObjectModel? _selectedTagObject;
    public TagObjectModel? SelectedTagObject
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
    public ICommand AddHierarchyItemCommand => new RelayCommand(execute => AddHierarchyItem());
    public ICommand EditHierarchyItemCommand => new RelayCommand(execute => EditHierarchyItem());
    public ICommand DeleteHierarchyItemCommand => new RelayCommand(execute => DeleteHierarchyItem());

    private void EditHierarchyItem()
    {
        throw new NotImplementedException();
    }


    private void DeleteHierarchyItem()
    {
        throw new NotImplementedException();
    }

    private void AddHierarchyItem()
    {
        SelectedHierarchyName = SelectedHierarchyItem.Name;
    }

    public MainWindowViewModel(IDataConnector dataConnector)
    {
        _dataConnector = dataConnector;
        dataManager = new ObjectDataManager(_dataConnector);
        categoryDataManager = new CategoryDataManager(_dataConnector);
        _tagObjects = new ObservableCollection<TagObjectModel>(dataManager.GetTagObjects());
        _hierarchy1Names = new ObservableCollection<string>(categoryDataManager.GetHierarchy1Category());
        _pictureHierarchy = new List<IItem>();
        GetPictureHierarchy();
    }

    private void GetPictureHierarchy()
    {
        //add Root items
        foreach (string hierarchy1 in Hierarchy1Names)
        {
            PictureHierarchy.Add(new Hierarchy { Name = hierarchy1 });
        }

        //add sub items
        for (int i = 0; i < PictureHierarchy.Count; i++)
        {
            string? hierarchy1Name = PictureHierarchy[i].Name;
            List<string> hierarchy2Names = categoryDataManager.GetHierarchy2Category(hierarchy1Name);
            foreach (string name in hierarchy2Names)
            {
                PictureHierarchy[i].SubItem.Add(new Hierarchy { Name = name });
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
        MessageBox.Show(SelectedTagObject.ObjectDescription);
        editObjectWindow.Show();
        editObjectWindow.Closed += EditObjectWindow_Closed;
    }

    private void EditObjectWindow_Closed(object sender, EventArgs e)
    {
        UpdateTagObjects();
    }

    private void DeleteObject()
    {
        dataManager.DeleteTagObject(SelectedTagObject.ObjectId);
        MessageBox.Show(SelectedTagObject.ObjectId.ToString());
        UpdateTagObjects();
    }

    private void UpdateTagObjects()
    {
        TagObjects = new ObservableCollection<TagObjectModel>(dataManager.GetTagObjects());
    }
}
