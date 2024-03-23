using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSystemLibrary.Models
{
    public class TagObjectModel
    {
        public int Id { get; set; }
        public int SfiNumber { get; set; }
        public string MainEqNumber { get; set; }
        public string EqNumber { get; set; }
        public string ObjectDescription { get; set; }
        public string Hierarchy_1 { get; set; }
        public string Hierarchy_2 { get; set; }
        public string VduGroup { get; set; }
        public string AlarmGroup { get; set; }
        public string Otd { get; set; }
        public string AcknowledgeAllowed { get; set; }
        public string AlwaysVisible { get; set; }
        public string Node { get; set; }
        public string Cabinet { get; set; }
        public string DataBlock { get; set; }

        public string FullObjectName
        {
            get
            {
                return $"{SfiNumber}_{MainEqNumber}_{EqNumber}";
            }
        }
    }
}
