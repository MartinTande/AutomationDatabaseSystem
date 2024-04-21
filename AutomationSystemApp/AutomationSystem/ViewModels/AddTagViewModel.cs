using AutomationSystem.Models;
using AutomationSystem.Models.DataAccess;
using AutomationSystem.Models.DataManager;
using AutomationSystem.MVVM;

namespace AutomationSystem.ViewModels;

internal class AddTagViewModel : ViewModelBase, ICloseable
{
    private readonly IDataConnector _dataConnector;
    TagDataManager _tagDataManager;

    public AddTagViewModel(IDataConnector dataConnector)
    {
        _dataConnector = dataConnector;
        _tagDataManager = new TagDataManager(dataConnector);
    }

    public void AddTag()
    {
        TagModel tagModel = new TagModel
        {
            Suffix = SuffixInput,
            //Description = DescriptionInput,
        };
    }
    public Action Close { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public int SuffixInput { get; private set; }
}
