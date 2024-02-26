using AdventureLoggerBackend.Models;
using AdventureLoggerBackend.Data;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Data.Common;


namespace AdventureLoggerBackend.Controllers
{
    public class HomeController : Controller
    {

        private readonly AdventureLoggerBackendContext _context;
        private readonly ILogger<HomeController> _logger;


        public HomeController(AdventureLoggerBackendContext context, ILogger<HomeController> logger)
        {
            _context = context;
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
            Console.WriteLine("Login Method Cake");
            _context.PrintDatabaseContents();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return View("login");
            }
            
            // If authentication is successful, redirect to Home/Index with a welcome message
            if (IsValidUser(username, password))
            {
                return RedirectToAction("Index", "Home", new { username = username });
            }

            // If authentication fails, return to the login page with an error message
            ViewBag.ErrorMessage = "Invalid username or password.";
            return View("login");
        }
        
        private bool IsValidUser(string username, string password)
        {


            Console.WriteLine("Login Method awdajwnduinin");
            _context.PrintDatabaseContents();
            // Retrieve user from the database based on the provided username
            var user = _context.User.FirstOrDefault(u => u.UserName == username);

            // Check if user exists and if the provided password matches the stored password
            if (user != null && user.Password == password)
            {
                return true; // User authenticated successfully
            }

            return false; // Authentication failed
        }


        //public IActionResult Logout()
        //{
            
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
    }
}