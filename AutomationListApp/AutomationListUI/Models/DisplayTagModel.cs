using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace AutomationListUI.Models;

public class DisplayTagModel
{
	public int Id { get; set; }
	[Required]
	public int? EqSuffix { get; set; }
	[Required]
	[StringLength(46, ErrorMessage = "Description is too long")]
	public string? Description { get; set; }
	[Required]
	public string? IoType { get; set; }
	public string? SignalType { get; set; }
	public string? EngUnit { get; set; }
	public int? RangeLow { get; set; }
	public int? RangeHigh { get; set; }
	public int? LowLowLimit { get; set; }
	public int? LowLimit { get; set; }
	public int? HighLimit { get; set; }
	public int? HighHighLimit { get; set; }
	public int? Slot { get; set; }
	public string? AbsoluteAddress { get; set; }
	public string? SWPath { get; set; }
	public string? DBName { get; set; }
	public int? ModbusAddress { get; set; }
	public int? ModbusBit { get; set; }
	public bool? IsE0 { get; set; }
	public bool? IsVDR { get; set; }
	[Editable(false)]
	public DateTime? LastModified { get; set; }
	public string? ObjectName { get; set; }

	public bool? IsHW => !IoType?.StartsWith("S");

	public bool? IsInput => IoType?.EndsWith("I");

	public bool? IsDigital => IoType?.Contains("D");

	public string FullTagName => $"{GetPrefix()}{ObjectName}_{EqSuffix}";

	private string GetPrefix()
	{
		string ioPrefix = (bool)IsInput ? "x" : "y";
		Dictionary<string, string> signalPrefix = new Dictionary<string, string>()
	{
		{ "NC", "bo" },
		{ "NO", "bo" },
		{ "BYTE", "by" },
		{ "WORD", "wo" },
		{ "DWORD", "dw" },
		{ "LWORD", "lw" },
		{ "SINT", "si" },
		{ "INT", "in" },
		{ "DINT", "di" },
		{ "LINT", "li" },
		{ "USINT", "us" },
		{ "UINT", "ui" },
		{ "UDINT", "ud" },
		{ "ULINT", "ul" },
		{ "REAL", "re" },
		{ "LREAL", "lr" },
		{ "CHAR", "ch" },
		{ "STRING", "sti" }
	};

		return ioPrefix + signalPrefix[SignalType.ToUpper()];
	}

	public bool? AbsoluteAddressIsValid
	{
		get
		{
			if ((bool)!IsHW)
			{
				return false;
			}
			string regexPattern = (bool)IsInput ? "I" : "Q";
			switch (SignalType.ToUpper())
			{
				case "BYTE":
				case "SINT":
				case "USINT":
					regexPattern += "B\\d+";
					break;
				case "WORD":
				case "INT":
				case "UINT":
					regexPattern += "W\\d+";
					break;
				case "DWORD":
				case "DINT":
				case "UDINT":
				case "REAL":
					regexPattern += "D\\d+";
					break;
				case "LWORD":
				case "LINT":
				case "ULINT":
				case "LREAL":
					regexPattern += "\\d+";
					break;
				case "BOOL":
					regexPattern += "\\d+.\\d+";
					break;
			}
			regexPattern += "$";
			Regex regex = new Regex(regexPattern);
			return regex.IsMatch(AbsoluteAddress);
		}
	}

	public bool? ReadyForSWGeneration
	{
		get
		{
			bool _hasPath = false;
			if (!(bool)IsHW && (!string.IsNullOrEmpty(SWPath) || !string.IsNullOrEmpty(DBName)))
			{
				_hasPath = true;
			}

			return !string.IsNullOrEmpty(IoType) &&
				   !string.IsNullOrEmpty(SignalType) &&
				   _hasPath;
		}
	}
}
