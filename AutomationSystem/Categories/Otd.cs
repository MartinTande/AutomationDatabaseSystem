using AutomationSystem.Classes;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSystem.Categories
{
    public class Otd : ICategory<Otd>
    {
        string connectionString = DatabaseAccess.GetConnectionString();
        public int Id { get; set; }
        public string? Name { get; set; }

        public List<string> GetNames()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                List<string> otdList = new List<string>();

                connection.Open();

                string sqlQuery = "select OtdId, Otd from OTD order by Otd";
                SqlCommand command = new SqlCommand(sqlQuery, connection);

                SqlDataReader dataReader = command.ExecuteReader();

                if (dataReader != null)
                {
                    while (dataReader.Read())
                    {
                        Otd otd = new Otd();

                        otd.Id = Convert.ToInt32(dataReader["OtdId"]);
                        otd.Name = dataReader["Otd"].ToString();

                        otdList.Add(otd.Name);
                    }
                }

                connection.Close();
                return otdList;
            }

        }

        public List<string> GetNames(string category)
        {
            throw new NotImplementedException();
        }

        public List<Otd> GetTypes()
        {
            List<Otd> otdList = new List<Otd>();

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string sqlQuery = "select OtdId, Otd from OTD order by Otd";
            SqlCommand command = new SqlCommand(sqlQuery, connection);

            SqlDataReader dataReader = command.ExecuteReader();

            if (dataReader != null)
            {
                while (dataReader.Read())
                {
                    Otd otd = new Otd();

                    otd.Id = Convert.ToInt32(dataReader["OtdId"]);
                    otd.Name = dataReader["Otd"].ToString();

                    otdList.Add(otd);
                }
            }

            connection.Close();
            return otdList;
        }
    }
}
