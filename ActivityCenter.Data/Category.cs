using System;
using System.Collections.Generic;
using System.Text;

namespace ActivityCenter.Data
{
	public class Category
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public List<CategoryActivity> CategoriesActivities { get; set; }
	}
}
