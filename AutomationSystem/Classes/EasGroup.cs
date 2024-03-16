using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSystem.Classes
{
    public class EasGroup
    {
        string connectionString = DatabaseAccess.GetConnectionString();
        public int EasGroupId { get; set; }
        public string? EasGroupName { get; set; }

        public List<EasGroup> GetEasGroups()
        {
            List<EasGroup> easGroupList = new List<EasGroup>();

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string sqlQuery = "select EasGroupId, EasGroup from EAS_GROUP order by EasGroup";
            SqlCommand command = new SqlCommand(sqlQuery, connection);

            SqlDataReader dataReader = command.ExecuteReader();

            if (dataReader != null)
            {
                while (dataReader.Read())
                {
                    EasGroup easGroup = new EasGroup();

                    easGroup.EasGroupId = Convert.ToInt32(dataReader["EasGroupId"]);
                    easGroup.EasGroupName = dataReader["EasGroup"].ToString();

                    easGroupList.Add(easGroup);
                }
            }

            connection.Close();
            return easGroupList;
        }
    }
}
