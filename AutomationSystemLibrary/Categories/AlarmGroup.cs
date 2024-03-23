using System.Collections.Generic;
using AutomationSystem.Categories;

namespace AutomationSystemLibrary.Categories
{
    public class AlarmGroup : Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<string> GetNames()
        {
            return base.GetNames("AlarmGroupName", "ALARM_GROUP");
        }
    }
}
