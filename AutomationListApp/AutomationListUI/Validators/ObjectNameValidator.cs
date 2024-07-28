using AutomationListLibrary.DataAccess;
using AutomationListLibrary.DataManager;
using AutomationListUI.Models;
using AutomationListUI.Services;
using System.ComponentModel.DataAnnotations;

namespace AutomationListUI.Validators;


public class ObjectNameValidator : ValidationAttribute
{
	ISqlConnector _sqlConnector;
	IObjectDataManager _objectManager;
	IObjectService _objectService;
	List<DisplayObjectModel> objects = new List<DisplayObjectModel>();

    public ObjectNameValidator()
    {
		var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
		_sqlConnector = new SqlConnector(configuration);
		_objectManager = new ObjectDataManager(_sqlConnector);
		_objectService = new ObjectService(_objectManager);
	}

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
	{
		objects = Task.Run(async () => await _objectService.GetObjectsAsync()).Result.ToList();

		string inputName = value.ToString();
		if (string.IsNullOrEmpty(inputName))
			return new ValidationResult("Object name is required");

		// Check if the input name is unique among other items
		var existingNames = objects.Select(o => o.FullObjectName).ToList();
		if (existingNames.Contains(inputName))
			return new ValidationResult("Object name should be unique");

		return ValidationResult.Success; ; // Validation passed
	}
}
