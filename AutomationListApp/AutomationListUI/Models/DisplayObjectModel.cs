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
    [StringLength(4, ErrorMessage = "SfiNumber is too long")]
    public string? SfiNumber { get; set; }
    [Required]
    [ObjectNameValidator]
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
    public string? Revision { get; set; }

    [Required]
	[StringLength(20, ErrorMessage = "Object name is too long")]
    [ObjectNameValidator]
    [Editable(false)]
	public string? FullObjectName
    {
        get
        {
            if (string.IsNullOrEmpty(EqNumber))
            {
                return $"{SfiNumber}_{MainEqNumber}";
			}
            return $"{SfiNumber}_{MainEqNumber}_{EqNumber}";
        }
        set
        {
		}
	}

    public bool AutoAddon { get; set; } = false;    // Flag used for adding software tags for Auto Start/Stop Mode AddOn for pumps and valves

    [ReadOnly(true)]
    [Editable(false)]
	public DateTime? LastModified { get; set; }

    public List<DisplayTagModel>? Tags { get; set; } = new();

    [ReadOnly(true)]
	[Editable(false)]
	public bool ReadyForPLCGeneration
    {
        get
        {
            bool _mandatoryConnectionsResolved = false;
            if (Otd == null || OtdInterface == null)
            {
                return false;
            }
            foreach (OtdInterface currentInterface in OtdInterface.Interface)
            {
                if (currentInterface.IsOptional)
                {
                    continue;
                }
                _mandatoryConnectionsResolved = IsRequiredTagSuffixPresent(currentInterface.Suffix);
            }
            return !string.IsNullOrEmpty(Hierarchy1) &&
                    !string.IsNullOrEmpty(Otd) &&
                    !string.IsNullOrEmpty(Node) &&
                    _mandatoryConnectionsResolved;
        }
    }

    [ReadOnly(true)]
	[Editable(false)]
	public bool ReadyForHMIGeneration => !string.IsNullOrEmpty(Hierarchy1) &&
					                        !string.IsNullOrEmpty(Hierarchy2) &&
					                        !string.IsNullOrEmpty(Otd) &&
					                        !string.IsNullOrEmpty(Node);
	[Editable(false)]
    [ReadOnly(true)]
	public bool ReadyForPreliminaryPLCGeneration => !string.IsNullOrEmpty(Otd) && !string.IsNullOrEmpty(Node);

	private bool IsRequiredTagSuffixPresent(string suffix)
    {
        suffix = suffix.Replace("<ObjectTag>_","");
        if (Tags == null)
        {
            return false;
        }
        List<string> tagSuffixes = Tags.Select(tag => tag.EqSuffix).ToList();
        if (tagSuffixes.Contains(suffix))
        {
            return true;
        }
        return false;
    }
}
