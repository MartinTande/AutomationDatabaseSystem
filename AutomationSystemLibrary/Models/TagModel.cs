using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSystemLibrary.Models
{
    public class TagModel
    {
        public int Number { get; set; }
        public string Description { get; set; }
        public string SignalType { get; set; }
        public string IOType { get; set; }
        public string LowLimit { get; set; }
        public string HighLimit { get; set; }
        public string HighHighLimit { get; set; }
        public string LowLowLimit { get; set; }
        public string Limit { get; set; }
        public string SWPath { get; set; }

    }
}
