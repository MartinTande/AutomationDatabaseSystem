using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSystem.Classes
{
    public class Otd
    {
        string connectionString = DatabaseAccess.GetConnectionString();
        public int OtdId { get; set; }
        public string? OtdName { get; set; }

        public List<Otd> GetOTDs()
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

                    otd.OtdId = Convert.ToInt32(dataReader["OtdId"]);
                    otd.OtdName = dataReader["Otd"].ToString();

                    otdList.Add(otd);
                }
            }

            connection.Close();
            return otdList;
        }
    }
}
