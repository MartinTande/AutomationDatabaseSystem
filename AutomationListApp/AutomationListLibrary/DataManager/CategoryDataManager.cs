﻿using AutomationListLibrary.Data;
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

    public async Task<List<Node>> GetNodeCategory() => await GetCategory<Node>("NODE");
    public async Task<List<AcknowledgeAllowed>> GetAckAllowedCategory() => await GetCategory<AcknowledgeAllowed>("ACKNOWLEDGE_ALLOWED");
    public async Task<List<AlwaysVisible>> GetAlwaysVisibleCategory() => await GetCategory<AlwaysVisible>("ALWAYS_VISIBLE");
    public async Task<List<Cabinet>> GetCabinetCategory() => await GetCategory<Cabinet>("CABINET");
    public async Task<List<Otd>> GetOtdCategory() => await GetCategory<Otd>("OTD");
    public async Task<List<VduGroup>> GetVduGroupCategory() => await GetCategory<VduGroup>("VDU_GROUP");
    public async Task<List<AlarmGroup>> GetAlarmGroupCategory() => await GetCategory<AlarmGroup>("ALARM_GROUP");
    public async Task<List<Hierarchy1>> GetHierarchy1Category() => await GetCategory<Hierarchy1>("HIERARCHY_1");
    public async Task<List<EngUnit>> GetEngUnitCategory() => await GetCategory<EngUnit>("ENG_UNIT");
    public async Task<List<IoType>> GetIoTypeCategory() => await GetCategory<IoType>("IO_TYPE");

    public async Task<List<string>> GetCategoryNames(string tableName)
    {
        var p = new
        {
            TableName = tableName
        };

        return await _sqlConnector.ReadDataAsync<string, dynamic>("GetCategoryNames", p);
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
