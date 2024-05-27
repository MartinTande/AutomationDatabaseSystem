
namespace AutomationSystem.Models.DataAccess
{
    public interface IDataConnector
    {
        List<T> ReadData<T, U>(string storedProcedure, U parameters);
        void WriteData<T>(string storedProcedure, T parameters);
    }
}