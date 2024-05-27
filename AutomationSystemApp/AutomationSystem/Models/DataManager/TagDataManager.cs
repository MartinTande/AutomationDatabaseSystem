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

        List<TagModel> tagList = _sqlConnector.ReadData<TagModel, dynamic>("GetTagsByObjectId", p);
        return tagList;
    }

    public void DeleteTag(int tagId)
    {
        var p = new { Id = tagId };

        _sqlConnector.WriteData("DeleteTag", p);
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

        _sqlConnector.WriteData("CreateTag", p);
    }

    public void UpdateTag(TagModel tag)
    {
        // Anonymous object, object with no name type
        var p = new
        {
            tag.Id,
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

        _sqlConnector.WriteData("UpdateTag", p);
    }

    // Default tag structure for auto generating object tags based on OTD type
    public void AddTagsBasedOnOTD(int objectId, string otdName)
    {
        if (_otdTagStructure.ContainsKey(otdName))
        {
            List<TagModel> tags = _otdTagStructure[otdName];
            foreach (TagModel tag in tags)
            {
                InsertTag(objectId, tag);
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
}
