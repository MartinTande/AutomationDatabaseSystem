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
}
