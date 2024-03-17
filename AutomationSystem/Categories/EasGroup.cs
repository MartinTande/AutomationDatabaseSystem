using AutomationSystem.Classes;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSystem.Categories
{
    public class EasGroup : ICategory<EasGroup>
    {
        string connectionString = DatabaseAccess.GetConnectionString();
        public int Id { get; set; }
        public string? Name { get; set; }

        public List<string> GetNames()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                List<string> easGroupList = new List<string>();
                string sqlQuery = "select EasGroupId, EasGroup from EAS_GROUP order by EasGroup";
                SqlCommand command = new SqlCommand(sqlQuery, connection);

                connection.Open();
                SqlDataReader dataReader = command.ExecuteReader();

                if (dataReader != null)
                {
                    while (dataReader.Read())
                    {
                        EasGroup easGroup = new EasGroup();

                        easGroup.Id = Convert.ToInt32(dataReader["EasGroupId"]);
                        easGroup.Name = dataReader["EasGroup"].ToString();

                        easGroupList.Add(easGroup.Name);
                    }
                }

                connection.Close();
                return easGroupList;
            }
        }

        public List<string> GetNames(string category)
        {
            throw new NotImplementedException();
        }

        public List<EasGroup> GetTypes()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                List<EasGroup> easGroupList = new List<EasGroup>();
                string sqlQuery = "select EasGroupId, EasGroup from EAS_GROUP order by EasGroup";
                SqlCommand command = new SqlCommand(sqlQuery, connection);

                connection.Open();
                SqlDataReader dataReader = command.ExecuteReader();

                if (dataReader != null)
                {
                    while (dataReader.Read())
                    {
                        EasGroup easGroup = new EasGroup();

                        easGroup.Id = Convert.ToInt32(dataReader["EasGroupId"]);
                        easGroup.Name = dataReader["EasGroup"].ToString();

                        easGroupList.Add(easGroup);
                    }
                }

                connection.Close();
                return easGroupList;
            }
        }
    }
}
