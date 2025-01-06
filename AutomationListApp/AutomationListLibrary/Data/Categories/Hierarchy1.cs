namespace AutomationListLibrary.Data;

public class Hierarchy1 : ICategory
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public List<Hierarchy2> SubPictures { get; set; } = new();
}
