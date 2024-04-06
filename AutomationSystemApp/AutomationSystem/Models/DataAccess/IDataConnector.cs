
namespace AutomationSystem.Models.DataAccess
{
    public interface IDataConnector
    {
        List<ICategory> GetCategoryValues<T>(string columnName, string tableName, T category) where T : ICategory;
        List<T> LoadData<T, U>(string storedProcedure, U parameters);
        void SaveData<T>(string storedProcedure, T parameters);
    }
}