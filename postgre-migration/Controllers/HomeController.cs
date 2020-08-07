using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using postgre_migration.Context;
using postgre_migration.Entities;
using postgre_migration.Models;
using System.Diagnostics;
using System.Threading.Tasks;

namespace postgre_migration.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly BlogContext _context;

		public HomeController(ILogger<HomeController> logger, BlogContext context)
		{
			_logger = logger;
			_context = context;
		}

		public async Task<IActionResult> Index()
		{
			var user = new User
			{
				Email = "admin@admin.com",
				Password = "123456",
				UserName = "admin"
			};
			_context.Add(user);
			await _context.SaveChangesAsync();

			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
