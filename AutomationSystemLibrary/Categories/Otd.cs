using System.Collections.Generic;
using AutomationSystem.Categories;

namespace AutomationSystemLibrary.Categories
{
    public class Otd : Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<string> GetNames()
        {
            return base.GetNames("OtdName", "OTD");
        }
    }
}
