using AutomationListLibrary.Data;
using AutomationListUI.Validators;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace AutomationListUI.Models;

public class DisplayObjectModel
{
    [ReadOnly(true)]
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
    public string? EasGroup { get; set; }
    public string? Otd { get; set; }
    public Otd? OtdInterface { get; set; }
    public string? ObjectType { get; set; }
    public string? AcknowledgeAllowed { get; set; }
    public string? AlwaysVisible { get; set; }
    public string? Node { get; set; }
    [Required]
    public string? Cabinet { get; set; }
	[Required]
	[StringLength(20, ErrorMessage = "Object name is too long")]
    [ObjectNameValidator]
    [Editable(false)]
	public string? FullObjectName => $"{SfiNumber}_{MainEqNumber}_{EqNumber}";
    public DateTime? LastModified { get; set; }

    public List<DisplayTagModel>? Tags { get; set; }

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
            return !string.IsNullOrEmpty(Hierarchy1) &&
                    !string.IsNullOrEmpty(Otd) &&
                    !string.IsNullOrEmpty(Node) &&
                    _mandatoryConnectionsResolved;
        }
    }

	public bool ReadyForHMIGeneration => !string.IsNullOrEmpty(Hierarchy1) &&
					                        !string.IsNullOrEmpty(Hierarchy2) &&
					                        !string.IsNullOrEmpty(Otd) &&
					                        !string.IsNullOrEmpty(Node);

	public bool ReadyForPreliminaryPLCGeneration => !string.IsNullOrEmpty(Otd) && !string.IsNullOrEmpty(Node);

	private bool LookupTagSuffixesAgaintOtdInterface(string suffix)
    {
        if (Tags == null)
        {
            return false;
        }
        foreach (DisplayTagModel tag in Tags)
        {
            if (tag.EqSuffix.Equals(suffix))
            {
                return true;
            }
        }
        return false;
    }
}
