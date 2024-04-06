using Dapper;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace AutomationSystem.Models.DataAccess;

public class SqlConnector : IDataConnector
{
    private readonly string _connectionString;

    public SqlConnector(string connectionString)
    {
        _connectionString = connectionString;
    }

    public List<T> LoadData<T, U>(string storedProcedure, U parameters)
    {
        using IDbConnection connection = new SqlConnection(_connectionString);
        // Queries rows of type T into a list of T
        List<T> rows = connection.Query<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure).ToList();
        return rows;
    }

    public void SaveData<T>(string storedProcedure, T parameters)
    {
        using (IDbConnection connection = new SqlConnection(_connectionString))
        {
            connection.Execute(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }
    }

    public List<ICategory> GetCategoryValues<T>(string columnName, string tableName, T category) where T : ICategory
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            List<ICategory> categoryList = new List<ICategory>();
            List<string?> categoryValuesList = new List<string?>();

            SqlCommand command = new SqlCommand($"select {columnName} from {tableName}", connection);

            connection.Open();
            SqlDataReader dataReader = command.ExecuteReader();

            if (dataReader != null)
            {
                while (dataReader.Read())
                {
                    string? _name = dataReader[columnName].ToString();
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
