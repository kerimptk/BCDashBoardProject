using BCDashBoardProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BCDashBoardProject.Controllers
{
    public class AuthController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public AuthController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}