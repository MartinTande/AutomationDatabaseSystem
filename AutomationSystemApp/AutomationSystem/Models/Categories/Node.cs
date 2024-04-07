namespace AutomationSystem.Models;

public class Node : ICategory
{
    public int Id { get; set; }
    public string? NodeName { get; set; }
    public string? Name
    {
        get
        {
            return NodeName;
        }

        set
        {
            Name = NodeName;
        }
    }
}