using AutomationListLibrary.Data;
using AutomationListLibrary.DataAccess;

namespace AutomationListLibrary.DataManager;

public class TagDataManager
{
    private readonly ISqlConnector _sqlConnector;

    public TagDataManager(ISqlConnector sqlConnector)
    {
        _sqlConnector = sqlConnector;
    }

    public Task<List<TagModel>> GetTagsByObjectId(int objectId)
    {
        // Anonymous object, object with no name type
        // Id is parameter of object, id is input to that parameter
        var p = new { ObjectId = objectId };

        Task<List<TagModel>> tagList = _sqlConnector.ReadDataAsync<TagModel, dynamic>("GetTagsByObjectId", p);
        return tagList;
    }

    public async Task DeleteTag(int tagId)
    {
        var p = new { Id = tagId };

        await _sqlConnector.WriteDataAsync("DeleteTag", p);
    }

    public async Task InsertTag(int objectId, TagModel tag)
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

        await _sqlConnector.WriteDataAsync("CreateTag", p);
    }

    public async Task UpdateTag(TagModel tag)
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

        await _sqlConnector.WriteDataAsync("UpdateTag", p);
    }

    // Default tag structure for auto generating object tags based on OTD type
    public async Task AddTagsBasedOnOTD(int objectId, string otdName)
    {
        if (_otdTagStructure.ContainsKey(otdName))
        {
            List<TagModel> tags = _otdTagStructure[otdName];
            foreach (TagModel tag in tags)
            {
                await InsertTag(objectId, tag);
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
        },
        {
            "BO_AnalogIn", [
                new TagModel { EqSuffix = 41, Description = "Value", IoType = "AI", SignalType = "Int" }
                ]
        },
        {
            "BO_Value", [
                new TagModel { EqSuffix = 41, Description = "Value", IoType = "AI", SignalType = "Int" }
                ]
        },
        {
            "BO_Breaker", [
                new TagModel { EqSuffix = 32, Description = "Open feedback", IoType = "DI", SignalType = "NO" },
                new TagModel { EqSuffix = 31, Description = "Close feedback", IoType = "DI", SignalType = "NO" },
                new TagModel { EqSuffix = 34, Description = "Open command", IoType = "DO", SignalType = "NO" },
                new TagModel { EqSuffix = 33, Description = "Close command", IoType = "DO", SignalType = "NO" },
                ]
        },
        {
            "BO_Tank", [
                new TagModel { EqSuffix = 21, Description = "Level", IoType = "AI", SignalType = "U_AnalogValueLong" }
                ]
        },
        {
            "BO_1DI", [
                new TagModel { EqSuffix = 01, Description = "Alarm", IoType = "DI", SignalType = "NO" }
                ]
        },
    };
}
