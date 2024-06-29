
namespace AutomationSystem.Models.DataAccess
{
    public interface IDataConnector
    {
        Task<IEnumerable<T>> ReadDataAsync<T, U>(string storedProcedure, U parameters);
        Task WriteDataAsync<T>(string storedProcedure, T parameters);
    }
}