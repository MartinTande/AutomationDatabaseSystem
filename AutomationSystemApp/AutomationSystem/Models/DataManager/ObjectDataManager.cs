using AutomationSystem.Models.DataAccess;

namespace AutomationSystem.Models.DataManager;

public class ObjectDataManager
{
    private readonly IDataConnector _sqlConnector;

    public ObjectDataManager(IDataConnector sqlConnector)
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

    public Task<IEnumerable<ObjectModel>> GetObjects()
    {
        // Anonymous object, object with no name type
        // No parameters, but need an object
        var p = new { };

        var tagObjectList = _sqlConnector.ReadDataAsync<ObjectModel, dynamic>("GetAllObjects", p);
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
            tagObject.Hierarchy1Name,
            tagObject.Hierarchy2Name,
            tagObject.VduGroupName,
            tagObject.AlarmGroupName,
            tagObject.OtdName,
            tagObject.AcknowledgeAllowedName,
            tagObject.AlwaysVisibleName,
            tagObject.NodeName,
            tagObject.CabinetName
        };

        await _sqlConnector.WriteDataAsync("CreateObject", p);
    }

    public async Task UpdateObject(ObjectModel tagObject)
    {
        try
        {
            await _sqlConnector.WriteDataAsync("UpdateObject", tagObject);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<int> GetLastInsertedObjectId()
    {
        var p = new { };

        IEnumerable<int> lastInsertedObjectIds = await _sqlConnector.ReadDataAsync<int, dynamic>("GetLastInsertedObjectId", p);
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
