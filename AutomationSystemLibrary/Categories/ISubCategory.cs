﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSystem.Categories
{
    public interface ISubCategory
    {
        List<string> GetNames(string category);
    }
}
