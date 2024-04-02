using AutomationSystemLibrary.DataAccess;
using AutomationSystemLibrary.Models;
using System;
using System.Collections.Generic;

namespace AutomationSystemLibrary.Data
{
    public class ObjectDataManager
    {
        private readonly SqlConnector _sqlConnector;
        public ObjectDataManager()
        {
            _sqlConnector = new SqlConnector();
        }
        public List<TagObjectModel> GetTagObjectById(int id)
        {
            // Anonymous object, object with no name type
            // Id is parameter of object, id is input to that parameter
            var p = new { ObjectId = id };

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
            var p = new 
            { 
                tagObject.SfiNumber,
                tagObject.MainEqNumber,
                tagObject.EqNumber,
                tagObject.ObjectDescription,
                tagObject.Hierarchy1Name,
                tagObject.Hierarchy2Name,
                tagObject.VduGroupName,
                tagObject.AlarmGroupName,
                tagObject.OtdName,
                tagObject.AcknowledgeAllowedLocation,
                tagObject.AlwaysVisibleLocation,
                tagObject.NodeName,
                tagObject.CabinetName,
                tagObject.DataBlockName
            };

            _sqlConnector.SaveData("CreateObject", p);
        }

        public void UpdateTagObject(TagObjectModel tagObject)
        {
           // Anonymous object, object with no name type
           var p = new
           {
               tagObject.ObjectId,
               tagObject.SfiNumber,
               tagObject.MainEqNumber,
               tagObject.EqNumber,
               tagObject.ObjectDescription,
               tagObject.Hierarchy1Name,
               tagObject.Hierarchy2Name,
               tagObject.VduGroupName,
               tagObject.AlarmGroupName,
               tagObject.OtdName,
               tagObject.AcknowledgeAllowedLocation,
               tagObject.AlwaysVisibleLocation,
               tagObject.NodeName,
               tagObject.CabinetName,
               tagObject.DataBlockName
           };
            Console.WriteLine(tagObject.ObjectDescription);
            Console.WriteLine(tagObject.ObjectId);
            try
            {
                _sqlConnector.SaveData("UpdateObject", p);
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public void DeleteTagObject(int id)
        {
            // Anonymous object, object with no name type
            // Id is parameter of object, id is input to that parameter
            var p = new { ObjectId = id };

            _sqlConnector.SaveData("DeleteObject", p);
        }

    }
}
