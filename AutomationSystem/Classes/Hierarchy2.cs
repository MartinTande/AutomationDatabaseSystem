using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSystem.Classes
{
    public class Hierarchy2
    {
        string connectionString = DatabaseAccess.GetConnectionString();
        public int Hierarchy2Id { get; set; }
        public string? Hierarchy2Name { get; set; }

        public List<Hierarchy2> GetHierarchy2Types(string hierarchy1)
        {
            List<Hierarchy2> hierarchy2List = new List<Hierarchy2>();

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command = new SqlCommand("GetHierarchy2Data", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Hierarchy1", hierarchy1));

            SqlDataReader dataReader = command.ExecuteReader();

            if (dataReader != null)
            {
                while (dataReader.Read())
                {
                    Hierarchy2 hierarchy2 = new Hierarchy2();
                    hierarchy2.Hierarchy2Name = dataReader["Hierarchy2"].ToString();

                    hierarchy2List.Add(hierarchy2);
                }
            }

            connection.Close();
            return hierarchy2List;
        }
    }
}
