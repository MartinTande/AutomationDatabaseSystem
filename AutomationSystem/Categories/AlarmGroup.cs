using System.Data;
using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using AutomationSystem.Classes;

namespace AutomationSystem.Categories
{
    public class AlarmGroup : Category
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public List<string> GetNames()
        {
            return base.GetNames("AlarmGroupName", "ALARM_GROUP");
        }
    }
}
