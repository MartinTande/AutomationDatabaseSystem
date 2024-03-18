using AutomationSystem.Classes;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSystem.Categories
{
    public class Hierarchy1 : Category
    {
        string connectionString = DatabaseAccess.GetConnectionString();
        public int Id { get; set; }
        public string? Name { get; set; }

        public List<string> GetNames()
        {
            return base.GetNames("select Hierarchy1Name from HIERARCHY_1");
            //List<string> hierarchy1NameList = new List<string>();

            //SqlConnection connection = new SqlConnection(connectionString);
            //connection.Open();

            //string sqlQuery = "select Hierarchy1Id, Hierarchy1Name from HIERARCHY_1 order by Hierarchy1";
            //SqlCommand command = new SqlCommand(sqlQuery, connection);

            //SqlDataReader dataReader = command.ExecuteReader();

            //if (dataReader != null)
            //{
            //    while (dataReader.Read())
            //    {
            //        Hierarchy1 hierarchy1 = new Hierarchy1();

            //        hierarchy1.Id = Convert.ToInt32(dataReader["Hierarchy1Id"]);
            //        hierarchy1.Name = dataReader["Hierarchy1Name"].ToString();

            //        hierarchy1NameList.Add(hierarchy1.Name);
            //    }
            //}

            //connection.Close();
            //return hierarchy1NameList;
        }
    }
}
