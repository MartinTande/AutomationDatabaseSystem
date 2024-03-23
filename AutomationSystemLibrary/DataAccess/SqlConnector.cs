using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace AutomationSystemLibrary.DataAccess
{
    public class SqlConnector
    {
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["AUTOMATIONSYSTEM"].ConnectionString;
        }
        public void SaveData<T>(string storedProcedure, T parameters) where T : IEnumerable<T>
        {
            string connectionString = GetConnectionString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(storedProcedure, connection);
                command.CommandType = CommandType.StoredProcedure;

                foreach(T parameter in parameters)
                {
                    command.Parameters.Add(new SqlParameter($"@{parameter}", parameter));

                }

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public List<T> LoadData<T, U>(string storedProcedure, U parameters) where U : IEnumerable<T>
        {
            string connectionString = GetConnectionString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(storedProcedure, connection);
                command.CommandType = CommandType.StoredProcedure;

                foreach (T parameter in parameters)
                {
                    command.Parameters.Add(new SqlParameter($"@{parameter}", parameter));
                }

                connection.Open();
                command.ExecuteReader();
                connection.Close();
                return 
            }
        }
    }
}
