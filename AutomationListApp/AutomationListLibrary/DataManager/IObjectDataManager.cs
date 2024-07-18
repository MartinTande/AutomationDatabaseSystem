using AutomationListLibrary.Data;

namespace AutomationListLibrary.DataManager
{
	public interface IObjectDataManager
	{
		Task DeleteObject(int id);
		Task<int> GetLastInsertedObjectId();
		Task<ObjectModel?> GetObjectById(int id);
		Task<List<ObjectModel>> GetObjects();
		Task InsertObject(ObjectModel tagObject);
		Task UpdateObject(ObjectModel tagObject);
	}
}