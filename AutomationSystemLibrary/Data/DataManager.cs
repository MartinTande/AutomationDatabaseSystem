using AutomationSystemLibrary.DataAccess;
using AutomationSystemLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSystemLibrary.Data
{
    public class DataManager
    {
        private readonly SqlConnector _sqlConnector;
        public DataManager()
        {
            _sqlConnector = new SqlConnector();
        }
        public List<TagObjectModel> GetTagObjectById(int id)
        {
            // Anonymous object, object with no name type
            // Id is parameter of object, id is input to that parameter
            var p = new { Id = id };

            var tagObjectList = _sqlConnector.LoadData<TagObjectModel, dynamic>("GetObjectById", p);
            return tagObjectList;
        }

        public List<TagObjectModel> GetTagObjects()
        {
            // Anonymous object, object with no name type
            // No parameters, but need an object
            var p = new {  };

            List<TagObjectModel> tagObjectList = _sqlConnector.LoadData<TagObjectModel, dynamic>("GetAllObjects", p);
            return tagObjectList;
        }

        public void InsertTagObject(TagObjectModel tagObject)
        {
            // Anonymous object, object with no name type
            // No parameters, but need an object
            var p = new { 
                tagObject.SfiNumber,
                tagObject.MainEqNumber,
                tagObject.EqNumber,
                tagObject.ObjectDescription,
                tagObject.Hierarchy1Name,
                tagObject.Hierarchy2Name,
                tagObject.VduGroupName,
                tagObject.AlarmGroupName,
                tagObject.OtdName,
                tagObject.AlwaysVisibleLocation,
                tagObject.AcknowledgeAllowedLocation,
                tagObject.NodeName,
                tagObject.CabinetName,
                tagObject.DataBlockName
            };

            _sqlConnector.SaveData<TagObjectModel>("UpdateObject", tagObject);
        }
    }
}
