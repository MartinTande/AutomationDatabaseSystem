namespace AutomationSystem.Models;

public class Hierarchy : IItem
{
    public string? Name { get; set; }

    public List<IItem> SubItem { get; set; }
    public Hierarchy()
    {
        SubItem = new List<IItem>();
    }
}
