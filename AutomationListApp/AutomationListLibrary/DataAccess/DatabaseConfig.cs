using System.Configuration;

namespace AutomationSystem.Models.DataAccess;

public static class DatabaseConfig
{
    public static string GetConnectionString()
    {
        return ConfigurationManager.ConnectionStrings["AUTOMATIONSYSTEM"].ConnectionString;
    }
}
