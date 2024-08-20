using AutomationListLibrary.Data;
using AutomationListLibrary.DataAccess;
using AutomationListLibrary.DataManager;
using AutomationListUI.Models;
using AutomationListUI.Services;
using System.ComponentModel.DataAnnotations;

namespace AutomationListUI.Validators;

public class TagSuffixValidator2 : ValidationAttribute
{
	ITagService _tagService;
	IObjectService _objectService;
	SubCategoryDataManager	_subCategoryDataManager;

	public TagSuffixValidator2(IObjectService objectService, ITagService tagService, SubCategoryDataManager subCategoryDataManager)
	{
		_tagService = tagService;
		_objectService = objectService;
		_subCategoryDataManager = subCategoryDataManager;
	}

	protected override ValidationResult IsValid(object value, ValidationContext validationContext)
	{
		if (value is null)
		{
			return null;
		}
		string currentSuffix = value.ToString();
		DisplayTagModel currentTag = (DisplayTagModel)validationContext.ObjectInstance;

		List<DisplayTagModel> tags = Task.Run(async () => await _tagService.GetTagsByObjectIdAsync(currentTag.ObjectId)).Result.ToList();

		List<string?> usedSuffixes = tags.Where(t => t.Id != currentTag.Id)
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
