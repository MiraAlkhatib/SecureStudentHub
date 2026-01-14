using Microsoft.AspNetCore.Mvc;
using SecureStudentHub.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace SecureStudentHub.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Authorize] 
        public IActionResult Index()
        {
            
            var username = User.Identity.Name;
            var role = User.FindFirst(ClaimTypes.Role)?.Value;

            ViewBag.Username = username;
            ViewBag.Role = role;
            ViewBag.Message = "You have successfully authenticated via Secure Cookie.";

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
