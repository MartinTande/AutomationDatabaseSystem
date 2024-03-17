using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSystem.Classes
{
    public class Hierarchy1 : ICategory<Hierarchy1>
    {
        string connectionString = DatabaseAccess.GetConnectionString();
        public int Id { get; set; }
        public string? Name { get; set; }

        public List<string> GetNames()
        {
            List<string> hierarchy1List = new List<string>();

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

                    hierarchy1.Id = Convert.ToInt32(dataReader["Hierarchy1Id"]);
                    hierarchy1.Name = dataReader["Hierarchy1"].ToString();

                    hierarchy1List.Add(hierarchy1.Name);
                }
            }

            connection.Close();
            return hierarchy1List;
        }

        public List<string> GetNames(string category)
        {
            throw new NotImplementedException();
        }

        public List<Hierarchy1> GetTypes()
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

                    hierarchy1.Id = Convert.ToInt32(dataReader["Hierarchy1Id"]);
                    hierarchy1.Name = dataReader["Hierarchy1"].ToString();

                    hierarchy1List.Add(hierarchy1);
                }
            }

            connection.Close();
            return hierarchy1List;
        }
    }
}
