using Dapper;
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

    public List<T> ReadData<T, U>(string storedProcedure, U parameters)
    {
        using IDbConnection connection = new SqlConnection(_connectionString);
        // Queries rows of type T into a list of T
        List<T> rows = connection.Query<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure).ToList();
        return rows;
    }

    public void WriteData<T>(string storedProcedure, T parameters)
    {
        using (IDbConnection connection = new SqlConnection(_connectionString))
        {
            connection.Execute(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
