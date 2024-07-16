using AutomationListLibrary.DataAccess;
using AutomationListLibrary.DataManager;
using AutomationListUI.Models;
using AutomationListUI.Services;
using System.ComponentModel.DataAnnotations;

namespace AutomationListUI.Validators;

public class TagSuffixValidator : ValidationAttribute
{
	private readonly int _objectId;
	ISqlConnector _sqlConnector;
	TagDataManager _tagManager;
	ITagService _tagService;
	List<DisplayTagModel> tags = new List<DisplayTagModel>();

	public TagSuffixValidator(int objectId)
	{
		var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
		_sqlConnector = new SqlConnector(configuration);
		_tagManager = new TagDataManager(_sqlConnector);
		_tagService = new TagService(_tagManager);
		_objectId = objectId;
	}

	protected override ValidationResult IsValid(object value, ValidationContext validationContext)
	{
		//objects = _tagService.GetTagsByObjectIdAsync();
		string inputName = value.ToString();
		if (string.IsNullOrEmpty(inputName))
			return new ValidationResult("Object name should is required");

		// Check if the input name is unique among other items
		List<string> existingNames = tags.Select(o => o.FullTagName).ToList();
		if (existingNames.Contains(inputName))
			return new ValidationResult("Object name should be unique");

		return ValidationResult.Success; ; // Validation passed
	}
}
