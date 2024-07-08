using AutomationListLibrary.Data;
using System.ComponentModel.DataAnnotations;


namespace AutomationListUI.Models;

public class DisplayObjectModel
{
    [Key]
    public int Id { get; set; }
    [Required]
    public int SfiNumber { get; set; }
    [Required]
    public string? MainEqNumber { get; set; }
    public string? EqNumber { get; set; }
    [Required]
    [StringLength(46, ErrorMessage = "Description is too long")]
    public string? Description { get; set; }
    public string? Hierarchy1Name { get; set; }
    public string? Hierarchy2Name { get; set; }
    [Required]
    public string? VduGroupName { get; set; }
    public string? AlarmGroupName { get; set; }
    public string? OtdName { get; set; }
    public Otd? Otd { get; set; }
    public string? AcknowledgeAllowedName { get; set; }
    public string? AlwaysVisibleName { get; set; }
    public string? NodeName { get; set; }
    [Required]
    public string? CabinetName { get; set; }

    [Required]
    [StringLength(20, ErrorMessage = "Object name is too long")]
    public string? FullObjectName
    {
        get
        {
            return $"{SfiNumber}_{MainEqNumber}_{EqNumber}";
        }
    }

    public List<TagModel>? Tags { get; set; }

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
            return !String.IsNullOrEmpty(Hierarchy1Name) &&
                    !String.IsNullOrEmpty(OtdName) &&
                    !String.IsNullOrEmpty(NodeName) &&
                    _mandatoryConnectionsResolved;
        }
    }

    public bool ReadyForHMIGeneration
    {
        get
        {
            return !String.IsNullOrEmpty(Hierarchy1Name) &&
                    !String.IsNullOrEmpty(Hierarchy2Name) &&
                    !String.IsNullOrEmpty(OtdName) &&
                    !String.IsNullOrEmpty(NodeName);
        }
    }

    public bool ReadyForPreliminaryPLCGeneration
    {
        get
        {
            return !String.IsNullOrEmpty(OtdName) && !String.IsNullOrEmpty(NodeName);
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
