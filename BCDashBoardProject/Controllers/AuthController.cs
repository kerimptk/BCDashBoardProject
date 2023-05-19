using BCDashBoardProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BCDashBoardProject.Controllers
{
    public class AuthController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BCSCDBContext _dbContext;

        public AuthController(ILogger<HomeController> logger, BCSCDBContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Login(User user)
        {
            if (user.UserName == null && user.Password == null && user.Id == 0)
            {
                return View();
            }
            else
            {
                var query = _dbContext.Users.Where(x => x.UserName.Equals(user.UserName) && x.Password.Equals(user.Password)).FirstOrDefault();
                if (query == null)
                {
                    return View();
                }
                else
                { 
                    HttpContext.Session.SetString("UserName", query.UserName);
                    return RedirectToAction("Index", "Home");
                }
            }
        }
    }
}