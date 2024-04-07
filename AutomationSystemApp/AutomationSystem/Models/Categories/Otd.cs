namespace AutomationSystem.Models;

public class Otd : ICategory
{
    public int Id { get; set; }
    public string? OtdName { get; set; }
    public string? Name
    {
        get
        {
            return OtdName;
        }

        set
        {
            Name = OtdName;
        }
    }
}