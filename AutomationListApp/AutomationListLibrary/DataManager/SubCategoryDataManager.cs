using AutomationSystem.Models.Data.Categories;
using AutomationSystem.Models.DataAccess;

namespace AutomationSystem.Models.DataManager;

public class SubCategoryDataManager
{
    private readonly IDataConnector _sqlConnector;

    public SubCategoryDataManager(IDataConnector sqlConnector)
    {
        _sqlConnector = sqlConnector;
    }

    public async Task<IEnumerable<SignalType>> GetSignalTypeCategory(string ioType)
    {
        // Anonymous object, object with no name type
        // No parameters, but need an object
        var p = new
        {
            Name = ioType
        };

        return await _sqlConnector.ReadDataAsync<SignalType, dynamic>("GetSignalTypesByGroup", p);
    }

    public async Task<IEnumerable<OtdInterface>> GetOtdInterfaces(string otdType)
    {
        var p = new
        {
            Name = otdType
        };
        return await _sqlConnector.ReadDataAsync<OtdInterface, dynamic>("GetOtdInterfacesByGroup", p);
    }

    public async Task<IEnumerable<Hierarchy2>> GetHierarchy2Category(string hierarchy1Name)
    {
        // Anonymous object, object with no name type
        // No parameters, but need an object
        var p = new
        {
            Name = hierarchy1Name
        };

        return await _sqlConnector.ReadDataAsync<Hierarchy2, dynamic>("GetHierarchy2ByGroup", p);
    }

    public async Task AddHierarchy2Category(string hierarchy1Name, string newHierarchy2Name)
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

    public void DeleteHierarchy2Category(int id)
    {
        // Anonymous object, object with no name type
        // No parameters, but need an object
        var p = new
        {
            Id = id
        };

        _sqlConnector.WriteDataAsync("DeleteHierarchy2", p);
    }

    public void EditHierarchy2Category(int id, string updatedHierarchy2Name)
    {
        var p = new
        {
            Id = id,
            Name = updatedHierarchy2Name
        };

        _sqlConnector.WriteDataAsync("EditHierarchy2", p);
    }

    public async Task<IEnumerable<string>> GetHierarchy2Names(string hierarchy1Name)
    {
        // Anonymous object, object with no name type
        // No parameters, but need an object
        var p = new
        {
            Name = hierarchy1Name
        };

        return await _sqlConnector.ReadDataAsync<string, dynamic>("GetHierarchy2NamesByGroup", p);
    }

    public async Task<IEnumerable<string>> GetSignalTypeNames(string ioType)
    {
        // Anonymous object, object with no name type
        // No parameters, but need an object
        var p = new
        {
            Name = ioType
        };

        return await _sqlConnector.ReadDataAsync<string, dynamic>("GetSignalTypeNamesByGroup", p);
    }


}
