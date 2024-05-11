using System.Collections.ObjectModel;

namespace AutomationSystem.Models;

public class HierarchyModel : IItem
{
    public int Id { get; set; }
    public string? Name { get; set; }

    public ObservableCollection<IItem> SubItem { get; set; }
    public HierarchyModel()
    {
        SubItem = new ObservableCollection<IItem>();
    }
}
