using System.Collections.ObjectModel;

namespace AutomationSystem.Models;

public interface IItem
{
    int Id { get; set; }
    string? Name { get; }
    ObservableCollection<IItem> SubItem { get; }
}
