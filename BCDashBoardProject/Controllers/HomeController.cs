using BCDashBoardProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BCDashBoardProject.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BCSCDBContext _dbContext;

        public HomeController(ILogger<HomeController> logger, BCSCDBContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }
         
        public IActionResult Index()
        {
            _dbContext.
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