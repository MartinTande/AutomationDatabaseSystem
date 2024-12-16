namespace AutomationListLibrary.Data;

public class ObjectType : ICategory
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? OtdName { get; set; }
    public List<TagModel> Tags { get; set; } = new();
}
