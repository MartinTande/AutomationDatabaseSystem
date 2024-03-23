using AutomationSystemLibrary;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace AutomationSystem.Categories
{
    public abstract class Category
    {
        string connectionString = GlobalConfig.GetConnectionString();

        public List<string> GetNames(string columnName, string tableName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                List<string> nameList = new List<string>();

                SqlCommand command = new SqlCommand($"select {columnName} from {tableName}", connection);

                connection.Open();
                SqlDataReader dataReader = command.ExecuteReader();

                if (dataReader != null)
                {
                    while (dataReader.Read())
                    {
                        string _name = dataReader[columnName].ToString();

                        nameList.Add(_name);
                    }
                }

                connection.Close();
                return nameList;
            }
        }
    }
}
