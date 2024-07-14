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

    public Task<List<Node>> GetNodeCategory() => GetCategory<Node>("NODE");
    public Task<List<AcknowledgeAllowed>> GetAckAllowedCategory() => GetCategory<AcknowledgeAllowed>("ACKNOWLEDGE_ALLOWED");
    public Task<List<AlwaysVisible>> GetAlwaysVisibleCategory() => GetCategory<AlwaysVisible>("ALWAYS_VISIBLE");
    public Task<List<Cabinet>> GetCabinetCategory() => GetCategory<Cabinet>("CABINET");
    public Task<List<Otd>> GetOtdCategory() => GetCategory<Otd>("OTD");
    public Task<List<VduGroup>> GetVduGroupCategory() => GetCategory<VduGroup>("VDU_GROUP");
    public Task<List<AlarmGroup>> GetAlarmGroupCategory() => GetCategory<AlarmGroup>("ALARM_GROUP");
    public Task<List<Hierarchy1>> GetHierarchy1Category() => GetCategory<Hierarchy1>("HIERARCHY_1");
    public Task<List<EngUnit>> GetEngUnitCategory() => GetCategory<EngUnit>("ENG_UNIT");
    public Task<List<IoType>> GetIoTypeCategory() => GetCategory<IoType>("IO_TYPE");

    public async Task<List<string>> GetCategoryNames(string tableName)
    {
        var p = new
        {
            TableName = tableName
        };

        return await _sqlConnector.ReadDataAsync<string, dynamic>("GetCategoryNames", p);
    }

    public async Task<List<string>> GetAlarmGroupNames() => await GetCategoryNames("ALARM_GROUP");
    public async Task<List<string>> GetNodeNames() => await GetCategoryNames("NODE");
    public async Task<List<string>> GetAlwaysVisibleNames() => await GetCategoryNames("ALWAYS_VISIBLE");
    public async Task<List<string>> GetAckowledgeAllowedNames() => await GetCategoryNames("ACKNOWLEDGE_ALLOWED");
    public async Task<List<string>> GetVduGroupNames() => await GetCategoryNames("VDU_GROUP");
    public async Task<List<string>> GetOtdNames() => await GetCategoryNames("OTD");
    public async Task<List<string>> GetCabinetNames() => await GetCategoryNames("CABINET");
    public async Task<List<string>> GetHierarchy1Names() => await GetCategoryNames("HIERARCHY_1");
    public async Task<List<string>> GetIoTypeNames() => await GetCategoryNames("IO_TYPE");
    public async Task<List<string>> GetEngUnitNames() => await GetCategoryNames("ENG_UNIT");

    private async Task DeleteCategoryItem(string tableName, int id)
    {
        // Anonymous object, object with no name type
        // No parameters, but need an object
        var p = new
        {
            TableName = tableName,
            Id = id
        };

        await _sqlConnector.ReadDataAsync<string, dynamic>("DeleteCategoryItem", p);
    }

    private async Task EditCategoryItem(string tableName, int id, string updatedName)
    {
        var p = new
        {
            TableName = tableName,
            Id = id,
            Name = updatedName
        };

        await _sqlConnector.ReadDataAsync<string, dynamic>("EditCategoryItem", p);
    }

    private async Task AddCategoryItem(string tableName, string name)
    {
        // Anonymous object, object with no name type
        // No parameters, but need an object
        var p = new
        {
            TableName = tableName,
            Name = name
        };

        await _sqlConnector.WriteDataAsync("AddCategoryItem", p);
    }

    public async Task DeleteHierarchy1Category(int id) => await DeleteCategoryItem("HIERARCHY_1", id);

    public async Task EditHierarchy1Category(ICategory category) => await EditCategoryItem("HIERARCHY_1", category.Id, category.Name);

    public async Task AddHierarchy1Category(string hierarchy1Name) => await AddCategoryItem("HIERARCHY_1", hierarchy1Name);

    public async Task UpdateOtds(List<Otd> otds)
    {
        // Delete all Otds and Otd interfaces
        await _sqlConnector.WriteDataAsync("DeleteOtdInterfaces", new { });

        // Add Otds and Otd interfaces again
        foreach (Otd otd in otds)
        {
            await AddCategoryItem("OTD", otd.Name);

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
                await _sqlConnector.WriteDataAsync("AddOtdInterface", p);
            }
        }
    }
}
