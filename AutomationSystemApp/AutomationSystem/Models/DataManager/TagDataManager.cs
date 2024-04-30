using AutomationSystem.Models.DataAccess;

namespace AutomationSystem.Models.DataManager;

public class TagDataManager
{
    private readonly IDataConnector _sqlConnector;

    public TagDataManager(IDataConnector sqlConnector)
    {
        _sqlConnector = sqlConnector;
    }

    public List<TagModel> GetTagsByObjectId(int objectId)
    {
        // Anonymous object, object with no name type
        // Id is parameter of object, id is input to that parameter
        var p = new { ObjectId = objectId };

        List<TagModel> tagList = _sqlConnector.LoadData<TagModel, dynamic>("GetTagsByObjectId", p);
        return tagList;
    }

    public void DeleteTag(int tagId)
    {
        var p = new { Id = tagId };

        _sqlConnector.SaveData("DeleteTag", p);
    }

    public void InsertTag(TagModel tag)
    {
        // Anonymous object, object with no name type
        var p = new
        {
            tag.Suffix,
            tag.Description,
            tag.SignalType,
            tag.IoType,
            tag.LowLimit,
            tag.LowLowLimit,
            tag.HighLimit,
            tag.HighHighLimit
        };

        _sqlConnector.SaveData("CreateTag", p);
    }
}
