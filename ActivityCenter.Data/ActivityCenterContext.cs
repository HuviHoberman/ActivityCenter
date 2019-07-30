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

		public ActivityCenterContext(DbContextOptions options) : base(options)
		{
		}

		private string _connectionString;
		public ActivityCenterContext(string connectionString)
		{
			_connectionString = connectionString;
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(_connectionString);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Activity>()
				.ToTable("Activities");

			modelBuilder.Entity<Activity>()
				.Property(a => a.Size)
				.HasConversion<string>();

			base.OnModelCreating(modelBuilder);

			foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
			{
				relationship.DeleteBehavior = DeleteBehavior.Restrict;
			}

			modelBuilder.Entity<CategoryActivity>()
				.HasKey(ca => new { ca.CategoryId, ca.ActivityId });

			modelBuilder.Entity<CategoryActivity>()
				.HasOne(ca => ca.Category)
				.WithMany(c => c.CategoriesActivities)
				.HasForeignKey(c => c.CategoryId);

			modelBuilder.Entity<CategoryActivity>()
				.HasOne(ca => ca.Activity)
				.WithMany(a => a.CategoriesActivities)
				.HasForeignKey(a => a.ActivityId);
		}
	}
}
