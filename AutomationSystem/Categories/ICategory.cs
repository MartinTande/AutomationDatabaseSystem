﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSystem.Categories
{
    public interface ICategory<T>
    {
        public List<string> GetNames();

        public List<string> GetNames(string category);
    }
}
