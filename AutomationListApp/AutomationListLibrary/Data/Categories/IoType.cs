namespace AutomationListLibrary.Data;

public class IoType : ICategory
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public List<SignalType> SignalTypes { get; set; }
    public IoType()
    {
        SignalTypes = new List<SignalType>();
    }
}