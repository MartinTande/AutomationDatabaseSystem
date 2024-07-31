namespace AutomationListLibrary.Data;

public class ObjectModel
{
    public int Id { get; set; }
    public string? SfiNumber { get; set; }
    public string? MainEqNumber { get; set; }
    public string? EqNumber { get; set; }
    public string? Description { get; set; }
    public string? Hierarchy1 { get; set; }
    public string? Hierarchy2 { get; set; }
    public string? VduGroup { get; set; }
    public string? AlarmGroup { get; set; }
    public string? EasGroup { get; set; }
    public string? Otd { get; set; }
    public Otd? OtdInterface { get; set; }
    public string? ObjectType { get; set; }
    public string? AcknowledgeAllowed { get; set; }
    public string? AlwaysVisible { get; set; }
    public string? Node { get; set; }
    public string? Cabinet { get; set; }
	public DateTime? LastModified { get; }

	public List<TagModel>? Tags { get; set; }
}
