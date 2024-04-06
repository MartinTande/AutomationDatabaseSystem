using AutomationSystem.Models.DataAccess;

namespace AutomationSystem.DataManager;

public class CategoryDataManager
{
    private readonly IDataConnector _sqlConnector;

    public CategoryDataManager(IDataConnector sqlConnector)
    {
        _sqlConnector = sqlConnector;
    }

    private List<string> GetCategory(string tableName, string tableColumn)
    {
        // Anonymous object, object with no name type
        // No parameters, but need an object
        var p = new { TableName = tableName, TableColumn = tableColumn };

        List<string> category = _sqlConnector.LoadData<string, dynamic>("GetCategory", p);
        return category;
    }

    public List<string> GetHierarchy2Category(string hierarchy1Name)
    {
        // Anonymous object, object with no name type
        // No parameters, but need an object
        var p = new { Hierarchy1Name = hierarchy1Name };

        List<string> hierarchy2Category = _sqlConnector.LoadData<string, dynamic>("GetHierarchy2Data", p);
        return hierarchy2Category;
    }

    public void AddHierarchy2Category(string hierarchy1Name, string newHierarchy2)
    {
        // Anonymous object, object with no name type
        // No parameters, but need an object
        var p = new { Hierarchy1Name = hierarchy1Name, Hierarchy2Name = newHierarchy2 };

        _sqlConnector.LoadData<string, dynamic>("AddHierarchy2", p);
    }

    public List<string> GetHierarchy1Category()
    {
        return GetCategory("HIERARCHY_1", "Hierarchy1Name");
    }

    public List<string> GetNodeCategory()
    {
        return GetCategory("NODE", "NodeName");
    }

    public List<string> GetAckAllowedCategory()
    {
        return GetCategory("ACKNOWLEDGE_ALLOWED", "AcknowledgeAllowedName");
    }

    public List<string> GetAlwaysVisibleCategory()
    {
        return GetCategory("ALWAYS_VISIBLE", "AlwaysVisibleLocation");
    }

    public List<string> GetCabinetCategory()
    {
        return GetCategory("CABINET", "CabinetName");
    }

    public List<string> GetOtdCategory()
    {
        return GetCategory("OTD", "OtdName");
    }

    public List<string> GetVduGroupCategory()
    {
        return GetCategory("VDU_GROUP", "VduGroupName");
    }

    public List<string> GetAlarmGroupCategory()
    {
        return GetCategory("ALARM_GROUP", "AlarmGroupName");
    }

    public List<string> GetHierarchy2CategoryNames(int id)
    {
        // Anonymous object, object with no name type
        // No parameters, but need an object
        var p = new { Id = id };

        List<string> category = _sqlConnector.LoadData<string, dynamic>("GetHierarchy2Data", p);
        return category;
    }
}
