using AdventureLoggerBackend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;


namespace AdventureLoggerBackend.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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

    
        public IActionResult Login(string username, string password)
        {
            // Your authentication logic here
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
            // Simplified validation logic, replace with actual authentication
            return !string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password);
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