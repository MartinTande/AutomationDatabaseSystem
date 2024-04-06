using AutomationSystem.Models;
using AutomationSystem.Models.DataAccess;

namespace AutomationSystem.DataManager;

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

        var tagObjectList = _sqlConnector.LoadData<ObjectModel, dynamic>("GetObjectById", p);
        return tagObjectList;
    }

    public List<ObjectModel> GetObjects()
    {
        // Anonymous object, object with no name type
        // No parameters, but need an object
        var p = new { };

        List<ObjectModel> tagObjectList = _sqlConnector.LoadData<ObjectModel, dynamic>("GetAllObjects", p);
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
            tagObject.CabinetName,
            tagObject.DataBlockName
        };

        _sqlConnector.SaveData("CreateObject", p);
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
            tagObject.CabinetName,
            tagObject.DataBlockName
        };
        Console.WriteLine(tagObject.Description);
        Console.WriteLine(tagObject.Id);
        try
        {
            _sqlConnector.SaveData("UpdateObject", p);
        }
        catch (Exception)
        {
            throw;
        }

    }

    public void DeleteObject(int id)
    {
        // Anonymous object, object with no name type
        // Id is parameter of object, id is input to that parameter
        var p = new { Id = id };

        _sqlConnector.SaveData("DeleteObject", p);
    }
}
