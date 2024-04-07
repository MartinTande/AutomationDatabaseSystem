namespace AutomationSystem.Models;

public class AlwaysVisible : ICategory
{
    public int Id { get; set; }
    public string? AlwaysVisibleName { get; set; }
    public string? Name
    {
        get
        {
            return AlwaysVisibleName;
        }

        set
        {
            Name = AlwaysVisibleName;
        }
    }
}
