using AutomationListLibrary.Data;
using AutomationListLibrary.DataAccess;
using AutomationListLibrary.DataManager;
using AutomationListUI.Models;
using AutomationListUI.Services;
using System.ComponentModel.DataAnnotations;

namespace AutomationListUI.Validators;

public class TagSuffixValidator : ValidationAttribute
{
	ISqlConnector _sqlConnector;
	ITagService _tagService;
	IObjectService _objectService;
	TagDataManager _tagManager;
	ObjectDataManager _objectDataManager;
	SubCategoryDataManager	_subCategoryDataManager;

	public TagSuffixValidator()
	{
		var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
		_sqlConnector = new SqlConnector(configuration);
		_tagManager = new TagDataManager(_sqlConnector);
		_tagService = new TagService(_tagManager);
		_objectDataManager = new ObjectDataManager(_sqlConnector);
		_objectService = new ObjectService(_objectDataManager);
		_subCategoryDataManager = new SubCategoryDataManager(_sqlConnector);
	}

	protected override ValidationResult IsValid(object value, ValidationContext validationContext)
	{
		if (value is null)
		{
			return null;
		}
		string currentSuffix = value.ToString();
		DisplayTagModel currentTag = (DisplayTagModel)validationContext.ObjectInstance;

		var tags = Task.Run(async () => await _tagService.GetTagsByObjectIdAsync(currentTag.ObjectId)).Result.ToList();

		var usedSuffixes = tags.Where(t => t.Id != currentTag.Id)
								.Select(t => t.EqSuffix)
								.ToList();

		if (usedSuffixes.Contains(currentSuffix))
		{
			return new ValidationResult("Eq Suffix must be unique");
		}

		DisplayObjectModel displayObject = Task.Run(async () => await _objectService.GetObjectByIdAsync(currentTag.ObjectId)).Result;
		List<OtdInterface> otdInterfaces = Task.Run(async () => await _subCategoryDataManager.GetOtdInterfacesAsync(displayObject.Otd)).Result.ToList();
		var possibleSuffixes = otdInterfaces.Select(o => o.Suffix);
		
		if (!possibleSuffixes.Contains(currentSuffix))
		{
			return new ValidationResult("Eq Suffix not part of OTD");
		}

		return ValidationResult.Success;
	}
}
