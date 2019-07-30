using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ActivityCenter.Data
{
	public class ActivityRepos
	{
		private readonly string _connectionString;

		public ActivityRepos(string connectionString)
		{
			_connectionString = connectionString;
		}

		public List<Activity> GetActivities()
		{
			using (var context = new ActivityCenterContext(_connectionString))
			{
				return context.Activities.OrderByDescending(a => a.DatePosted).ToList();
			}
		}

		public List<Category> GetCategories()
		{
			using (var context = new ActivityCenterContext(_connectionString))
			{
				return context.Categories.OrderBy(c => c.Name).ToList();
			}
		}
	}
}
