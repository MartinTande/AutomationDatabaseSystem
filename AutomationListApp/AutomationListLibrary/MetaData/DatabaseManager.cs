using Microsoft.Data.SqlClient;


using AutomationListLibrary.DataAccess;

namespace AutomationListLibrary.MetaData;

public class DatabaseManager
{
    private readonly ISqlConnector _sqlConnector;
    private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder;

    public DatabaseManager(ISqlConnector sqlConnector, SqlConnectionStringBuilder sqlConnectionStringBuilder)
    {
        _sqlConnector = sqlConnector;
        _sqlConnectionStringBuilder = sqlConnectionStringBuilder;
    }

    public async Task<List<Database>> GetAll<Database>()
    {
        var p = new { };

        return await _sqlConnector.ReadDataAsync<Database, dynamic>("GetAllDatabases", p);
    }

    public async Task<List<Database>> GetById<Database>(int id)
    {
        var p = new
        {
            Id = id
        };

        return await _sqlConnector.ReadDataAsync<Database, dynamic>("GetDatabaseById", p);
    }

    public async Task Delete(int id)
    {
        var p = new
        {
            Id = id
        };

        await _sqlConnector.ReadDataAsync<string, dynamic>("DeleteDatabase", p);
    }
    public async Task Update(int id, string updatedName)
    {
        var p = new
        {
            Id = id,
            Name = updatedName
        };

        await _sqlConnector.WriteDataAsync("EditCategoryItem", p);
    }
    public async Task CreateDatabase(string name)
    {
        var p = new
        {
            Name = name
        };

        await _sqlConnector.WriteDataAsync("CreateDatabase", p);
    }

    public void UpdateConncectionString(string databaseName)
    {
        _sqlConnectionStringBuilder.
    }
}
