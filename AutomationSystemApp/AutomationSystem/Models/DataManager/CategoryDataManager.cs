using AutomationSystem.Models.DataAccess;

namespace AutomationSystem.Models.DataManager;

public class CategoryDataManager
{
    private readonly IDataConnector _sqlConnector;

    public CategoryDataManager(IDataConnector sqlConnector)
    {
        _sqlConnector = sqlConnector;
    }

    public List<Node> GetNodeCategory()
    {
        var p = new
        {
            TableName = "NODE"
        };

        return _sqlConnector.LoadData<Node, dynamic>("GetCategory", p);
    }

    public List<AcknowledgeAllowed> GetAckAllowedCategory()
    {
        var p = new
        {
            TableName = "ACKNOWLEDGE_ALLOWED"
        };

        return _sqlConnector.LoadData<AcknowledgeAllowed, dynamic>("GetCategory", p);
    }

    public List<AlwaysVisible> GetAlwaysVisibleCategory()
    {
        var p = new
        {
            TableName = "ALWAYS_VISIBLE"
        };

        return _sqlConnector.LoadData<AlwaysVisible, dynamic>("GetCategory", p);
    }

    public List<Cabinet> GetCabinetCategory()
    {
        var p = new
        {
            TableName = "CABINET"
        };

        return _sqlConnector.LoadData<Cabinet, dynamic>("GetCategory", p);
    }

    public List<Otd> GetOtdCategory()
    {
        var p = new
        {
            TableName = "OTD"
        };

        return _sqlConnector.LoadData<Otd, dynamic>("GetCategory", p);
    }

    public List<VduGroup> GetVduGroupCategory()
    {
        var p = new
        {
            TableName = "VDU_GROUP"
        };

        return _sqlConnector.LoadData<VduGroup, dynamic>("GetCategory", p);
    }

    public List<AlarmGroup> GetAlarmGroupCategory()
    {
        var p = new
        {
            TableName = "ALARM_GROUP"
        };

        return _sqlConnector.LoadData<AlarmGroup, dynamic>("GetCategory", p);
    }

    public List<Hierarchy1> GetHierarchy1Category()
    {
        var p = new
        {
            TableName = "HIERARCHY_1"
        };

        return _sqlConnector.LoadData<Hierarchy1, dynamic>("GetCategory", p);
    }

    public List<IoType> GetIoType()
    {
        var p = new
        {
            TableName = "IO_TYPE"
        };

        return _sqlConnector.LoadData<IoType, dynamic>("GetCategory", p);
    }

    public List<string> GetCategoryNames(string tableName)
    {
        var p = new
        {
            TableName = tableName
        };

        return _sqlConnector.LoadData<string, dynamic>("GetCategoryNames", p);
    }

    public List<string> GetAlarmGroupNames()    { return GetCategoryNames("ALARM_GROUP"); }
    public List<string> GetNodeNames()    { return GetCategoryNames("NODE"); }
    public List<string> GetAlwaysVisibleNames()    { return GetCategoryNames("ALWAYS_VISIBLE"); }
    public List<string> GetAckowledgeAllowedNames()    { return GetCategoryNames("ACKNOWLEDGE_ALLOWED"); }
    public List<string> GetVduGroupNames()    { return GetCategoryNames("VDU_GROUP"); }
    public List<string> GetOtdNames()    { return GetCategoryNames("OTD"); }
    public List<string> GetCabinetNames()    { return GetCategoryNames("CABINET"); }
    public List<string> GetHierarchy1Names()    { return GetCategoryNames("HIERARCHY_1"); }
    public List<string> GetIoTypeNames()    { return GetCategoryNames("IO_TYPE"); }

    private void DeleteCategoryItem(string tableName, int id)
    {
        // Anonymous object, object with no name type
        // No parameters, but need an object
        var p = new
        {
            TableName = tableName,
            Id = id
        };

        _sqlConnector.LoadData<string, dynamic>("DeleteCategoryItem", p);
    }

    private void EditCategoryItem(string tableName, int id, string updatedName)
    {
        var p = new
        {
            TableName = tableName,
            Id = id,
            Name = updatedName
        };

        _sqlConnector.LoadData<string, dynamic>("EditCategoryItem", p);
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

        _sqlConnector.LoadData<string, dynamic>("AddCategoryItem", p);
    }

    public void DeleteHierarchy1Category(int id)    { DeleteCategoryItem("HIERARCHY_1", id); }
    
    public void EditHierarchy1Category(int id, string updatedHierarchy1Name)    {  EditCategoryItem("HIERARCHY_1", id, updatedHierarchy1Name);  }

    public void AddHierarchy1Category(string hierarchy1Name)    { AddCategoryItem("HIERARCHY_1", hierarchy1Name); }
}
