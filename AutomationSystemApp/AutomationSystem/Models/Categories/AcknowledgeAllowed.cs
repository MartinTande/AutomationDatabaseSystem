namespace AutomationSystem.Models;

public class AcknowledgeAllowed : ICategory
{
    public int Id { get; set; }
    public string? AcknowledgeAllowedName { get; set; }
    public string? Name
    {
        get
        {
            return AcknowledgeAllowedName;
        }

        set
        {
            Name = AcknowledgeAllowedName;
        }
    }
}
