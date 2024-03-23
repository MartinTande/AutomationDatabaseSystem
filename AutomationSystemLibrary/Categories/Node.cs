using System.Collections.Generic;
using AutomationSystem.Categories;

namespace AutomationSystemLibrary.Categories
{
    public class Node : Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<string> GetNames()
        {
            return base.GetNames("NodeName", "NODE");
        }
    }
}
