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
    public class Hierarchy2 : ICategory<Hierarchy2>
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

                command.Parameters.Add(new SqlParameter("@Hierarchy1Name", hierarchy1));

                SqlDataReader dataReader = command.ExecuteReader();

                if (dataReader != null)
                {
                    while (dataReader.Read())
                    {
                        Hierarchy2 hierarchy2 = new Hierarchy2();
                        hierarchy2.Name = dataReader["Hierarchy2Name"].ToString();

                        hierarchy2NameList.Add(hierarchy2.Name);
                    }
                }

                connection.Close();
                return hierarchy2NameList;
            }
        }

    }
}
