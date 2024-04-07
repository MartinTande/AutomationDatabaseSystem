using AutomationSystem.Models;
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
            TableName = "NODE",
            TableColumn = "NodeName"
        };

        return _sqlConnector.LoadData<Node, dynamic>("GetCategory", p);
    }

    public List<AcknowledgeAllowed> GetAckAllowedCategory()
    {
        var p = new
        {
            TableName = "ACKNOWLEDGE_ALLOWED",
            TableColumn = "AcknowledgeAllowedName"
        };

        return _sqlConnector.LoadData<AcknowledgeAllowed, dynamic>("GetCategory", p);
    }

    public List<AlwaysVisible> GetAlwaysVisibleCategory()
    {
        var p = new
        {
            TableName = "ALWAYS_VISIBLE",
            TableColumn = "AlwaysVisibleName"
        };

        return _sqlConnector.LoadData<AlwaysVisible, dynamic>("GetCategory", p);
    }

    public List<Cabinet> GetCabinetCategory()
    {
        var p = new
        {
            TableName = "CABINET",
            TableColumn = "CabinetName"
        };

        return _sqlConnector.LoadData<Cabinet, dynamic>("GetCategory", p);
    }

    public List<Otd> GetOtdCategory()
    {
        var p = new
        {
            TableName = "OTD",
            TableColumn = "OtdName"
        };

        return _sqlConnector.LoadData<Otd, dynamic>("GetCategory", p);
    }

    public List<VduGroup> GetVduGroupCategory()
    {
        var p = new
        {
            TableName = "VDU_GROUP",
            TableColumn = "VduGroupName"
        };

        return _sqlConnector.LoadData<VduGroup, dynamic>("GetCategory", p);
    }

    public List<AlarmGroup> GetAlarmGroupCategory()
    {
        var p = new
        {
            TableName = "ALARM_GROUP",
            TableColumn = "AlarmGroupName"
        };

        return _sqlConnector.LoadData<AlarmGroup, dynamic>("GetCategory", p);
    }
}
