using System;
using System.Collections.Generic;
using System.Text;

namespace ActivityCenter.Data
{
	public class Activity
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public DateTime DatePosted { get; set; }
		public bool? Indoor { get; set; }
		public GroupSize Size { get; set; }
		public List<CategoryActivity> CategoriesActivities { get; set; }

		public enum GroupSize
		{
			GoodForAnyGroupSize,
			Small,
			Medium,
			Large,
		}
	}	
}
