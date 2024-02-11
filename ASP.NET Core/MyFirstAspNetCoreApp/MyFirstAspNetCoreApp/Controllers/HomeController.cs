using Microsoft.AspNetCore.Mvc;
using MyFirstAspNetCoreApp.Models;
using System.Diagnostics;
using MyFirstAspNetCoreApp.Data;
using MyFirstAspNetCoreApp.ViewModels.Home;

namespace MyFirstAspNetCoreApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext dbContext;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {  
            IndexViewModel viewModel = new IndexViewModel()
            {
                UsersCount = this.dbContext.Users.Count(),
                ProcessorsCount = Environment.ProcessorCount,
                CurrentDate = DateTime.Now.ToUniversalTime(),
            };
            return View(viewModel);
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
