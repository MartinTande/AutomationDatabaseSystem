namespace AutomationListLibrary.Data;
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