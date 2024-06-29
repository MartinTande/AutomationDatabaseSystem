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

    public async Task<IEnumerable<T>> ReadDataAsync<T, U>(string storedProcedure, U parameters)
    {
        using IDbConnection connection = new SqlConnection(_connectionString);
        // Queries rows of type T into a list of T
        IEnumerable<T> rows = await connection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);

        return rows;
    }

    public async Task WriteDataAsync<T>(string storedProcedure, T parameters)
    {
        using IDbConnection connection = new SqlConnection(_connectionString);
        
        await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
    }
}
