using AutomationSystem.Categories;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;


namespace AutomationSystemLibrary.DataAccess
{
    internal class SqlConnector
    {
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["AUTOMATIONSYSTEM"].ConnectionString;
        }

        public List<T> LoadData<T, U>(string storedProcedure, U parameters)
        {
            string connectionString = GetConnectionString();

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                // Queries rows of type T into a list of T
                List<T> rows = connection.Query<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure).ToList();
                return rows;
            }
        }

        public void SaveData<T>(string storedProcedure, T parameters)
        {
            string connectionString = GetConnectionString();

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Execute(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        
        public List<ICategory> GetCategoryValues<T>(string columnName, string tableName, T category) where T : ICategory
        {
            string connectionString = GetConnectionString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                List<ICategory> categoryList = new List<ICategory>();
                List<string> categoryValuesList = new List<string>();

                SqlCommand command = new SqlCommand($"select {columnName} from {tableName}", connection);

                connection.Open();
                SqlDataReader dataReader = command.ExecuteReader();

                if (dataReader != null)
                {
                    while (dataReader.Read())
                    {
                        string _name = dataReader[columnName].ToString();
                        category.Name = dataReader[columnName].ToString();
                        category.Id = Convert.ToInt32(dataReader["Id"]);
                        categoryList.Add(category);

                        categoryValuesList.Add(_name);
                    }
                }

                connection.Close();
                return categoryList;
            }
        }
    }
}
