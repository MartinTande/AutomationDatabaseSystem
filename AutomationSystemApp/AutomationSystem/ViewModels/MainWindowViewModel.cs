using System.Collections.ObjectModel;
using System.Windows.Input;
using AutomationSystem.Commands;
using AutomationSystem.Views;
using AutomationSystem.MVVM;
using System.Windows;
using AutomationSystem.Models;
using AutomationSystem.Models.DataAccess;
using AutomationSystem.Models.DataManager;
using System.Windows.Controls;
using System.ComponentModel;
using System.Windows.Data;
using AutomationSystem.Models.Data.Categories;


namespace AutomationSystem.ViewModels;


internal class MainWindowViewModel : ViewModelBase
{
    private readonly IDataConnector _dataConnector;
    ObjectDataManager objectDataManager;
    TagDataManager tagDataManager;
    CategoryDataManager categoryDataManager;
    SubCategoryDataManager subCategoryDataManager;

    public ICollectionView ObjectCollectionView { get; set; }
    public RelayCommand CellEditEndingCommand { get; }
    public RelayCommand RowEditEndingCommand { get; }

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

    private ObservableCollection<IoType> _ioTypeNames;

    public ObservableCollection<IoType> IoTypeNames
    {
        get { return _ioTypeNames; }
        set
        {
            _ioTypeNames = value;
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

    private ObservableCollection<Otd> _otds;
    public ObservableCollection<Otd> Otds
    {
        get { return _otds; }
        set
        { 
            _otds = value;
            OnPropertyChanged();

        }
    }

    private ObservableCollection<Hierarchy1> _pictureHierarchy2;

    public ObservableCollection<Hierarchy1> PictureHierarchy2
    {
        get { return _pictureHierarchy2; }
        set 
        { 
            _pictureHierarchy2 = value; 
            OnPropertyChanged();
        }
    }

    private ObservableCollection<HierarchyModel> _pictureHierarchy;
    public ObservableCollection<HierarchyModel> PictureHierarchy
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

    private ObservableCollection<HierarchyModel> _ioTypeHierarchy;
    public ObservableCollection<HierarchyModel> IoTypeHierarchy
    {
        get { return _ioTypeHierarchy; }
        set
        {
            if (value != null)
            {
                _ioTypeHierarchy = value;
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

    private void ObjectModel_PropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == "Description")
        {
            MessageBox.Show("Testing testing");
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
            if (value != null)
            {
                _selectedObject = value;
                OnPropertyChanged();

                UpdateTags(SelectedObject.FullObjectName);
            }
        }
    }

    private Hierarchy1? _selectedProcessArea;
    public Hierarchy1? SelectedProcessArea
    {
        get { return _selectedProcessArea; }
        set 
        { 
            _selectedProcessArea = value; 
            OnPropertyChanged();
        }
    }

    private Otd _selectedOtd;

    public Otd SelectedOtd
    {
        get { return _selectedOtd; }
        set 
        { 
            _selectedOtd = value;
            OnPropertyChanged();
        }
    }

    private int _objectCount;

    public int ObjectCount
    {
        get { return _objectCount; }
        set 
        { 
            _objectCount = value;
            OnPropertyChanged();
        }
    }
    #endregion

    #region Filter
    private string _fullNameFilter = string.Empty;
    public string FullNameFilter
    {
        get { return _fullNameFilter; }
        set
        {
            _fullNameFilter = value;
            OnPropertyChanged();
            ObjectCollectionView.Refresh();
            UpdateObjectCount();
        }
    }

    private string _descriptionFilter = string.Empty;
    public string DescriptionFilter
    {
        get { return _descriptionFilter; }
        set
        {
            _descriptionFilter = value;
            OnPropertyChanged();
            ObjectCollectionView.Refresh();
            UpdateObjectCount();
        }
    }

    private string _hierarchy1Filter = string.Empty;
    public string Hierarchy1Filter
    {
        get { return _hierarchy1Filter; }
        set
        {
            _hierarchy1Filter = value;
            OnPropertyChanged();
            ObjectCollectionView.Refresh();
            UpdateObjectCount();
        }
    }

    private string _hierarchy2Filter = string.Empty;
    public string Hierarchy2Filter
    {
        get { return _hierarchy2Filter; }
        set
        {
            _hierarchy2Filter = value;
            OnPropertyChanged();
            ObjectCollectionView.Refresh();
            UpdateObjectCount();
        }
    }

    private string _vduGroupFilter = string.Empty;
    public string VduGroupFilter
    {
        get { return _vduGroupFilter; }
        set
        {
            _vduGroupFilter = value;
            OnPropertyChanged();
            ObjectCollectionView.Refresh();
            UpdateObjectCount();
        }
    }

    private string _alarmGroupFilter = string.Empty;
    public string AlarmGroupFilter
    {
        get { return _alarmGroupFilter; }
        set
        {
            _alarmGroupFilter = value;
            OnPropertyChanged();
            ObjectCollectionView.Refresh();
            UpdateObjectCount();
        }
    }

    private string _otdFilter = string.Empty;
    public string OtdFilter
    {
        get { return _otdFilter; }
        set
        {
            _otdFilter = value;
            OnPropertyChanged();
            ObjectCollectionView.Refresh();
            UpdateObjectCount();
        }
    }

    private string _nodeFilter = string.Empty;
    public string NodeFilter
    {
        get { return _nodeFilter; }
        set
        {
            _nodeFilter = value;
            OnPropertyChanged();
            ObjectCollectionView.Refresh();
            UpdateObjectCount();
        }
    }

    private string _cabinetFilter = string.Empty;
    public string CabinetFilter
    {
        get { return _cabinetFilter; }
        set
        {
            _cabinetFilter = value;
            OnPropertyChanged();
            ObjectCollectionView.Refresh();
            UpdateObjectCount();
        }
    }

    private string _acknowledgeAllowedFilter = string.Empty;
    public string AcknowledgeAllowedFilter
    {
        get { return _acknowledgeAllowedFilter; }
        set
        {
            _acknowledgeAllowedFilter = value;
            OnPropertyChanged();
            ObjectCollectionView.Refresh();
            UpdateObjectCount();
        }
    }

    private string _alwaysVisibleFilter = string.Empty;
    public string AlwaysVisibleFilter
    {
        get { return _alwaysVisibleFilter; }
        set
        {
            _alwaysVisibleFilter = value;
            OnPropertyChanged();
            ObjectCollectionView.Refresh();
            UpdateObjectCount();
        }
    }
    #endregion

    public MainWindowViewModel(IDataConnector dataConnector)
    {
        _dataConnector = dataConnector;

        //datamanagers
        objectDataManager = new ObjectDataManager(_dataConnector);
        tagDataManager = new TagDataManager(_dataConnector);
        subCategoryDataManager = new SubCategoryDataManager(_dataConnector);
        categoryDataManager = new CategoryDataManager(_dataConnector);
        
        //properties
        _objects = new ObservableCollection<ObjectModel>(objectDataManager.GetObjects());
        _tags = new ObservableCollection<TagModel>();
        _hierarchy1Names = new ObservableCollection<Hierarchy1>(categoryDataManager.GetHierarchy1Category());
        _pictureHierarchy = new ObservableCollection<HierarchyModel>();
        _ioTypeHierarchy = new ObservableCollection<HierarchyModel>();
        _otds = new ObservableCollection<Otd>(categoryDataManager.GetOtdCategory());
        _pictureHierarchy2 = new ObservableCollection<Hierarchy1>(categoryDataManager.GetHierarchy1Category());
        //objectModel.PropertyChanged += ObjectModel_PropertyChanged;

        ObjectCount = _objects.Count();
        ObjectCollectionView = CollectionViewSource.GetDefaultView(_objects);
        ObjectCollectionView.Filter = FilterObjects;
        ObjectCollectionView.SortDescriptions.Add(new SortDescription(nameof(ObjectModel.FullObjectName), ListSortDirection.Ascending));

        GetTagsForObjects();
        GetPictureHierarchy();
        GetOtdHierarchy();
        GetIoSignalTypes();
        GetPictureHierarchy2();
        //CellEditEndingCommand = new RelayCommand(OnCellEditEnding);
        //RowEditEndingCommand = new RelayCommand(OnRowEditEnding);
    }

    private bool FilterObjects(object obj)
    {
        if (obj is ObjectModel objectModel)
        {
            return objectModel.FullObjectName.Contains(FullNameFilter, StringComparison.InvariantCultureIgnoreCase) &&
                    objectModel.Description.Contains(DescriptionFilter, StringComparison.InvariantCultureIgnoreCase) &&
                    (objectModel.Hierarchy1Name?.Contains(Hierarchy1Filter, StringComparison.InvariantCultureIgnoreCase) ?? true) &&
                    (objectModel.Hierarchy2Name?.Contains(Hierarchy2Filter, StringComparison.InvariantCultureIgnoreCase) ?? true) &&
                    (objectModel.AcknowledgeAllowedName?.Contains(AcknowledgeAllowedFilter, StringComparison.InvariantCultureIgnoreCase) ?? true) &&
                    (objectModel.AlwaysVisibleName?.Contains(AlwaysVisibleFilter, StringComparison.InvariantCultureIgnoreCase) ?? true) &&
                    (objectModel.NodeName?.Contains(NodeFilter, StringComparison.InvariantCultureIgnoreCase) ?? true) &&
                    (objectModel.CabinetName?.Contains(CabinetFilter, StringComparison.InvariantCultureIgnoreCase) ?? true) &&
                    (objectModel.OtdName?.Contains(OtdFilter, StringComparison.InvariantCultureIgnoreCase) ?? true) &&
                    (objectModel.VduGroupName?.Contains(VduGroupFilter, StringComparison.InvariantCultureIgnoreCase) ?? true) &&
                    (objectModel.AlarmGroupName?.Contains(AlarmGroupFilter, StringComparison.InvariantCultureIgnoreCase) ?? true);
        }

        return false;
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

    #region Object functions
    private void UpdateObjectCount()
    {
        ObjectCount = ObjectCollectionView.Cast<object>().Where(item => item is ObjectModel).Count();
        OnPropertyChanged(nameof(ObjectCount));
    }
    private void ShowAddObjectWindow()
    {
        AddObjectWindow addObjectWindow = new AddObjectWindow(_dataConnector);
        addObjectWindow.Show();
        addObjectWindow.Closed += AddObjectWindow_Closed;
    }
    private void ShowEditObjectWindow()
    {
        EditObjectWindow editObjectWindow = new EditObjectWindow(_dataConnector, SelectedObject);
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
        _objects = new ObservableCollection<ObjectModel>(objectDataManager.GetObjects());
        OnPropertyChanged(nameof(Objects));

        // Use a collection view for filtering and sorting. even though it is not put as the binded object in XAML, this connects to the itemssource of the datagrid
        ObjectCollectionView = CollectionViewSource.GetDefaultView(_objects);
        ObjectCollectionView.Filter = FilterObjects;
        ObjectCollectionView.SortDescriptions.Add(new SortDescription(nameof(ObjectModel.FullObjectName), ListSortDirection.Ascending));
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

    private void GetTagsForObjects()
    {
        foreach (ObjectModel currentObject in Objects)
        {
            currentObject.Tags = tagDataManager.GetTagsByObjectId(currentObject.Id);
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

    private void ShowEditTagWindow()
    {
        EditTagWindow editTagWindow = new EditTagWindow(_dataConnector, SelectedTag);
        editTagWindow.Show();
        editTagWindow.Closed += EditTagWindow_Closed;
    }
    private void EditTagWindow_Closed(object sender, EventArgs e)
    {
        UpdateObjects();
        UpdateTags(SelectedObject.FullObjectName);
    }

    private void DeleteTag()
    {
        tagDataManager.DeleteTag(SelectedTag.Id);
        UpdateTags(SelectedObject.FullObjectName);
    }
    #endregion

    #region Picture Hierarchy functions
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

    private void GetPictureHierarchy2()
    {
        foreach (Hierarchy1 processArea in PictureHierarchy2)
        {
            processArea.SubPictures = subCategoryDataManager.GetHierarchy2Category(processArea.Name);
        }
    }
    #endregion

    #region Io/signal hierarchy functions


    private void GetIoSignalTypes()
    {
        if (IoTypeHierarchy != null)
        {
            IoTypeHierarchy.Clear();
        }
        IoTypeNames = new ObservableCollection<IoType>(categoryDataManager.GetIoTypeCategory());

        //add Root items
        foreach (IoType ioType in IoTypeNames)
        {
            IoTypeHierarchy.Add(new HierarchyModel { Id = ioType.Id, Name = ioType.Name });
        }

        //add sub items
        for (int i = 0; i < IoTypeHierarchy.Count; i++)
        {
            string? ioTypeName = IoTypeHierarchy[i].Name;
            List<SignalType> signalTypeCategory = subCategoryDataManager.GetSignalTypeCategory(ioTypeName);
            foreach (SignalType signalType in signalTypeCategory)
            {
                IoTypeHierarchy[i].SubItem.Add(new HierarchyModel { Id = signalType.Id, Name = signalType.Name });
            }
        }
    }

    #endregion

    #region Otd
    public void GetOtdHierarchy()
    {
        foreach (Otd otd in Otds)
        {
            otd.Interface = subCategoryDataManager.GetOtdInterfaces(otd.Name);
        }
    }

    #endregion

    private void OnCellEditEnding(object parameter)
    {
        // Your logic here
        // For example:
        if (parameter is DataGridCellEditEndingEventArgs e)
        {
            if (e.Column.SortMemberPath == "EndDate")
            {
                // Update properties based on the edited cell
                // ...
            }
        }
    }

    public void OnRowEditEnding(object parameter)
    {
        objectDataManager.UpdateObject(SelectedObject);
        ObjectModel test = (ObjectModel)parameter;
        OnPropertyChanged("SelectedObject");
    }

}
