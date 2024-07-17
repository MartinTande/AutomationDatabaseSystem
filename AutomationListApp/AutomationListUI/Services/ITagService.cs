using AutomationListUI.Models;

namespace AutomationListUI.Services
{
	public interface ITagService
	{
		Task DeleteTagAsync(int tagId);
		Task<List<DisplayTagModel>> GetTagsByObjectIdAsync(int objectId);
		Task InsertTagAsync(int objectId, DisplayTagModel tag);
		Task UpdateTagAsync(DisplayTagModel tag);
	}
}