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

    public List<SignalType> GetSignalTypeCategory(string ioType)
    {
        // Anonymous object, object with no name type
        // No parameters, but need an object
        var p = new
        {
            Name = ioType
        };

        return _sqlConnector.ReadData<SignalType, dynamic>("GetSignalTypesByGroup", p);
    }

    public List<OtdInterface> GetOtdInterfaces(string otdType)
    {
        var p = new
        {
            Name = otdType
        };
        return _sqlConnector.ReadData<OtdInterface, dynamic>("GetOtdInterfacesByGroup", p);
    }

    public List<Hierarchy2> GetHierarchy2Category(string hierarchy1Name)
    {
        // Anonymous object, object with no name type
        // No parameters, but need an object
        var p = new
        {
            Name = hierarchy1Name
        };

        List<Hierarchy2> hierarchy2Category = _sqlConnector.ReadData<Hierarchy2, dynamic>("GetHierarchy2ByGroup", p);
        return hierarchy2Category;
    }

    public void AddHierarchy2Category(string hierarchy1Name, string newHierarchy2Name)
    {
        // Anonymous object, object with no name type
        // No parameters, but need an object
        var p = new
        {
            Hierarchy1Name = hierarchy1Name,
            Hierarchy2Name = newHierarchy2Name
        };

        _sqlConnector.WriteData("AddHierarchy2", p);
    }

    public void DeleteHierarchy2Category(int id)
    {
        // Anonymous object, object with no name type
        // No parameters, but need an object
        var p = new
        {
            Id = id
        };

        _sqlConnector.WriteData("DeleteHierarchy2", p);
    }

    public void EditHierarchy2Category(int id, string updatedHierarchy2Name)
    {
        var p = new
        {
            Id = id,
            Name = updatedHierarchy2Name
        };

        _sqlConnector.WriteData("EditHierarchy2", p);
    }

    public List<string> GetHierarchy2Names(string hierarchy1Name)
    {
        // Anonymous object, object with no name type
        // No parameters, but need an object
        var p = new
        {
            Name = hierarchy1Name
        };

        List<string> hierarchy2Category = _sqlConnector.ReadData<string, dynamic>("GetHierarchy2NamesByGroup", p);
        return hierarchy2Category;
    }

    public List<string> GetSignalTypeNames(string ioType)
    {
        // Anonymous object, object with no name type
        // No parameters, but need an object
        var p = new
        {
            Name = ioType
        };

        return _sqlConnector.ReadData<string, dynamic>("GetSignalTypeNamesByGroup", p);
    }


}
