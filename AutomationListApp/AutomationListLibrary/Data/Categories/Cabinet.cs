namespace AutomationListLibrary.Data;

public class Cabinet : ICategory
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int NoIMs { get; set; }
    public int NoSlotsPerIM { get; set; }
}
