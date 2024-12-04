using AutomationListLibrary.Data;
using AutomationListLibrary.DataManager;
using AutomationListUI.Models;

namespace AutomationListUI.Services;

public class ObjectService : IObjectService
{
	private readonly IObjectDataManager _objectDataManager;

	public ObjectService(IObjectDataManager objectDataManager)
	{
		_objectDataManager = objectDataManager;
	}

	private ObjectModel? MapDisplayObjectToDTO(DisplayObjectModel displayObject)
	{
		if (displayObject == null) return null;

		ObjectModel objectModel = new ObjectModel()
		{
			Id = displayObject.Id,
			SfiNumber = displayObject.SfiNumber,
			MainEqNumber = displayObject.MainEqNumber,
			EqNumber = displayObject.EqNumber,
			Description = displayObject.Description,
			Hierarchy1 = displayObject.Hierarchy1,
			Hierarchy2 = displayObject.Hierarchy2,
			VduGroup = displayObject.VduGroup,
			EasGroup = displayObject.EasGroup,
			AcknowledgeAllowed = displayObject.AcknowledgeAllowed,
			AlwaysVisible = displayObject.AlwaysVisible,
			AlarmGroup = displayObject.AlarmGroup,
			Node = displayObject.Node,
			Cabinet = displayObject.Cabinet,
			Otd = displayObject.Otd,
			ObjectType = displayObject.ObjectType,
			Revision = displayObject.Revision
		};

		return objectModel;
	}

	private DisplayObjectModel? MapDTOToDisplayObject(ObjectModel dtoObject)
	{
		if (dtoObject == null) return null;

		DisplayObjectModel displayObject = new DisplayObjectModel()
		{
			Id = dtoObject.Id,
			SfiNumber = dtoObject.SfiNumber,
			MainEqNumber = dtoObject.MainEqNumber,
			EqNumber = dtoObject.EqNumber,
			Description = dtoObject.Description,
			Hierarchy1 = dtoObject.Hierarchy1,
			Hierarchy2 = dtoObject.Hierarchy2,
			VduGroup = dtoObject.VduGroup,
			EasGroup = dtoObject.EasGroup,
			AcknowledgeAllowed = dtoObject.AcknowledgeAllowed,
			AlwaysVisible = dtoObject.AlwaysVisible,
			AlarmGroup = dtoObject.AlarmGroup,
			Node = dtoObject.Node,
			Cabinet = dtoObject.Cabinet,
			Otd = dtoObject.Otd,
			ObjectType = dtoObject.ObjectType,
			Revision = dtoObject.Revision,
			LastModified = dtoObject.LastModified
		};

		return displayObject;
	}

	public async Task<List<DisplayObjectModel>> GetObjectsAsync()
	{
		List<ObjectModel> objects = await _objectDataManager.GetObjects();
		List<DisplayObjectModel> displayObjects = new List<DisplayObjectModel>();

		if (objects is null) return null;

		foreach (var obj in objects)
		{
			displayObjects.Add(MapDTOToDisplayObject(obj));
		}

		return displayObjects;
	}

	public async Task DeleteObjectAsync(int id)
	{
		await _objectDataManager.DeleteObject(id);
	}

	public async Task UpdateObjectAsync(DisplayObjectModel updatedObject)
	{
		ObjectModel updatedDTO = MapDisplayObjectToDTO(updatedObject);
		await _objectDataManager.UpdateObject(updatedDTO);
	}

	public async Task InsertObjectAsync(DisplayObjectModel displayObject)
	{
		ObjectModel newDTO = MapDisplayObjectToDTO(displayObject);

		await _objectDataManager.InsertObject(newDTO);
	}

	public async Task<int> GetLastInsertedObjectId()
	{
		return await _objectDataManager.GetLastInsertedObjectId();
	}

	public async Task<DisplayObjectModel> GetObjectByIdAsync(int id)
	{
		ObjectModel dtoObject = await _objectDataManager.GetObjectById(id);
		return MapDTOToDisplayObject(dtoObject);
	}
}
