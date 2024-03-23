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
                SqlDataReader dataReader = command.ExecuteReader();
                if (dataReader != null)
                {
                    while (dataReader.Read())
                    {
                        foreach (T parameter in parameters)
                        {
                            
                        }
                        T.Id = Convert.ToInt32(dataReader["ObjectId"]);
                        tagObject.SfiNumber = Convert.ToInt32(dataReader["SfiNumber"]);
                        tagObject.MainEqNumber = dataReader["MainEqNumber"].ToString();
                        tagObject.EqNumber = dataReader["EqNumber"].ToString();
                        tagObject.ObjectDescription = dataReader["ObjectDescription"].ToString();
                        tagObject.Hierarchy_1 = dataReader["Hierarchy1Name"].ToString();
                        tagObject.Hierarchy_2 = dataReader["Hierarchy2Name"].ToString();
                        tagObject.VduGroup = dataReader["VduGroupName"].ToString();
                        tagObject.AlarmGroup = dataReader["AlarmGroupName"].ToString();
                        tagObject.Otd = dataReader["OtdName"].ToString();
                        tagObject.AcknowledgeAllowed = dataReader["AcknowledgeAllowedLocation"].ToString();
                        tagObject.AlwaysVisible = dataReader["AlwaysVisibleLocation"].ToString();
                        tagObject.Node = dataReader["NodeName"].ToString();
                        tagObject.Cabinet = dataReader["CabinetName"].ToString();
                        tagObject.DataBlock = dataReader["DataBlockName"].ToString();
                    }
                }
                connection.Close();
            }
        }
    }
}
