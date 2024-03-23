﻿using System.Collections.Generic;
using AutomationSystem.Categories;

namespace AutomationSystemLibrary.Categories
{
    public class Cabinet : Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<string> GetNames()
        {
            return base.GetNames("CabinetName", "CABINET");
        }
    }
}
