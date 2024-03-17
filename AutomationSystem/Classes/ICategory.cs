using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSystem.Classes
{
    public interface ICategory<T>
    {
        public List<string> GetNames();

        public List<T> GetTypes();

        public List<string> GetNames(string category);
    }
}
