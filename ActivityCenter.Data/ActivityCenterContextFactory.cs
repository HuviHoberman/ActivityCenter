using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ActivityCenter.Data
{
	class ActivityCenterContextFactory : IDesignTimeDbContextFactory<ActivityCenterContext>
	{
		public ActivityCenterContext CreateDbContext(string[] args)
		{
			var config = new ConfigurationBuilder()
				.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), $"..{Path.DirectorySeparatorChar}ActivityCenter.Web"))
				.AddJsonFile("appsettings.json")
				.AddJsonFile("appsettings.local.json", optional: true, reloadOnChange: true).Build();

			return new ActivityCenterContext(config.GetConnectionString("ConStr"));
		}
	}
}
