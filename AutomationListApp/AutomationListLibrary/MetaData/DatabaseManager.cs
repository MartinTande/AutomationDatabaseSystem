using Microsoft.Data.SqlClient;
using AutomationListLibrary.DataAccess;
using Microsoft.Extensions.Configuration;
using AutomationListLibrary.Data;


namespace AutomationListLibrary.MetaData;

public class DatabaseManager
{
    IConfiguration _configuration;
    private readonly ISqlConnector _sqlConnector;
    private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder;
    private readonly string _metaDataConnStringName = "MetaData";
    private readonly string _defaultConnStringName = "Default";

    public DatabaseManager(IConfiguration configuration, ISqlConnector sqlConnector, SqlConnectionStringBuilder sqlConnectionStringBuilder)
    {
        _configuration = configuration;
        _sqlConnector = sqlConnector;
        _sqlConnectionStringBuilder = sqlConnectionStringBuilder;
    }

    public async Task<List<Database>> GetAllDatabases()
    {
        var p = new { };

        return await _sqlConnector.ReadDataAsync<Database, dynamic>("GetAllDatabases", p, _metaDataConnStringName);
    }

    public async Task<List<Database>> GetByDatabaseId(int id)
    {
        var p = new
        {
            Id = id
        };

        return await _sqlConnector.ReadDataAsync<Database, dynamic>("GetDatabaseById", p, _metaDataConnStringName);
    }

    public async Task DeleteDatabase(int id)
    {
        var p = new
        {
            Id = id
        };

        await _sqlConnector.ReadDataAsync<string, dynamic>("DeleteDatabase", p, _metaDataConnStringName);
    }
    public async Task Update(int id, string updatedName)
    {
        var p = new
        {
            Id = id,
            Name = updatedName
        };

        await _sqlConnector.WriteDataAsync("EditCategoryItem", p, _metaDataConnStringName);
    }
    public async Task CreateDatabase(string name)
    {
        var p = new
        {
            Name = name
        };

        await _sqlConnector.WriteDataAsync("CreateDatabase", p, _metaDataConnStringName);
    }

    public void UpdateConncectionString(string databaseName)
    {
        string connectionString = _configuration.GetConnectionString(_defaultConnStringName);
        _sqlConnectionStringBuilder.ConnectionString = connectionString;
        _sqlConnectionStringBuilder.InitialCatalog = databaseName;

        string test = _sqlConnectionStringBuilder.ConnectionString;
        _configuration["ConnectionStrings:Default"] = test;
    }
}
