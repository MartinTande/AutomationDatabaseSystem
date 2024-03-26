using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSystemLibrary.Models
{
    public class TagObjectModel
    {
        public int ObjectId { get; set; }
        public int SfiNumber { get; set; }
        public string MainEqNumber { get; set; }
        public string EqNumber { get; set; }
        public string ObjectDescription { get; set; }
        public string Hierarchy1Name { get; set; }
        public string Hierarchy2Name { get; set; }
        public string VduGroupName { get; set; }
        public string AlarmGroupName { get; set; }
        public string OtdName { get; set; }
        public string AcknowledgeAllowedLocation { get; set; }
        public string AlwaysVisibleLocation { get; set; }
        public string NodeName { get; set; }
        public string CabinetName { get; set; }
        public string DataBlockName { get; set; }

        public string FullObjectName
        {
            get
            {
                return $"{SfiNumber}_{MainEqNumber}_{EqNumber}";
            }
        }
    }
}
