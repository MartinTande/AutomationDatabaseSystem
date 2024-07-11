using System.Text.RegularExpressions;

namespace AutomationListLibrary.Data;

public class TagModel
{
    public int Id { get; set; }
    public int? EqSuffix { get; set; }
    public string? Description { get; set; }
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
    public bool IsE0 { get; set; }
    public bool IsVDR { get; set; }
    public DateTime? LastModified { get; }
    public string? ObjectName { get; set; }


    public bool IsHW => !IoType.StartsWith("S");

    public bool IsInput => IoType.EndsWith("I");

    public bool IsDigital => IoType.Contains("D");

    public string FullTagName
    {
        get
        {
            return $"{GetPrefix()}{ObjectName}_{EqSuffix}";
        }
    }

    private string GetPrefix()
    {
        string ioPrefix = IsInput ? "x" : "y";
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

    public bool AbsoluteAddressIsValid
    {
        get
        {
            if (!IsHW)
            {
                return false;
            }
            string regexPattern = IsInput ? "I" : "Q";
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

    public bool ReadyForSWGeneration
    {
        get
        {
            bool _hasPath = false;
            if (!IsHW && (!String.IsNullOrEmpty(SWPath) || !String.IsNullOrEmpty(DBName)))
            {
                _hasPath = true;
            }

            return !String.IsNullOrEmpty(IoType) &&
                   !String.IsNullOrEmpty(SignalType) &&
                   _hasPath;
        }
    }
}
