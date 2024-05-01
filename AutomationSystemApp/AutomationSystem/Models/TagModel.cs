namespace AutomationSystem.Models;

public class TagModel
{
    public int Id { get; set; }
    public int Suffix { get; set; }
    public bool IsE0 { get; set; }
    public bool IsVDR { get; set; }
    public string? Description { get; set; }
    public string? SignalType { get; set; }
    public string? IoType { get; set; }
    public int LowLimit { get; set; }
    public int LowLowLimit { get; set; }
    public int HighLimit { get; set; }
    public int HighHighLimit { get; set; }
    public int Slot { get; set; }
    public string? AbsoluteAddress { get; set; }
    public string? SWPath { get; set; }
    public string? DataBlockName { get; set; }
    public int ModbusAddress { get; set; }
    public int ModbusBit { get; set; }
    public string? ObjectName { get; set; }

    public string FullTagName
    {
        get
        {
            return $"{ObjectName}_{Suffix}";
        }
    }
}
