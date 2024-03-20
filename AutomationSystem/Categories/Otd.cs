using AutomationSystem.Classes;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSystem.Categories
{
    public class Otd : Category
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public List<string> GetNames()
        {
            return base.GetNames("OtdName", "OTD");
        }
    }
}
