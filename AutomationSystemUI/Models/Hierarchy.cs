using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSystemUI.Models
{
    internal class Hierarchy : IHierarchy
    {

        public string HierarchyName { get; set; }

        public List<IHierarchy> PictureHierarchy { get; set; }

        public Hierarchy()
        {
            PictureHierarchy = new List<IHierarchy>();
        }
    }
}
