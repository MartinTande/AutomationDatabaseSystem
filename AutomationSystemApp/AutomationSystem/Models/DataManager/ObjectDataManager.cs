using AutomationSystem.Models.DataAccess;

namespace AutomationSystem.Models.DataManager;

public class ObjectDataManager
{
    private readonly IDataConnector _sqlConnector;

    public ObjectDataManager(IDataConnector sqlConnector)
    {
        _sqlConnector = sqlConnector;
    }
    public List<ObjectModel> GetObjectById(int id)
    {
        // Anonymous object, object with no name type
        // Id is parameter of object, id is input to that parameter
        var p = new { Id = id };

        var tagObjectList = _sqlConnector.ReadData<ObjectModel, dynamic>("GetObjectById", p);
        return tagObjectList;
    }

    public List<ObjectModel> GetObjects()
    {
        // Anonymous object, object with no name type
        // No parameters, but need an object
        var p = new { };

        List<ObjectModel> tagObjectList = _sqlConnector.ReadData<ObjectModel, dynamic>("GetAllObjects", p);
        return tagObjectList;
    }

    public void InsertObject(ObjectModel tagObject)
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

        _sqlConnector.WriteData("CreateObject", p);
    }

    public void UpdateObject(ObjectModel tagObject)
    {
        // Anonymous object, object with no name type
        var p = new
        {
            tagObject.Id,
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

        try
        {
            _sqlConnector.WriteData("UpdateObject", p);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public int GetLastInsertedObjectId()
    {
        var p = new { };
        
        List<int> lastInsertedObjectIds= _sqlConnector.ReadData<int, dynamic>("GetLastInsertedObjectId", p);
        return lastInsertedObjectIds.First();
    }

    public void DeleteObject(int id)
    {
        // Anonymous object, object with no name type
        // Id is parameter of object, id is input to that parameter
        var p = new { Id = id };

        _sqlConnector.WriteData("DeleteObject", p);
    }
}
