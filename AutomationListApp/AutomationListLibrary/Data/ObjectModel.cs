using System.ComponentModel.DataAnnotations;

namespace AutomationListLibrary.Data;

public class ObjectModel
{
    [Key]
    public int Id { get; set; }
    public int SfiNumber { get; set; }
    public string? MainEqNumber { get; set; }
    public string? EqNumber { get; set; }
    public string? Description { get; set; }
    public string? Hierarchy1Name { get; set; }
    public string? Hierarchy2Name { get; set; }
    public string? VduGroupName { get; set; }
    public string? AlarmGroupName { get; set; }
    public string? OtdName { get; set; }
    public Otd? Otd { get; set; }
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

    private bool DescriptionIsValid
    {
        get
        {
            return (!String.IsNullOrEmpty(Description)) && (Description.Length <= 46);
        }
    }

    private bool NameIsValid
    {
        get
        {
            return (!String.IsNullOrEmpty(FullObjectName)) && (FullObjectName.Length <= 20);
        }
    }

    public bool ReadyForPLCGeneration
    {
        get
        {
            bool _mandatoryConnectionsResolved = false;
            if (Otd == null)
            {
                return false;
            }
            foreach (OtdInterface currentInterface in Otd.Interface)
            {
                if (currentInterface.IsOptional)
                {
                    continue;
                }
                _mandatoryConnectionsResolved = LookupTagSuffixesAgaintOtdInterface(currentInterface.Suffix);
            }
            return NameIsValid &&
                DescriptionIsValid &&
                !String.IsNullOrEmpty(Hierarchy1Name) &&
                !String.IsNullOrEmpty(OtdName) &&
                !String.IsNullOrEmpty(NodeName) &&
                _mandatoryConnectionsResolved;
        }
    }

    public bool ReadyForHMIGeneration
    {
        get
        {
            return NameIsValid &&
                !String.IsNullOrEmpty(Hierarchy1Name) &&
                !String.IsNullOrEmpty(Hierarchy2Name) &&
                !String.IsNullOrEmpty(OtdName) &&
                !String.IsNullOrEmpty(NodeName);
        }
    }

    public bool ReadyForPreliminaryPLCGeneration
    {
        get
        {
            return NameIsValid && !String.IsNullOrEmpty(OtdName) && !String.IsNullOrEmpty(NodeName);
        }
    }

    private bool LookupTagSuffixesAgaintOtdInterface(string suffix)
    {
        if (Tags == null)
        {
            return false;
        }
        foreach (TagModel tag in Tags)
        {
            if (tag.EqSuffix == Convert.ToInt16(suffix))
            {
                return true;
            }
        }
        return false;
    }
}
