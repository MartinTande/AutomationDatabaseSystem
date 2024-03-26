using AutomationSystem.Categories;
using AutomationSystemLibrary.Categories;
using AutomationSystemLibrary.DataAccess;
using AutomationSystemLibrary.Models;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace AutomationSystemLibrary.Data
{
    public class CategoryDataManager
    {
        private readonly SqlConnector _sqlConnector;
        public CategoryDataManager()
        {
            _sqlConnector = new SqlConnector();
        }

        private List<string> GetCategory(string tableName, string tableColumn)
        {
            // Anonymous object, object with no name type
            // No parameters, but need an object
            var p = new { TableName = tableName, TableColumn = tableColumn };

            List<string> category = _sqlConnector.LoadData<string, dynamic>("GetCategory", p);
            return category;
        }

        public List<string> GetHierarchy1Category()
        {
            return GetCategory("HIERARCHY_1", "Hierarchy1Name");
        }

        public List<string> GetNodeCategory()
        {
            return GetCategory("NODE", "NodeName");
        }

        public List<string> GetAckAllowedCategory()
        {
            return GetCategory("ACKNOWLEDGE_ALLOWED", "AcknowledgeAllowedLocation");
        }

        public List<string> GetAlwaysVisibleCategory()
        {
            return GetCategory("ALWAYS_VISIBLE", "AlwaysVisibleLocation");
        }

        public List<string> GetCabinetCategory()
        {
            return GetCategory("CABINET", "CabinetName");
        }

        public List<string> GetOtdCategory()
        {
            return GetCategory("OTD", "OtdName");
        }

        public List<string> GetVduGroupCategory()
        {
            return GetCategory("VDU_GROUP", "VduGroupName");
        }

        public List<string> GetAlarmGroupCategory()
        {
            return GetCategory("ALARM_GROUP", "AlarmGroupName");
        }

        public List<string> GetHierarchy2CategoryNames(int id) 
        {
            // Anonymous object, object with no name type
            // No parameters, but need an object
            var p = new { Id = id };

            List<string> category = _sqlConnector.LoadData<string, dynamic>("GetHierarchy2Data", p);
            return category;
        }
    }
}
