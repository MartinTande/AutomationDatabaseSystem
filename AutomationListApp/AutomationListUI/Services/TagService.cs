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

	// Default tag structure for auto generating object tags based on OTD type
	public async Task AddTagsBasedOnOTD(int objectId, string otdName)
	{
		if (_otdTagStructure.ContainsKey(otdName))
		{
			List<TagModel> tags = _otdTagStructure[otdName];
			foreach (TagModel tag in tags)
			{
				await _tagDataManager.InsertTagAsync(objectId, tag);
			}
		}
	}

	Dictionary<string, List<TagModel>> _otdTagStructure = new Dictionary<string, List<TagModel>>()
{
	{
		"BO_Motor", [
			new TagModel { EqSuffix = 11, Description = "Running feedback", IoType = "DI", SignalType = "NO" },
			new TagModel { EqSuffix = 12, Description = "Local selector", IoType = "DI", SignalType = "NO" },
			new TagModel { EqSuffix = 21, Description = "Start command", IoType = "DO", SignalType = "NO" },
			new TagModel { EqSuffix = 22, Description = "Stop command", IoType = "DO", SignalType = "NO" },
			new TagModel { EqSuffix = 18, Description = "Auxiliary fault", IoType = "DI", SignalType = "NC" },
			]
	},
	{
		"BO_MotorFC", [
			new TagModel { EqSuffix = 11, Description = "Running feedback", IoType = "DI", SignalType = "NO" },
			new TagModel { EqSuffix = 12, Description = "Local selector", IoType = "DI", SignalType = "NO" },
			new TagModel { EqSuffix = 21, Description = "Start command", IoType = "DO", SignalType = "NO" },
			new TagModel { EqSuffix = 22, Description = "Stop command", IoType = "DO", SignalType = "NO" },
			new TagModel { EqSuffix = 18, Description = "Auxiliary fault", IoType = "DI", SignalType = "NC" },
			new TagModel { EqSuffix = 61, Description = "Speed feedback", IoType = "AI", SignalType = "4-20mA, 2W" },
			new TagModel { EqSuffix = 62, Description = "Speed setpoint", IoType = "AO", SignalType = "4-20mA, 2W" },
			]
	},
	{
		"BO_Valve", [
			new TagModel { EqSuffix = 01, Description = "Closed feedback", IoType = "DI", SignalType = "NO" },
			new TagModel { EqSuffix = 02, Description = "Opened feedback", IoType = "DI", SignalType = "NO" },
			new TagModel { EqSuffix = 03, Description = "Close command", IoType = "DO", SignalType = "NO" },
			new TagModel { EqSuffix = 04, Description = "Open command", IoType = "DO", SignalType = "NO" },
			new TagModel { EqSuffix = 07, Description = "Valve - Fault", IoType = "DO", SignalType = "NO" },
			]
	},
	{
		"BO_AnalogIn", [
			new TagModel { EqSuffix = 41, Description = "Value", IoType = "AI", SignalType = "Int" }
			]
	},
	{
		"BO_Value", [
			new TagModel { EqSuffix = 41, Description = "Value", IoType = "AI", SignalType = "Int" }
			]
	},
	{
		"BO_Breaker", [
			new TagModel { EqSuffix = 32, Description = "Open feedback", IoType = "DI", SignalType = "NO" },
			new TagModel { EqSuffix = 31, Description = "Close feedback", IoType = "DI", SignalType = "NO" },
			new TagModel { EqSuffix = 34, Description = "Open command", IoType = "DO", SignalType = "NO" },
			new TagModel { EqSuffix = 33, Description = "Close command", IoType = "DO", SignalType = "NO" },
			]
	},
	{
		"BO_Tank", [
			new TagModel { EqSuffix = 21, Description = "Level", IoType = "AI", SignalType = "U_AnalogValueLong" }
			]
	},
	{
		"BO_1DI", [
			new TagModel { EqSuffix = 01, Description = "Alarm", IoType = "DI", SignalType = "NO" }
			]
	},
};
}
