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

    public void InsertTag(int objectId, TagModel tag)
    {
        // Anonymous object, object with no name type
        var p = new
        {
            ObjectId = objectId,
            tag.EqSuffix,
            tag.Description,
            tag.IoType,
            tag.SignalType,
            tag.EngUnit,
            tag.RangeLow,
            tag.RangeHigh,
            tag.LowLowLimit,
            tag.LowLimit,
            tag.HighLimit,
            tag.HighHighLimit,
            tag.Slot,
            tag.AbsoluteAddress,
            tag.SWPath,
            tag.DBName,
            tag.ModbusAddress,
            tag.ModbusBit,
            tag.IsE0,
            tag.IsVDR
        };

        _sqlConnector.SaveData("CreateTag", p);
    }
}
