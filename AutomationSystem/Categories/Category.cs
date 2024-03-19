using AutomationSystem.Classes;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSystem.Categories
{
    public abstract class Category
    {
        string connectionString = DatabaseAccess.GetConnectionString();

        public List<string> GetNames(string sqlQuery)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                List<string> nameList = new List<string>();

                SqlCommand command = new SqlCommand(sqlQuery, connection);

                connection.Open();
                SqlDataReader dataReader = command.ExecuteReader();

                if (dataReader != null)
                {
                    while (dataReader.Read())
                    {
                        string _name = dataReader.ToString();

                        nameList.Add(_name);
                    }
                }

                connection.Close();
                return nameList;
            }
        }
    }
}
