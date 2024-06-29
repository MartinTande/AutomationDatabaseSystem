using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace AutomationListLibrary.DataAccess;

public class SqlConnector : ISqlConnector
{
    private readonly IConfiguration _configuration;

    public string ConnectionStringName { get; set; } = "Default";

    public SqlConnector(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<List<T>> ReadDataAsync<T, U>(string storedProcedure, U parameters)
    {
        string connectionString = _configuration.GetConnectionString(ConnectionStringName);

        using (IDbConnection connection = new SqlConnection(connectionString))
        {
            // Queries rows of type T into a list of T
            IEnumerable<T> rows = await connection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);

            return rows.ToList();
        }
    }

    public async Task WriteDataAsync<T>(string storedProcedure, T parameters)
    {
        string connectionString = _configuration.GetConnectionString(ConnectionStringName);

        using (IDbConnection connection = new SqlConnection(connectionString))
        {
            await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
