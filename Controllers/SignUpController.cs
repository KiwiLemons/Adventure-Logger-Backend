// SignUpController.cs
using Microsoft.AspNetCore.Mvc;
using AdventureLoggerBackend.Models;
using System.Security.Cryptography;
using AdventureLoggerBackend.Data;



public class SignUpController : Controller
{
    private readonly UserService _userService;
    private readonly AdventureLoggerBackendContext _context;

    public SignUpController(AdventureLoggerBackendContext context)
    {
        _context = context;
        _userService = new UserService(context);
    }
    [HttpGet]
    public IActionResult Index()
    {
        return View("SignUp");
    }

    [HttpPost]
    public IActionResult Index(UserSignUpViewModel model)
    {
        if (ModelState.IsValid)
        {
            if (!_userService.IsUsernameUnique(model.Username))
            {
                ModelState.AddModelError("Username", "Username is already taken.");
                return View(model);
            }

            if (!_userService.IsEmailUnique(model.Email))
            {
                ModelState.AddModelError("Email", "Email address is already registered!");
                return View(model);
            }

            string hashedPassword = HashPassword(model.Password);

            var user = new User
            {
                UserName = model.Username,
                Email = model.Email,
                Password = hashedPassword
            };

            _userService.RegisterUser(user);

            //confirmation email here
            //figure out

            return RedirectToAction("SignUpSuccess");
        }

        // If model state is not valid, return the view with validation errors
        return View(model);
    }

    private string HashPassword(string password)
    {
        /*
        // Generate a random salt
        byte[] saltBytes = new byte[16];
        using (var rng = new RNGCryptoServiceProvider())
        {
            rng.GetBytes(saltBytes);
        }

        // Convert the salt to a base64-encoded string
        string salt = Convert.ToBase64String(saltBytes);

        // Create the Rfc2898DeriveBytes object with the password and salt
        var pbkdf2 = new Rfc2898DeriveBytes(password, saltBytes, 10000, HashAlgorithmName.SHA256);

        // Get the derived key bytes
        byte[] hashBytes = pbkdf2.GetBytes(32); // 32 bytes = 256 bits

        // Combine the salt and hash bytes into a single byte array
        byte[] combinedBytes = new byte[saltBytes.Length + hashBytes.Length];
        Array.Copy(saltBytes, 0, combinedBytes, 0, saltBytes.Length);
        Array.Copy(hashBytes, 0, combinedBytes, saltBytes.Length, hashBytes.Length);

        // Convert the combined byte array to a base64-encoded string
        string hashedPassword = Convert.ToBase64String(combinedBytes);

        return hashedPassword;
        */

        return password;
    }
}
