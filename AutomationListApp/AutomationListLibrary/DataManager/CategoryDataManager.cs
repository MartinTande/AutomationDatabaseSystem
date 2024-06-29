using AutomationListLibrary.Data;
using AutomationListLibrary.DataAccess;

namespace AutomationListLibrary.DataManager;

public class CategoryDataManager
{
    private readonly ISqlConnector _sqlConnector;

    public CategoryDataManager(ISqlConnector sqlConnector)
    {
        _sqlConnector = sqlConnector;
    }
    public async Task<List<T>> GetCategory<T>(string tableName)
    {
        var p = new
        {
            TableName = tableName
        };

        return await _sqlConnector.ReadDataAsync<T, dynamic>("GetCategory", p);
    }

    public Task<List<Node>> GetNodeCategory() { return GetCategory<Node>("NODE"); }
    public Task<List<AcknowledgeAllowed>> GetAckAllowedCategory() { return GetCategory<AcknowledgeAllowed>("ACKNOWLEDGE_ALLOWED"); }
    public Task<List<AlwaysVisible>> GetAlwaysVisibleCategory() { return GetCategory<AlwaysVisible>("ALWAYS_VISIBLE"); }
    public Task<List<Cabinet>> GetCabinetCategory() { return GetCategory<Cabinet>("CABINET"); }
    public Task<List<Otd>> GetOtdCategory() { return GetCategory<Otd>("OTD"); }
    public Task<List<VduGroup>> GetVduGroupCategory() { return GetCategory<VduGroup>("VDU_GROUP"); }
    public Task<List<AlarmGroup>> GetAlarmGroupCategory() { return GetCategory<AlarmGroup>("ALARM_GROUP"); }
    public Task<List<Hierarchy1>> GetHierarchy1Category() { return GetCategory<Hierarchy1>("HIERARCHY_1"); }
    public Task<List<EngUnit>> GetEngUnitCategory() { return GetCategory<EngUnit>("ENG_UNIT"); }
    public Task<List<IoType>> GetIoTypeCategory() { return GetCategory<IoType>("IO_TYPE"); }

    public Task<List<string>> GetCategoryNames(string tableName)
    {
        var p = new
        {
            TableName = tableName
        };

        return _sqlConnector.ReadDataAsync<string, dynamic>("GetCategoryNames", p);
    }

    public Task<List<string>> GetAlarmGroupNames() { return GetCategoryNames("ALARM_GROUP"); }
    public Task<List<string>> GetNodeNames() { return GetCategoryNames("NODE"); }
    public Task<List<string>> GetAlwaysVisibleNames() { return GetCategoryNames("ALWAYS_VISIBLE"); }
    public Task<List<string>> GetAckowledgeAllowedNames() { return GetCategoryNames("ACKNOWLEDGE_ALLOWED"); }
    public Task<List<string>> GetVduGroupNames() { return GetCategoryNames("VDU_GROUP"); }
    public Task<List<string>> GetOtdNames() { return GetCategoryNames("OTD"); }
    public Task<List<string>> GetCabinetNames() { return GetCategoryNames("CABINET"); }
    public Task<List<string>> GetHierarchy1Names() { return GetCategoryNames("HIERARCHY_1"); }
    public Task<List<string>> GetIoTypeNames() { return GetCategoryNames("IO_TYPE"); }
    public Task<List<string>> GetEngUnitNames() { return GetCategoryNames("ENG_UNIT"); }

    private void DeleteCategoryItem(string tableName, int id)
    {
        // Anonymous object, object with no name type
        // No parameters, but need an object
        var p = new
        {
            TableName = tableName,
            Id = id
        };

        _sqlConnector.ReadDataAsync<string, dynamic>("DeleteCategoryItem", p);
    }

    private void EditCategoryItem(string tableName, int id, string updatedName)
    {
        var p = new
        {
            TableName = tableName,
            Id = id,
            Name = updatedName
        };

        _sqlConnector.ReadDataAsync<string, dynamic>("EditCategoryItem", p);
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

        _sqlConnector.WriteDataAsync("AddCategoryItem", p);
    }

    public void DeleteHierarchy1Category(int id) { DeleteCategoryItem("HIERARCHY_1", id); }

    public void EditHierarchy1Category(int id, string updatedHierarchy1Name) { EditCategoryItem("HIERARCHY_1", id, updatedHierarchy1Name); }

    public void AddHierarchy1Category(string hierarchy1Name) { AddCategoryItem("HIERARCHY_1", hierarchy1Name); }

    public void UpdateOtds(List<Otd> otds)
    {
        // Delete all Otds and Otd interfaces
        _sqlConnector.WriteDataAsync("DeleteOtdInterfaces", new { });

        // Add Otds and Otd interfaces again
        foreach (Otd otd in otds)
        {
            AddCategoryItem("OTD", otd.Name);

            foreach (OtdInterface otdInterface in otd.Interface)
            {
                var p = new
                {
                    OtdName = otd.Name,
                    OtdInterfaceName = otdInterface.Name,
                    Suffix = otdInterface.Suffix,
                    DataType = otdInterface.DataType,
                    InterfaceType = otdInterface.InterfaceType,
                    IsOptional = otdInterface.IsOptional
                };
                _sqlConnector.WriteDataAsync("AddOtdInterface", p);
            }
        }
    }
}
