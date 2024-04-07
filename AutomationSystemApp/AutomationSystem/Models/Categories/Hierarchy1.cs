namespace AutomationSystem.Models;

public class Hierarchy1 : ICategory
{
    public int Id { get; set; }
    public string? Hierarchy1Name { get; set; }
    public string? Name
    {
        get
        {
            return Hierarchy1Name;
        }

        set
        {
            Name = Hierarchy1Name;
        }
    }
    public List<Hierarchy2> hierarchy2Names { get; set; }
}
