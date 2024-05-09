namespace AutomationSystem.Models.Categories;

public class EngUnit : ICategory
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int? UnitId { get; set; }
}
