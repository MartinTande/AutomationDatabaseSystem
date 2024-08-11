namespace AutomationListLibrary.Data;

public class TagModel
{
    public int Id { get; set; }
    public int ObjectId { get; set; }
	public string? EqSuffix { get; set; }
    public string? Description { get; set; }
    public string? Symbol { get; set; }
    public string? IoType { get; set; }
    public string? SignalType { get; set; }
    public string? AlarmDelay { get; set; }
    public string? EngUnit { get; set; }
    public int? RangeLow { get; set; }
    public int? RangeHigh { get; set; }
    public int? LowLowLimit { get; set; }
    public int? LowLimit { get; set; }
    public int? HighLimit { get; set; }
    public int? HighHighLimit { get; set; }
    public int? Slot { get; set; }
    public int? Channel { get; set; }
    public int? TP1 { get; set; }
    public int? TP2 { get; set; }
    public int? TP3 { get; set; }
    public int? TP4 { get; set; }
    public string? AbsoluteAddress { get; set; }
    public string? SWPath { get; set; }
    public string? DBName { get; set; }
    public int? ModbusAddress { get; set; }
    public int? ModbusBit { get; set; }
    public bool? IsE0 { get; set; }
    public bool? IsVDR { get; set; }
    public string? IOStatus { get; set; }
    public DateTime? LastModified { get; }
    public string? ObjectName { get; set; }
	public string? InterfaceModule { get; set; }
    public bool UserLock { get; set; }
    public bool IOLock { get; set; }
    public int BeijerBoxId { get; set; }
}
