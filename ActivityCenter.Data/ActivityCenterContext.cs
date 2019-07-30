using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ActivityCenter.Data
{
	public class ActivityCenterContext : DbContext
	{
		public DbSet<User> Users { get; set; }
		public DbSet<Activity> Activities { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<CategoryActivity> CategoriesActivities { get; set; }
		public DbSet<GroupSize> GroupSize { get; set; }
		private string _connectionString;
		public ActivityCenterContext(string connectionString)
		{
			_connectionString = connectionString;
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(_connectionString);
		}
	}
}
