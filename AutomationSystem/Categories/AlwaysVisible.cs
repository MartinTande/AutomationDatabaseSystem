using AutomationSystem.Classes;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSystem.Categories
{
    public class AlwaysVisible : ICategory<AlwaysVisible>
    {
        string connectionString = DatabaseAccess.GetConnectionString();
        public int Id { get; set; }
        public string? Location { get; set; }

        public List<string> GetNames()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                List<string> alwaysVisibleLocationList = new List<string>();

                connection.Open();

                string sqlQuery = "select AlwaysVisibleId, AlwaysVisibleLocation from ALWAYS_VISIBLE order by AlwaysVisibleLocation";
                SqlCommand command = new SqlCommand(sqlQuery, connection);

                SqlDataReader dataReader = command.ExecuteReader();

                if (dataReader != null)
                {
                    while (dataReader.Read())
                    {
                        AlwaysVisible alwaysVisible = new AlwaysVisible();

                        alwaysVisible.Id = Convert.ToInt32(dataReader["AlwaysVisibleId"]);
                        alwaysVisible.Location = dataReader["AlwaysVisibleLocation"].ToString();

                        alwaysVisibleLocationList.Add(alwaysVisible.Location);
                    }
                }

                connection.Close();
                return alwaysVisibleLocationList;
            }
        }

        public List<string> GetNames(string category)
        {
            throw new NotImplementedException();
        }
    }
}
