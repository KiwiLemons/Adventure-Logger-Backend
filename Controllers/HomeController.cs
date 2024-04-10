using AdventureLoggerBackend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Build.Framework;
using AdventureLoggerBackend.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AdventureLoggerBackend.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AdventureLoggerBackendContext _context;

        public HomeController(ILogger<HomeController> logger, AdventureLoggerBackendContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index(string username)
        {
            ViewBag.Username = username; // Pass username to the view
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

    
        public IActionResult Login(LoginViewModel lvm)
        {
            string username = lvm.Username;
            string password = lvm.Password;

            // If authentication is successful, redirect to Home/Index with a welcome message
            if (IsValidUser(username, password))
            {
                return RedirectToAction("Index", "Home", new { username = username });
            }


            // If authentication fails, return to the login page
            return View();
        }

        // Replace this with your actual authentication logic
         private bool IsValidUser(string username, string password)
        {
            // Retrieve user from the database based on the provided username
            var user = _context.User.FirstOrDefault(u => u.UserName == username);

            // Check if user exists and if the provided password matches the stored password
            if (user != null && user.Password == password)
            {
                return true; // User authenticated successfully
            }

            return false; // Authentication failed
        }


        public IActionResult Logout()
        {
            string username = null;
            return RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
    }
}