using AutomationSystem.Models.DataAccess;

namespace AutomationSystem.Models.DataManager;

public class HierarchyDataManager
{
    private readonly IDataConnector _sqlConnector;

    public HierarchyDataManager(IDataConnector sqlConnector)
    {
        _sqlConnector = sqlConnector;
    }

    public List<Hierarchy2> GetHierarchy2Category(string hierarchy1Name)
    {
        // Anonymous object, object with no name type
        // No parameters, but need an object
        var p = new
        {
            Hierarchy1Name = hierarchy1Name
        };

        List<Hierarchy2> hierarchy2Category = _sqlConnector.LoadData<Hierarchy2, dynamic>("GetHierarchy2Data", p);
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

        _sqlConnector.LoadData<string, dynamic>("AddHierarchy2", p);
    }

    public void AddHierarchy1Category(string hierarchy1Name)
    {
        // Anonymous object, object with no name type
        // No parameters, but need an object
        var p = new
        {
            Hierarchy1Name = hierarchy1Name
        };

        _sqlConnector.LoadData<string, dynamic>("AddHierarchy1", p);
    }

    public void DeleteHierarchy2Category(int id)
    {
        // Anonymous object, object with no name type
        // No parameters, but need an object
        var p = new
        {
            Id = id
        };

        _sqlConnector.LoadData<string, dynamic>("DeleteHierarchy2", p);
    }

    public void DeleteHierarchy1Category(int id)
    {
        // Anonymous object, object with no name type
        // No parameters, but need an object
        var p = new
        {
            Id = id
        };

        _sqlConnector.LoadData<string, dynamic>("DeleteHierarchy1", p);
    }

    public void EditHierarchy1Category(int id, string updatedHierarchy1Name)
    {
        var p = new
        {
            Id = id,
            Hierarchy1Name = updatedHierarchy1Name
        };

        _sqlConnector.LoadData<string, dynamic>("EditHierarchy1", p);
    }

    public void EditHierarchy2Category(int id, string updatedHierarchy2Name)
    {
        var p = new
        {
            Id = id,
            Hierarchy2Name = updatedHierarchy2Name
        };

        _sqlConnector.LoadData<string, dynamic>("EditHierarchy2", p);
    }

    public List<Hierarchy1> GetHierarchy1Category()
    {
        var p = new
        {
            TableName = "HIERARCHY_1",
            TableColumn = "Hierarchy1Name"
        };

        return _sqlConnector.LoadData<Hierarchy1, dynamic>("GetCategory", p);
    }
}
