using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSystemLibrary
{
    public static class GlobalConfig
    {
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["AUTOMATIONSYSTEM"].ConnectionString;
        }
    }
}
