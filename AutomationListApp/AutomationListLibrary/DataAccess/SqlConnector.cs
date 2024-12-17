using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;

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
		#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
		string connectionString = _configuration.GetConnectionString(ConnectionStringName);

        using (IDbConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                // Queries rows of type T into a list of T
                IEnumerable<T> rows = await connection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);

                return rows.ToList();
            }
            catch (Exception ex)
            {
				Console.WriteLine(ex.ToString());
                return null;
			}
        }
    }

    public async Task WriteDataAsync<T>(string storedProcedure, T parameters)
    {
		#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
		string connectionString = _configuration.GetConnectionString(ConnectionStringName);

		using (IDbConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }

	#pragma warning disable CS8766 // Nullability of reference types in return type doesn't match implicitly implemented member (possibly because of nullability attributes).
	public List<T>? ReadData<T, U>(string storedProcedure, U parameters)
	{
		string connectionString = _configuration.GetConnectionString(ConnectionStringName);

		using (IDbConnection connection = new SqlConnection(connectionString))
		{
			try
			{
				// Queries rows of type T into a list of T
				IEnumerable<T> rows = connection.Query<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);

				return rows.ToList();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
				return null;
			}
		}
	}

	public void WriteData<T>(string storedProcedure, T parameters)
	{
		string connectionString = _configuration.GetConnectionString(ConnectionStringName);

		using (IDbConnection connection = new SqlConnection(connectionString))
		{
			try
			{
				connection.Execute(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
		}
	}
}
