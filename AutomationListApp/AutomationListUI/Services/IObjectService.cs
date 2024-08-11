using AutomationListUI.Models;

namespace AutomationListUI.Services;

public interface IObjectService
{
	Task<List<DisplayObjectModel>> GetObjectsAsync();
	Task<DisplayObjectModel> GetObjectByIdAsync(int id);
	Task UpdateObjectAsync(DisplayObjectModel displayObject);
	Task DeleteObjectAsync(int id);
	Task InsertObjectAsync(DisplayObjectModel displayObject);
	Task<int> GetLastInsertedObjectId();
}