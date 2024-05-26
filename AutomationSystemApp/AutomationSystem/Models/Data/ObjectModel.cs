using AutomationSystem.MVVM;

namespace AutomationSystem.Models;

public class ObjectModel : ViewModelBase
{
    public int Id { get; set; }
    public int SfiNumber { get; set; }
    public string? MainEqNumber { get; set; }
    public string? EqNumber { get; set; }
    private string? _description;

    public string? Description
    {
        get { return _description; }
        set
        {
            _description = value;
            OnPropertyChanged();
            
        }
    }
    public string? Hierarchy1Name { get; set; }
    public string? Hierarchy2Name { get; set; }
    public string? VduGroupName { get; set; }
    public string? AlarmGroupName { get; set; }
    public string? OtdName { get; set; }
    public string? AcknowledgeAllowedName { get; set; }
    public string? AlwaysVisibleName { get; set; }
    public string? NodeName { get; set; }
    public string? CabinetName { get; set; }

    public string? FullObjectName
    {
        get
        {
            return $"{SfiNumber}_{MainEqNumber}_{EqNumber}";
        }
    }

    public List<TagModel>? Tags { get; set; }


}
