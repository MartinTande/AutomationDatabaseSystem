using AutomationSystem.Classes;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSystem.Categories
{
    public class Node : ICategory<Node>
    {
        string connectionString = DatabaseAccess.GetConnectionString();
        public int Id { get; set; }
        public string? Name { get; set; }

        public List<string> GetNames()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                List<string> nodeNameList = new List<string>();

                connection.Open();

                string sqlQuery = "select NodeId, NodeName from NODE order by NodeName";
                SqlCommand command = new SqlCommand(sqlQuery, connection);

                SqlDataReader dataReader = command.ExecuteReader();

                if (dataReader != null)
                {
                    while (dataReader.Read())
                    {
                        Node node = new Node();

                        node.Id = Convert.ToInt16(dataReader["NodeId"]);
                        node.Name = dataReader["NodeName"].ToString();

                        nodeNameList.Add(node.Name);
                    }
                }

                connection.Close();
                return nodeNameList;
            }
        }

        public List<string> GetNames(string category)
        {
            throw new NotImplementedException();
        }
    }
}
