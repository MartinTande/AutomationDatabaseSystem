using AutomationListUI.Models;
using AutomationListUI.Services;
using System.ComponentModel.DataAnnotations;

namespace AutomationListUI.Validators;


public class ObjectNameValidator2 : ValidationAttribute
{
	IObjectService _objectService;
	List<DisplayObjectModel> objects = new List<DisplayObjectModel>();

    public ObjectNameValidator2(IObjectService objectService)
    {
		_objectService = objectService;
	}

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
	{
		if (value is null)
		{
			return new ValidationResult("Object name is required");
		}

		string inputName = value.ToString();

		if (inputName.Length > 20)
		{
			return new ValidationResult("Object name is too long");
		}

		objects = Task.Run(async () => await _objectService.GetObjectsAsync()).Result.ToList();

		// Check if the input name is unique among other items
		var existingNames = objects.Select(o => o.FullObjectName).ToList();
		if (existingNames.Contains(inputName))
		{
			return new ValidationResult("Object name should be unique");
		}

		return ValidationResult.Success;
	}
}
