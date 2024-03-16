using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSystem.Classes
{
    public class Hierarchy2
    {
        string connectionString = DatabaseAccess.GetConnectionString();
        public int Hierarchy2Id { get; set; }
        public string? Hierarchy2Name { get; set; }

        public List<Hierarchy2> GetHierarchy2Types()
        {
            List<Hierarchy2> hierarchy2List = new List<Hierarchy2>();

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string sqlQuery = "select Hierarchy2Id, Hierarchy2 from HIERARCHY_2 order by Hierarchy2";
            SqlCommand command = new SqlCommand(sqlQuery, connection);

            SqlDataReader dataReader = command.ExecuteReader();

            if (dataReader != null)
            {
                while (dataReader.Read())
                {
                    Hierarchy2 hierarchy2 = new Hierarchy2();

                    hierarchy2.Hierarchy2Id = Convert.ToInt32(dataReader["Hierarchy2Id"]);
                    hierarchy2.Hierarchy2Name = dataReader["Hierarchy2"].ToString();

                    hierarchy2List.Add(hierarchy2);
                }
            }

            connection.Close();
            return hierarchy2List;
        }
    }
}
