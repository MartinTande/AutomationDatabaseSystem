using AutomationListLibrary.DataAccess;
using AutomationListLibrary.DataManager;
using AutomationListUI.Models;
using AutomationListUI.Services;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutomationListUI.Validators;

public class TagSuffixValidator : ValidationAttribute
{
	ISqlConnector _sqlConnector;
	TagDataManager _tagManager;
	ITagService _tagService;
	List<DisplayTagModel> tags = new List<DisplayTagModel>();

	public TagSuffixValidator()
	{
		var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
		_sqlConnector = new SqlConnector(configuration);
		_tagManager = new TagDataManager(_sqlConnector);
		_tagService = new TagService(_tagManager);
	}

	protected override ValidationResult IsValid(object value, ValidationContext validationContext)
	{
		if (value is null)
		{
			return new ValidationResult("No Signal type");
		}
		string currentSuffix = value.ToString();
		DisplayTagModel tag = (DisplayTagModel)validationContext.ObjectInstance;

		var task = Task.Run(async () => await _tagService.GetTagsByObjectIdAsync(tag.ObjectId));
		task.Wait();
		tags = task.Result.ToList();

		var usedSuffixes = tags.Select(t => t.EqSuffix).ToList();
		if (usedSuffixes.Contains(currentSuffix))
		{
			return new ValidationResult("Eq Suffix must be unique");
		}

		return ValidationResult.Success;
	}
}
