using AutomationListLibrary.Data;
using AutomationListLibrary.DataAccess;

namespace AutomationListLibrary.DataManager;

public class ObjectDataManager : IObjectDataManager
{
	private readonly ISqlConnector _sqlConnector;

	public ObjectDataManager(ISqlConnector sqlConnector)
	{
		_sqlConnector = sqlConnector;
	}
	public async Task<ObjectModel?> GetObjectById(int id)
	{
		// Anonymous object, object with no name type
		// Id is parameter of object, id is input to that parameter
		var p = new { Id = id };

		// Need to await it before getting first entry
		var tagObjectList = await _sqlConnector.ReadDataAsync<ObjectModel, dynamic>("GetObjectById", p);
		return tagObjectList.FirstOrDefault();
	}

	public async Task<List<ObjectModel>> GetObjects()
	{
		// Anonymous object, object with no name type
		// No parameters, but need an object
		var p = new { };

		var tagObjectList = await _sqlConnector.ReadDataAsync<ObjectModel, dynamic>("GetAllObjects", p);
		return tagObjectList;
	}

	public async Task InsertObject(ObjectModel tagObject)
	{
		// Anonymous object, object with no name type
		var p = new
		{
			tagObject.SfiNumber,
			tagObject.MainEqNumber,
			tagObject.EqNumber,
			tagObject.Description,
			tagObject.VduGroup,
			tagObject.Hierarchy1,
			tagObject.Hierarchy2,
			tagObject.EasGroup,
			tagObject.AlarmGroup,
			tagObject.Otd,
			tagObject.ObjectType,
			tagObject.AcknowledgeAllowed,
			tagObject.AlwaysVisible,
			tagObject.Node,
			tagObject.Cabinet,
			tagObject.Revision
		};

		await _sqlConnector.WriteDataAsync("CreateObject", p);
	}

	public async Task UpdateObject(ObjectModel updatedObject)
	{
		var p = new
		{
			updatedObject.Id,
			updatedObject.SfiNumber,
			updatedObject.MainEqNumber,
			updatedObject.EqNumber,
			updatedObject.Description,
			updatedObject.VduGroup,
			updatedObject.Hierarchy1,
			updatedObject.Hierarchy2,
			updatedObject.EasGroup,
			updatedObject.AlarmGroup,
			updatedObject.Otd,
			updatedObject.ObjectType,
			updatedObject.AcknowledgeAllowed,
			updatedObject.AlwaysVisible,
			updatedObject.Node,
			updatedObject.Cabinet,
			updatedObject.Revision
		};

		await _sqlConnector.WriteDataAsync("UpdateObject", p);
	}

	public async Task<int> GetLastInsertedObjectId()
	{
		var p = new { };

		List<int> lastInsertedObjectIds = await _sqlConnector.ReadDataAsync<int, dynamic>("GetLastInsertedObjectId", p);
		return lastInsertedObjectIds.FirstOrDefault();
	}

	public async Task DeleteObject(int id)
	{
		// Anonymous object, object with no name type
		// Id is parameter of object, id is input to that parameter
		var p = new { Id = id };

		await _sqlConnector.WriteDataAsync("DeleteObject", p);
	}
}
