using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ActivityCenter.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace ActivityCenter.Web.Controllers
{
	public class HomeController : Controller
	{

		private IHostingEnvironment _environment;
		private string _connectionString;

		public HomeController(IHostingEnvironment environment, IConfiguration configuration)
		{
			_environment = environment;
			_connectionString = configuration.GetConnectionString("ConStr");
		}

		public IActionResult Index()
		{
			ActivityRepos repository = new ActivityRepos(_connectionString);
			return View(repository.GetActivities());
		}
	}
	}