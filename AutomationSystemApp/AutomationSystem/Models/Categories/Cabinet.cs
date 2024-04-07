
namespace AutomationSystem.Models;

public class Cabinet : ICategory
{
    public int Id { get; set; }
    public string? CabinetName { get; set; }
    public string? Name
    {
        get
        {
            return CabinetName;
        }

        set
        {
            Name = CabinetName;
        }
    }
}
