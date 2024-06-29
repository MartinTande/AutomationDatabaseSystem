using AutomationSystem.Models.Data.Categories;

namespace AutomationSystem.Models;

public class Otd : ICategory
{

    public int Id { get; set; }
    public string? Name { get; set; }
    public List<OtdInterface>? Interface { get; set; }
    public Otd()
    {
        Interface = new List<OtdInterface>();
    }
}