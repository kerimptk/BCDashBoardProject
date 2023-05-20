using BCDashBoardProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
            // Oturum açıkken yeniden login olmak istiyorsa ana sayfaya yönlendirildi.
            var isLogin = HttpContext.Session.Keys.FirstOrDefault();
            if (isLogin != null && isLogin.Equals("UserName"))
            {
                return RedirectToAction("Index", "Home");
            }
            // ilk girişte bu bilgiler null geldiği için logine yönlendirildi. 
            if (user.UserName == null && user.Password == null && user.Id == 0)
            {
                return View();
            }
            // Null değil ise kullanıcı kontrolü yapılarak sessiyona string set edilerek login işlemi tamamlandıç
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
        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("UserName");
            return RedirectToAction("Login", "Auth");
        }
    }
}