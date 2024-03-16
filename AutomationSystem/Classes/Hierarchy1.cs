using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSystem.Classes
{
    public class Hierarchy1
    {
        string connectionString = DatabaseAccess.GetConnectionString();
        public int Hierarchy1Id { get; set; }
        public string? Hierarchy1Name { get; set; }

        public List<Hierarchy1> GetHierarchy1Types()
        {
            List<Hierarchy1> hierarchy1List = new List<Hierarchy1>();

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string sqlQuery = "select Hierarchy1Id, Hierarchy1 from HIERARCHY_1 order by Hierarchy1";
            SqlCommand command = new SqlCommand(sqlQuery, connection);

            SqlDataReader dataReader = command.ExecuteReader();

            if (dataReader != null)
            {
                while (dataReader.Read())
                {
                    Hierarchy1 hierarchy1 = new Hierarchy1();

                    hierarchy1.Hierarchy1Id = Convert.ToInt32(dataReader["Hierarchy1Id"]);
                    hierarchy1.Hierarchy1Name = dataReader["Hierarchy1"].ToString();

                    hierarchy1List.Add(hierarchy1);
                }
            }

            connection.Close();
            return hierarchy1List;
        }
    }
}
