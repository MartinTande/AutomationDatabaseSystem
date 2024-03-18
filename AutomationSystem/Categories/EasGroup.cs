using AutomationSystem.Classes;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSystem.Categories
{
    public class EasGroup : Category
    {
        string connectionString = DatabaseAccess.GetConnectionString();
        public int Id { get; set; }
        public string? Name { get; set; }

        public List<string> GetNames()
        {
            return base.GetNames("select EasGroupName from EAS_GROUP");
            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    List<string> easGroupNameList = new List<string>();

            //    string sqlQuery = "select EasGroupId, EasGroupName from EAS_GROUP order by EasGroupName";
            //    SqlCommand command = new SqlCommand(sqlQuery, connection);

            //    connection.Open();
            //    SqlDataReader dataReader = command.ExecuteReader();

            //    if (dataReader != null)
            //    {
            //        while (dataReader.Read())
            //        {
            //            EasGroup easGroup = new EasGroup();

            //            easGroup.Id = Convert.ToInt32(dataReader["EasGroupId"]);
            //            easGroup.Name = dataReader["EasGroupName"].ToString();

            //            easGroupNameList.Add(easGroup.Name);
            //        }
            //    }

            //    connection.Close();
            //    return easGroupNameList;
            //}
        }

    }
}
