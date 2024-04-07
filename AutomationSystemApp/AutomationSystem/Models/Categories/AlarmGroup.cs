namespace AutomationSystem.Models;

public class AlarmGroup : ICategory
{
    public int Id { get; set; }
    public string? AlarmGroupName { get; set; }
    public string? Name
    {
        get
        {
            return AlarmGroupName;
        }

        set
        {
            Name = AlarmGroupName;
        }
    }
}
