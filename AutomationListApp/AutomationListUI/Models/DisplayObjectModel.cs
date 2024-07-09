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
    public string? Hierarchy1 { get; set; }
    public string? Hierarchy2 { get; set; }
    [Required]
    public string? VduGroup { get; set; }
    public string? AlarmGroup { get; set; }
    public string? Otd { get; set; }
    public Otd? OtdInterface { get; set; }
    public string? AcknowledgeAllowed { get; set; }
    public string? AlwaysVisible { get; set; }
    public string? Node { get; set; }
    [Required]
    public string? Cabinet { get; set; }

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
            foreach (OtdInterface currentInterface in OtdInterface.Interface)
            {
                if (currentInterface.IsOptional)
                {
                    continue;
                }
                _mandatoryConnectionsResolved = LookupTagSuffixesAgaintOtdInterface(currentInterface.Suffix);
            }
            return !String.IsNullOrEmpty(Hierarchy1) &&
                    !String.IsNullOrEmpty(Otd) &&
                    !String.IsNullOrEmpty(Node) &&
                    _mandatoryConnectionsResolved;
        }
    }

    public bool ReadyForHMIGeneration
    {
        get
        {
            return !String.IsNullOrEmpty(Hierarchy1) &&
                    !String.IsNullOrEmpty(Hierarchy2) &&
                    !String.IsNullOrEmpty(Otd) &&
                    !String.IsNullOrEmpty(Node);
        }
    }

    public bool ReadyForPreliminaryPLCGeneration
    {
        get
        {
            return !String.IsNullOrEmpty(Otd) && !String.IsNullOrEmpty(Node);
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
