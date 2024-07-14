using AutomationListUI.Models;

namespace AutomationListUI.Services
{
	public interface IObjectService
	{
		Task<List<DisplayObjectModel>> GetObjectsAsync();
		Task UpdateObjectAsync(DisplayObjectModel displayObject);
		Task DeleteObjectAsync(int id);
		Task InsertObjectAsync(DisplayObjectModel displayObject);
		List<DisplayObjectModel> GetObjects();
	}
}