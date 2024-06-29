using AutomationSystem.Models.Categories;
using AutomationSystem.Models.Data.Categories;
using AutomationSystem.Models.DataAccess;
using System.Windows;

namespace AutomationSystem.Models.DataManager;

public class CategoryDataManager
{
    private readonly IDataConnector _sqlConnector;

    public CategoryDataManager(IDataConnector sqlConnector)
    {
        _sqlConnector = sqlConnector;
    }
    public async Task<IEnumerable<T>> GetCategory<T>(string tableName)
    {
        var p = new
        {
            TableName = tableName
        };

        return await _sqlConnector.ReadDataAsync<T, dynamic>("GetCategory", p);
    }

    public Task<IEnumerable<Node>> GetNodeCategory() { return GetCategory<Node>("NODE"); }
    public Task<IEnumerable<AcknowledgeAllowed>> GetAckAllowedCategory() { return GetCategory<AcknowledgeAllowed>("ACKNOWLEDGE_ALLOWED"); }
    public Task<IEnumerable<AlwaysVisible>> GetAlwaysVisibleCategory() { return GetCategory<AlwaysVisible>("ALWAYS_VISIBLE"); }
    public Task<IEnumerable<Cabinet>> GetCabinetCategory() { return GetCategory<Cabinet>("CABINET"); }
    public Task<IEnumerable<Otd>> GetOtdCategory() { return GetCategory<Otd>("OTD"); }
    public Task<IEnumerable<VduGroup>> GetVduGroupCategory() { return GetCategory<VduGroup>("VDU_GROUP"); }
    public Task<IEnumerable<AlarmGroup>> GetAlarmGroupCategory() { return GetCategory<AlarmGroup>("ALARM_GROUP"); }
    public Task<IEnumerable<Hierarchy1>> GetHierarchy1Category() { return GetCategory<Hierarchy1>("HIERARCHY_1"); }
    public Task<IEnumerable<EngUnit>> GetEngUnitCategory() { return GetCategory<EngUnit>("ENG_UNIT"); }
    public Task<IEnumerable<IoType>> GetIoTypeCategory() { return GetCategory<IoType>("IO_TYPE"); }

    public Task<IEnumerable<string>> GetCategoryNames(string tableName)
    {
        var p = new
        {
            TableName = tableName
        };

        return _sqlConnector.ReadDataAsync<string, dynamic>("GetCategoryNames", p);
    }

    public Task<IEnumerable<string>> GetAlarmGroupNames() { return GetCategoryNames("ALARM_GROUP"); }
    public Task<IEnumerable<string>> GetNodeNames() { return GetCategoryNames("NODE"); }
    public Task<IEnumerable<string>> GetAlwaysVisibleNames() { return GetCategoryNames("ALWAYS_VISIBLE"); }
    public Task<IEnumerable<string>> GetAckowledgeAllowedNames() { return GetCategoryNames("ACKNOWLEDGE_ALLOWED"); }
    public Task<IEnumerable<string>> GetVduGroupNames() { return GetCategoryNames("VDU_GROUP"); }
    public Task<IEnumerable<string>> GetOtdNames() { return GetCategoryNames("OTD"); }
    public Task<IEnumerable<string>> GetCabinetNames() { return GetCategoryNames("CABINET"); }
    public Task<IEnumerable<string>> GetHierarchy1Names() { return GetCategoryNames("HIERARCHY_1"); }
    public Task<IEnumerable<string>> GetIoTypeNames() { return GetCategoryNames("IO_TYPE"); }
    public Task<IEnumerable<string>> GetEngUnitNames() { return GetCategoryNames("ENG_UNIT"); }

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
        MessageBox.Show("Done");
    }
}
