namespace AutomationSystem.Models;

public interface IItem
{
    string? Name { get; }
    List<IItem> SubItem { get; }
}
