using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationSystemLibrary.Data;
using AutomationSystemLibrary.Models;

namespace AutomationSystemUI.Models
{
    public class TagObjectController
    {
        public List<TagObjectModel> GetById(int id)
        {
            ObjectDataManager data = new ObjectDataManager();

            return data.GetTagObjectById(id);
        }
    }
}
