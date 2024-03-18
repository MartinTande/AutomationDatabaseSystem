using AutomationSystem.Classes;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSystem.Categories
{
    public class Otd : Category
    {
        string connectionString = DatabaseAccess.GetConnectionString();
        public int Id { get; set; }
        public string? Name { get; set; }

        public List<string> GetNames()
        {
            return base.GetNames("select OtdName from OTD");
            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    List<string> otdNameList = new List<string>();

            //    connection.Open();

            //    string sqlQuery = "select OtdId, OtdName from OTD order by OtdName";
            //    SqlCommand command = new SqlCommand(sqlQuery, connection);

            //    SqlDataReader dataReader = command.ExecuteReader();

            //    if (dataReader != null)
            //    {
            //        while (dataReader.Read())
            //        {
            //            Otd otd = new Otd();

            //            otd.Id = Convert.ToInt32(dataReader["OtdId"]);
            //            otd.Name = dataReader["OtdName"].ToString();

            //            otdNameList.Add(otd.Name);
            //        }
            //    }

            //    connection.Close();
            //    return otdNameList;
            //}

        }

        public List<string> GetNames(string category)
        {
            throw new NotImplementedException();
        }
    }
}
