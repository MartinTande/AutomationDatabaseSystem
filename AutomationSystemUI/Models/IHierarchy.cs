using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSystemUI.Models
{
    public interface IHierarchy
    {
        string HierarchyName { get; }
        List<IHierarchy> PictureHierarchy { get; }
    }
}
