using System.Collections.Generic;
using AutomationSystem.Categories;

namespace AutomationSystemLibrary.Categories
{
    public class AlwaysVisible : Category
    {
        public int Id { get; set; }
        public string Location { get; set; }

        public List<string> GetNames()
        {
            return base.GetNames("AlwaysVisibleLocation", "ALWAYS_VISIBLE");
        }
    }
}
