using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSystemUI.Models
{
    public interface IItem
    {
        string Name { get; }
        List<IItem> SubItem { get; }
    }
}
