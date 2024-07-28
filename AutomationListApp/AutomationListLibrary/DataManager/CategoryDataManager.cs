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

    #region General methods
    public async Task<List<T>> GetCategory<T>(string tableName)
    {
        var p = new
        {
            TableName = tableName
        };

        return await _sqlConnector.ReadDataAsync<T, dynamic>("GetCategory", p);
    }
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
    #endregion

    #region Specific Get methods
    public async Task<List<Node>> GetNodeCategory() => await GetCategory<Node>("NODE");
    public async Task<List<AcknowledgeAllowed>> GetAckAllowedCategory() => await GetCategory<AcknowledgeAllowed>("ACKNOWLEDGE_ALLOWED");
    public async Task<List<AlwaysVisible>> GetAlwaysVisibleCategory() => await GetCategory<AlwaysVisible>("ALWAYS_VISIBLE");
    public async Task<List<Cabinet>> GetCabinetCategory() => await GetCategory<Cabinet>("CABINET");
    public async Task<List<Otd>> GetOtdCategory() => await GetCategory<Otd>("OTD");
    public async Task<List<VduGroup>> GetVduGroupCategory() => await GetCategory<VduGroup>("VDU_GROUP");
    public async Task<List<AlarmGroup>> GetAlarmGroupCategory() => await GetCategory<AlarmGroup>("ALARM_GROUP");
    public async Task<List<Hierarchy1>> GetHierarchy1Category() => await GetCategory<Hierarchy1>("HIERARCHY_1");
    public async Task<List<IoType>> GetIoTypeCategory() => await GetCategory<IoType>("IO_TYPE");
    public async Task<List<ObjectType>> GetObjectTypeCategory()
	{
		var p = new { };

		return await _sqlConnector.ReadDataAsync<ObjectType, dynamic>("GetObjectTypes", p);
	}
    public async Task<List<EngUnit>> GetEngUnitCategory()
    {
        var p = new {  };

        return await _sqlConnector.ReadDataAsync<EngUnit, dynamic>("GetEngUnits", p);
    }
	public async Task<string> GetOtdByObjectType(string objectType)
	{
		var p = new { ObjectType = objectType };

        var result = await _sqlConnector.ReadDataAsync<string, dynamic>("GetOtdByObjectType", p);
        return result.FirstOrDefault();
	}
    #endregion

    #region Specific Add methods
    public async Task AddHierarchy1Async(string hierarchy1Name) => await AddCategoryItem("HIERARCHY_1", hierarchy1Name);
    public async Task AddIoTypeAsync(string ioTypeName) => await AddCategoryItem("IO_TYPE", ioTypeName);
    public async Task AddEngUnitAsync(EngUnit engUnit)
    {
        var p = new
        {
            engUnit.Name,
            engUnit.UnitId
        };

        await _sqlConnector.ReadDataAsync<EngUnit, dynamic>("AddEngUnit", p);
    }
    #endregion

    #region Specific Edit methods
    public async Task EditHierarchy1Async(ICategory category) => await EditCategoryItem("HIERARCHY_1", category.Id, category.Name);
    public async Task EditIoTypeAsync(ICategory category) => await EditCategoryItem("IO_TYPE", category.Id, category.Name);
    public async Task EditEngUnitAsync(EngUnit engUnit)
    {
        var p = new
        {
            engUnit.Id,
            engUnit.Name,
            engUnit.UnitId
        };

        await _sqlConnector.ReadDataAsync<EngUnit, dynamic>("EditEngUnit", p);
    }
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
    #endregion

    #region Secific Delete methods
    public async Task DeleteHierarchy1Async(int id) => await DeleteCategoryItem("HIERARCHY_1", id);
    public async Task DeleteIoTypeAsync(int id) => await DeleteCategoryItem("IO_TYPE", id);
    public async Task DeleteEngUnitAsync(int id) => await DeleteCategoryItem("ENG_UNIT", id);
    #endregion
}
