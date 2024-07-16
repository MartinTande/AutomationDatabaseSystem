using AutomationListLibrary.Data;
using AutomationListLibrary.DataAccess;
using AutomationListLibrary.DataManager;
using AutomationListUI.Models;
using System.ComponentModel.DataAnnotations;

namespace AutomationListUI.Validators;

public class SignalTypeValidator : ValidationAttribute
{
	ISqlConnector _sqlConnector;
	SubCategoryDataManager _subCategoryDataManager;

	public SignalTypeValidator()
	{
		var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
		_sqlConnector = new SqlConnector(configuration);
		_subCategoryDataManager = new SubCategoryDataManager(_sqlConnector);
	}

	protected override ValidationResult IsValid(object value, ValidationContext validationContext)
	{
		if (value is null)
		{
			return new ValidationResult("No Signal type");
		}
		string signalType = value.ToString();
		DisplayTagModel tag = (DisplayTagModel)validationContext.ObjectInstance;

		if (string.IsNullOrEmpty(signalType))
			return new ValidationResult("Signal Type is required");

		List<SignalType> _signalTypes = _subCategoryDataManager.GetSignalTypes(tag.IoType);
		var signalTypeNames = _signalTypes.Select(x => x.Name).ToList();
		if (!signalTypeNames.Contains(signalType))
			return new ValidationResult("Signal Type does not match with Io Type");

		return ValidationResult.Success;
	}
}
