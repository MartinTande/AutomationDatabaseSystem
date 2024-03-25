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
    public class TagObjectData
    {
        public List<TagObjectModel> GetTagObjectById(int id)
        {
            SqlConnector sqlConnector = new SqlConnector();

            // Anonymous object, object with no name type
            // Id is parameter of object, id is input to that parameter
            var p = new { Id = id };

            var tagObjectList = sqlConnector.LoadData<TagObjectModel, dynamic>("GetObjectById", p);
            return tagObjectList;
        }

        public List<TagObjectModel> GetTagObject(int id)
        {
            SqlConnector sqlConnector = new SqlConnector();

            // Anonymous object, object with no name type
            // Id is parameter of object, id is input to that parameter
            var p = new {  };

            var tagObjectList = sqlConnector.LoadData<TagObjectModel, dynamic>("GetObjectById", p);
            return tagObjectList;
        }
    }
}
