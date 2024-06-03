using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSystem.Models.Data.Categories
{
    public class OtdInterface : ICategory
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Suffix { get; set; }
        public string? DataType { get; set; }
        public string? InterfaceType { get; set; }
        public bool IsOptional { get; set; }
    }
}
