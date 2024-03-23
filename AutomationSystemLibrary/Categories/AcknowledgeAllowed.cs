using System.Collections.Generic;
using AutomationSystem.Categories;

namespace AutomationSystemLibrary.Categories
{
    public class AcknowledgeAllowed : Category
    {
        public int Id { get; set; }
        public string Location { get; set; }

        public List<string> GetNames()
        {
            return base.GetNames("AcknowledgeAllowedLocation", "ACKNOWLEDGE_ALLOWED");
        }
    }
}
