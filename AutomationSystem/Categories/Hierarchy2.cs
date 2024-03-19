using AutomationSystem.Classes;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSystem.Categories
{
    public class Hierarchy2 : ISubCategory
    {
        string connectionString = DatabaseAccess.GetConnectionString();
        public int Id { get; set; }
        public string? Name { get; set; }

        public List<string> GetNames(string hierarchy1)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                List<string> hierarchy2NameList = new List<string>();

                connection.Open();
                SqlCommand command = new SqlCommand("GetHierarchy2Data", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@Hierarchy1Name", ""));

                SqlDataReader dataReader = command.ExecuteReader();

                if (dataReader != null)
                {
                    while (dataReader.Read())
                    {
                        this.Name = dataReader["Hierarchy2Name"].ToString();

                        hierarchy2NameList.Add(this.Name);
                    }
                }

                connection.Close();
                return hierarchy2NameList;
            }
        }

    }
}
