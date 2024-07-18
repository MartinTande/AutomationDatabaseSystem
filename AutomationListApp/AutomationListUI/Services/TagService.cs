using AutomationListLibrary.Data;
using AutomationListLibrary.DataManager;
using AutomationListUI.Models;

namespace AutomationListUI.Services;

public class TagService : ITagService
{
	private readonly TagDataManager _tagDataManager;

	public TagService(TagDataManager tagDataManager)
	{
		_tagDataManager = tagDataManager;
	}

	public async Task<List<DisplayTagModel>> GetTagsByObjectIdAsync(int objectId)
	{
		var dtoTags = await _tagDataManager.GetTagsByObjectIdAsync(objectId);
		List<DisplayTagModel> displayTags = new List<DisplayTagModel>();

		foreach (var tag in dtoTags)
		{
			displayTags.Add(MapDTOToDisplayTag(tag));
		}

		return displayTags;
	}

	public async Task<List<DisplayTagModel>> GetTagsByObjectTypeAsync(string objectType)
	{
		var dtoTags = await _tagDataManager.GetTagsByObjectTypeAsync(objectType);
		List<DisplayTagModel> displayTags = new List<DisplayTagModel>();

		foreach (var tag in dtoTags)
		{
			displayTags.Add(MapDTOToDisplayTag(tag));
		}

		return displayTags;
	}

	public async Task DeleteTagAsync(int tagId)
	{
		await _tagDataManager.DeleteTagAsync(tagId);
	}

	public async Task InsertTagAsync(int objectId, DisplayTagModel tag)
	{
		TagModel newDto = MapDisplayTagToDTO(tag);
		await _tagDataManager.InsertTagAsync(objectId, newDto);
	}

	public async Task UpdateTagAsync(DisplayTagModel tag)
	{
		TagModel updatedDto = MapDisplayTagToDTO(tag);
		await _tagDataManager.UpdateTagAsync(updatedDto);
	}

	private TagModel? MapDisplayTagToDTO(DisplayTagModel displayTag)
	{
		if (displayTag == null) return null;

		TagModel tagModel = new TagModel()
		{
			Id = displayTag.Id,
			ObjectId = displayTag.ObjectId,
			EqSuffix = displayTag.EqSuffix,
			Description = displayTag.Description,
			IoType = displayTag.IoType,
			SignalType = displayTag.SignalType,
			EngUnit = displayTag.EngUnit,
			RangeLow = displayTag.RangeLow,
			RangeHigh = displayTag.RangeHigh,
			LowLowLimit = displayTag.LowLowLimit,
			LowLimit = displayTag.LowLimit,
			HighLimit = displayTag.HighLimit,
			HighHighLimit = displayTag.HighHighLimit,
			Slot = displayTag.Slot,
			AbsoluteAddress = displayTag.AbsoluteAddress,
			SWPath = displayTag.SWPath,
			DBName = displayTag.DBName,
			ModbusAddress = displayTag.ModbusAddress,
			ModbusBit = displayTag.ModbusBit,
			IsE0 = displayTag.IsE0,
			IsVDR = displayTag.IsVDR,
		};

		return tagModel;
	}

	private DisplayTagModel? MapDTOToDisplayTag(TagModel dtoTag)
	{
		if (dtoTag == null) return null;

		DisplayTagModel displayTag = new DisplayTagModel()
		{
			Id = dtoTag.Id,
			ObjectId = dtoTag.ObjectId,
			EqSuffix = dtoTag.EqSuffix,
			Description = dtoTag.Description,
			IoType = dtoTag.IoType,
			SignalType = dtoTag.SignalType,
			EngUnit = dtoTag.EngUnit,
			RangeLow = dtoTag.RangeLow,
			RangeHigh = dtoTag.RangeHigh,
			LowLowLimit = dtoTag.LowLowLimit,
			LowLimit = dtoTag.LowLimit,
			HighLimit = dtoTag.HighLimit,
			HighHighLimit = dtoTag.HighHighLimit,
			Slot = dtoTag.Slot,
			AbsoluteAddress = dtoTag.AbsoluteAddress,
			SWPath = dtoTag.SWPath,
			DBName = dtoTag.DBName,
			ModbusAddress = dtoTag.ModbusAddress,
			ModbusBit = dtoTag.ModbusBit,
			IsE0 = dtoTag.IsE0,
			IsVDR = dtoTag.IsVDR,
			LastModified = dtoTag.LastModified
		};

		return displayTag;
	}

}
