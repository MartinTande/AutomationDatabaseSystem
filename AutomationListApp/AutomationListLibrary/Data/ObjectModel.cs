using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AutomationListLibrary.Data;

public class ObjectModel
{
    public int Id { get; set; }
    public int SfiNumber { get; set; }
    public string? MainEqNumber { get; set; }
    public string? EqNumber { get; set; }
    public string? Description { get; set; }
    public string? Hierarchy1 { get; set; }
    public string? Hierarchy2 { get; set; }
    public string? VduGroup { get; set; }
    public string? AlarmGroup { get; set; }
    public string? EasGroup { get; set; }
    public string? Otd { get; set; }
    public Otd? OtdInterface { get; set; }
    public string? AcknowledgeAllowed { get; set; }
    public string? AlwaysVisible { get; set; }
    public string? Node { get; set; }
    public string? Cabinet { get; set; }
	public DateTime? LastModified { get; }
	
    public string? FullObjectName => $"{SfiNumber}_{MainEqNumber}_{EqNumber}";

	public List<TagModel>? Tags { get; set; }

    private bool DescriptionIsValid
    {
        get
        {
            return (!string.IsNullOrEmpty(Description)) && (Description.Length <= 46);
        }
    }

    private bool NameIsValid
    {
        get
        {
            return (!string.IsNullOrEmpty(FullObjectName)) && (FullObjectName.Length <= 20);
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
            foreach (OtdInterface currentInterface in OtdInterface.Interface)
            {
                if (currentInterface.IsOptional)
                {
                    continue;
                }
                _mandatoryConnectionsResolved = LookupTagSuffixesAgaintOtdInterface(currentInterface.Suffix);
            }
            return NameIsValid &&
                DescriptionIsValid &&
                !string.IsNullOrEmpty(Hierarchy1) &&
                !string.IsNullOrEmpty(Otd) &&
                !string.IsNullOrEmpty(Node) &&
                _mandatoryConnectionsResolved;
        }
    }

    public bool ReadyForHMIGeneration
    {
        get
        {
            return NameIsValid &&
                !string.IsNullOrEmpty(Hierarchy1) &&
                !string.IsNullOrEmpty(Hierarchy2) &&
                !string.IsNullOrEmpty(Otd) &&
                !string.IsNullOrEmpty(Node);
        }
    }

    public bool ReadyForPreliminaryPLCGeneration
    {
        get
        {
            return NameIsValid && !string.IsNullOrEmpty(Otd) && !string.IsNullOrEmpty(Node);
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
