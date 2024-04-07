namespace AutomationSystem.Models;

public class VduGroup : ICategory
{
    public int Id { get; set; }
    public string? VduGroupName { get; set; }
    public string? Name
    {
        get
        {
            return VduGroupName;
        }

        set
        {
            Name = VduGroupName;
        }
    }
}
