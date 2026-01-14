using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using BCrypt.Net;
using Ganss.Xss;
using SecureStudentHub.Data;
using SecureStudentHub.Models;
using SecureStudentHub.Services;

namespace SecureStudentHub.Controllers
{
    public class AuthController : Controller
    {
        private readonly AppDbContext _context;
        private readonly EncryptionService _encryptionService;
        private readonly HtmlSanitizer _sanitizer;

        public AuthController(AppDbContext context)
        {
            _context = context;
            _encryptionService = new EncryptionService();
            _sanitizer = new HtmlSanitizer(); 
        }

        
        public IActionResult Register()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken] 
        public async Task<IActionResult> Register(string username, string email, string password, string ssn)
        {
            
            username = _sanitizer.Sanitize(username);
            email = _sanitizer.Sanitize(email);

            
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(password, workFactor: 11);

            
            string encryptedSSN = _encryptionService.Encrypt(ssn);

            var newUser = new User
            {
                Username = username,
                Email = email,
                PasswordHash = passwordHash,
                EncryptedSSN = encryptedSSN,
                Role = "User" 
            };

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return RedirectToAction("Login");
        }

        
        public IActionResult Login()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string username, string password)
        {
            
            var user = _context.Users.SingleOrDefault(u => u.Username == username);

            
            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, user.Role)
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(20) 
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Invalid Username or Password";
            return View();
        }

        
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}