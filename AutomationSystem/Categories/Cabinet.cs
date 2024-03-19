﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSystem.Categories
{
    public class Cabinet : Category
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public List<string> GetNames()
        {
            return base.GetNames("select CabinetName from CABINET");
        }
    }
}
