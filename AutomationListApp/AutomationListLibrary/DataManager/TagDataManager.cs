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

    public async Task<List<TagModel>> GetTagsByObjectIdAsync(int objectId)
    {
        // Anonymous object, object with no name type
        // Id is parameter of object, id is input to that parameter
        var p = new { ObjectId = objectId };

        List<TagModel> tagList = await _sqlConnector.ReadDataAsync<TagModel, dynamic>("GetTagsByObjectId", p);
        return tagList;
    }

	public async Task<List<TagModel>> GetTagsByObjectTypeAsync(string objectType)
	{
		var p = new { ObjectType = objectType };

		List<TagModel> tagList = await _sqlConnector.ReadDataAsync<TagModel, dynamic>("GetTagsByObjectType", p);
		return tagList;
	}

	public async Task DeleteTagAsync(int tagId)
    {
        var p = new { Id = tagId };

        await _sqlConnector.WriteDataAsync("DeleteTag", p);
    }

    public async Task InsertTagAsync(int objectId, TagModel tag)
    {
        // Anonymous object, object with no name type
        var p = new
        {
            ObjectId = objectId,
			tag.EqSuffix,
			tag.Description,
			tag.IoType,
			tag.SignalType,
			tag.Symbol,
			tag.EngUnit,
			tag.AlarmDelay,
			tag.RangeLow,
			tag.RangeHigh,
			tag.LowLowLimit,
			tag.LowLimit,
			tag.HighLimit,
			tag.HighHighLimit,
			tag.Slot,
			tag.Channel,
			tag.TP1,
			tag.TP2,
			tag.TP3,
			tag.TP4,
			tag.AbsoluteAddress,
			tag.SWPath,
			tag.DBName,
			tag.ModbusAddress,
			tag.ModbusBit,
			tag.IsE0,
			tag.IsVDR,
			tag.IOStatus,
			tag.InterfaceModule,
			tag.UserLock,
			tag.IOLock,
			tag.BeijerBoxId
		};

        await _sqlConnector.WriteDataAsync("CreateTag", p);
    }

    public async Task UpdateTagAsync(TagModel tag)
    {
        // Anonymous object, object with no name type
        var p = new
        {
            tag.Id,
            tag.ObjectId,
			tag.EqSuffix,
			tag.Description,
			tag.IoType,
			tag.SignalType,
			tag.Symbol,
			tag.EngUnit,
			tag.AlarmDelay,
			tag.RangeLow,
			tag.RangeHigh,
			tag.LowLowLimit,
			tag.LowLimit,
			tag.HighLimit,
			tag.HighHighLimit,
			tag.Slot,
			tag.Channel, 
			tag.TP1,
			tag.TP2,
			tag.TP3,
			tag.TP4,
			tag.AbsoluteAddress,
			tag.SWPath,
			tag.DBName,
			tag.ModbusAddress,
			tag.ModbusBit,
			tag.IsE0,
			tag.IsVDR,
			tag.IOStatus,
			tag.InterfaceModule,
			tag.UserLock,
			tag.IOLock,
			tag.BeijerBoxId
		};

        await _sqlConnector.WriteDataAsync("UpdateTag", p);
    }

}
