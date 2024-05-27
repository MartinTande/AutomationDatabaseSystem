using AutomationSystem.Models.Categories;
using AutomationSystem.Models.DataAccess;

namespace AutomationSystem.Models.DataManager;

public class CategoryDataManager
{
    private readonly IDataConnector _sqlConnector;

    public CategoryDataManager(IDataConnector sqlConnector)
    {
        _sqlConnector = sqlConnector;
    }
    public List<T> GetCategory<T>(string tableName)
    {
        var p = new
        {
            TableName = tableName
        };

        return _sqlConnector.ReadData<T, dynamic>("GetCategory", p);
    }

    public List<Node> GetNodeCategory() { return GetCategory<Node>("NODE"); }
    public List<AcknowledgeAllowed> GetAckAllowedCategory() { return GetCategory<AcknowledgeAllowed>("ACKNOWLEDGE_ALLOWED"); }
    public List<AlwaysVisible> GetAlwaysVisibleCategory() { return GetCategory<AlwaysVisible>("ALWAYS_VISIBLE"); }
    public List<Cabinet> GetCabinetCategory() { return GetCategory<Cabinet>("CABINET"); }
    public List<Otd> GetOtdCategory() { return GetCategory<Otd>("OTD"); }
    public List<VduGroup> GetVduGroupCategory() { return GetCategory<VduGroup>("VDU_GROUP"); }
    public List<AlarmGroup> GetAlarmGroupCategory() { return GetCategory<AlarmGroup>("ALARM_GROUP"); }
    public List<Hierarchy1> GetHierarchy1Category()  {  return GetCategory<Hierarchy1>("HIERARCHY_1");  }
    public List<EngUnit> GetEngUnitCategory() { return GetCategory<EngUnit>("ENG_UNIT"); }
    public List<IoType> GetIoTypeCategory() { return GetCategory<IoType>("IO_TYPE"); }

    public List<string> GetCategoryNames(string tableName)
    {
        var p = new
        {
            TableName = tableName
        };

        return _sqlConnector.ReadData<string, dynamic>("GetCategoryNames", p);
    }

    public List<string> GetAlarmGroupNames() { return GetCategoryNames("ALARM_GROUP"); }
    public List<string> GetNodeNames() { return GetCategoryNames("NODE"); }
    public List<string> GetAlwaysVisibleNames() { return GetCategoryNames("ALWAYS_VISIBLE"); }
    public List<string> GetAckowledgeAllowedNames() { return GetCategoryNames("ACKNOWLEDGE_ALLOWED"); }
    public List<string> GetVduGroupNames() { return GetCategoryNames("VDU_GROUP"); }
    public List<string> GetOtdNames() { return GetCategoryNames("OTD"); }
    public List<string> GetCabinetNames() { return GetCategoryNames("CABINET"); }
    public List<string> GetHierarchy1Names() { return GetCategoryNames("HIERARCHY_1"); }
    public List<string> GetIoTypeNames() { return GetCategoryNames("IO_TYPE"); }
    public List<string> GetEngUnitNames() { return GetCategoryNames("ENG_UNIT"); }

    private void DeleteCategoryItem(string tableName, int id)
    {
        // Anonymous object, object with no name type
        // No parameters, but need an object
        var p = new
        {
            TableName = tableName,
            Id = id
        };

        _sqlConnector.ReadData<string, dynamic>("DeleteCategoryItem", p);
    }

    private void EditCategoryItem(string tableName, int id, string updatedName)
    {
        var p = new
        {
            TableName = tableName,
            Id = id,
            Name = updatedName
        };

        _sqlConnector.ReadData<string, dynamic>("EditCategoryItem", p);
    }

    private void AddCategoryItem(string tableName, string name)
    {
        // Anonymous object, object with no name type
        // No parameters, but need an object
        var p = new
        {
            TableName = tableName,
            Name = name
        };

        _sqlConnector.ReadData<string, dynamic>("AddCategoryItem", p);
    }

    public void DeleteHierarchy1Category(int id) { DeleteCategoryItem("HIERARCHY_1", id); }

    public void EditHierarchy1Category(int id, string updatedHierarchy1Name) { EditCategoryItem("HIERARCHY_1", id, updatedHierarchy1Name); }

    public void AddHierarchy1Category(string hierarchy1Name) { AddCategoryItem("HIERARCHY_1", hierarchy1Name); }
}
