using System.Numerics;

namespace AutomationSystem.Models;

public class Hierarchy2 : ICategory
{
    public int Id { get; set; }
    public string? Hierarchy2Name { get; set; }
    public string? Name
    {
        get
        {
            return Hierarchy2Name;
        }

        set
        {
            Name = Hierarchy2Name;
        }
    }
}