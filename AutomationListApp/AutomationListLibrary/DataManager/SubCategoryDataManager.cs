using AutomationListLibrary.Data;
using AutomationListLibrary.DataAccess;

namespace AutomationListLibrary.DataManager;

public class SubCategoryDataManager
{
    private readonly ISqlConnector _sqlConnector;

    public SubCategoryDataManager(ISqlConnector sqlConnector)
    {
        _sqlConnector = sqlConnector;
    }

    public async Task<List<SignalType>> GetSignalTypesAsync(string ioType)
    {
        // Anonymous object, object with no name type
        // No parameters, but need an object
        var p = new
        {
            IoTypeName = ioType
        };

        return await _sqlConnector.ReadDataAsync<SignalType, dynamic>("GetSignalTypesByIoType", p);
    }

	public async Task<List<OtdInterface>> GetOtdInterfacesAsync(string otdType)
    {
        var p = new
        {
            Name = otdType
        };
        return await _sqlConnector.ReadDataAsync<OtdInterface, dynamic>("GetOtdInterfacesByGroup", p);
    }

    public async Task<IEnumerable<Hierarchy2>> GetHierarchy2CategoryAsync(string hierarchy1Name)
    {
        // Anonymous object, object with no name type
        // No parameters, but need an object
        var p = new
        {
            Name = hierarchy1Name
        };

        return await _sqlConnector.ReadDataAsync<Hierarchy2, dynamic>("GetHierarchy2ByGroup", p);
    }

    public async Task AddHierarchy2CategoryAsync(string hierarchy1Name, string newHierarchy2Name)
    {
        // Anonymous object, object with no name type
        // No parameters, but need an object
        var p = new
        {
            Hierarchy1Name = hierarchy1Name,
            Hierarchy2Name = newHierarchy2Name
        };

        await _sqlConnector.WriteDataAsync("AddHierarchy2", p);
    }

    public async Task DeleteHierarchy2CategoryAsync(int id)
    {
        // Anonymous object, object with no name type
        // No parameters, but need an object
        var p = new
        {
            Id = id
        };

        await _sqlConnector.WriteDataAsync("DeleteHierarchy2", p);
    }

    public async Task EditHierarchy2Category(ICategory category)
    {
        var p = new
        {
            category.Id,
            category.Name
        };

        await _sqlConnector.WriteDataAsync("EditHierarchy2", p);
    }
}
