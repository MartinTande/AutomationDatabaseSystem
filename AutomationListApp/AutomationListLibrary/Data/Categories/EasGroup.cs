using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationListLibrary.Data.Categories;

public class EasGroup : ICategory
{
	public int Id { get; set; }
	public string? Name { get; set; }
}
