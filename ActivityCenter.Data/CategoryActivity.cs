using System;
using System.Collections.Generic;
using System.Text;

namespace ActivityCenter.Data
{
	public class CategoryActivity
	{
		public int ActivityId { get; set; }
		public int CategoryId { get; set; }
		public Activity Activity { get; set; }
		public Category Category { get; set; }
	}
}
