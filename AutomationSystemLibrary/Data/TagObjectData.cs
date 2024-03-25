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
    internal class TagObjectData
    {
        SqlConnector sqlConnector;
        public TagObjectData()
        { 
            sqlConnector = new SqlConnector();
        }

        public List<TagObjectModel> GetTagObjects()
        {
            List<TagObjectModel> list = new List<TagObjectModel>();
            var parameters = new { };
            list = sqlConnector.LoadData<TagObjectModel, dynamic>("GetAllObjects", parameters);
            return list;
        }
        public TagObjectModel GetTagObject(int Id)
        {
            return GetTagObjects()[Id];
        }
        public void InsertTagObject(TagObjectModel newTagObject)
        {
            var parameters = new { 
                newTagObject.SfiNumber, 
                newTagObject.MainEqNumber,
                newTagObject.EqNumber,
                newTagObject.ObjectDescription,
                newTagObject.Hierarchy_1,
                newTagObject.Hierarchy_2,
                newTagObject.VduGroup,
                newTagObject.AlarmGroup,
                newTagObject.Otd,
                newTagObject.AcknowledgeAllowed,
                newTagObject.AlwaysVisible,
                newTagObject.Node,
                newTagObject.Cabinet,
                newTagObject.DataBlock,
            };

            sqlConnector.SaveData<TagObjectModel, dynamic>("GetAllObjects", parameters);
        }
    }
}
