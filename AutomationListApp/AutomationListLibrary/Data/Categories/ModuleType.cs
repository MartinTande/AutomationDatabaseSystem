namespace AutomationListLibrary.Data;

public class ModuleType
{
    public int Id { get; set; }
    public int Name { get; set; }
    public string? OrderNumber { get; set; }
    public int InBytes  { get; set; }
    public int InBits { get; set; }
    public int OutBytes { get; set; }
    public int OutBits { get; set; }
    public int QIBits { get; set; }
}
