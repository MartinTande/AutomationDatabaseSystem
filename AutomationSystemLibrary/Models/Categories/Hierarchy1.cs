using System.Collections.Generic;
using AutomationSystem.Categories;

namespace AutomationSystemLibrary.Categories
{
    public class Hierarchy1 : ICategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Hierarchy2> hierarchy2Names { get; set; }
    }
}
