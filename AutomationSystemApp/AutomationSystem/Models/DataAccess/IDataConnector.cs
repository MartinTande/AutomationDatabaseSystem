
namespace AutomationSystem.Models.DataAccess
{
    public interface IDataConnector
    {
        List<T> LoadData<T, U>(string storedProcedure, U parameters);
        void SaveData<T>(string storedProcedure, T parameters);
    }
}