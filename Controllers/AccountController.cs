using Microsoft.AspNetCore.Mvc;
using HeartDiseasePrediction.Data;
using HeartDiseasePrediction.Models;

namespace HeartDiseasePrediction.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        // REGISTER PAGE
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User model, string ConfirmPassword)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            // Email already exists
            var existingUser = _context.Users
                .FirstOrDefault(x => x.Email == model.Email);

            if (existingUser != null)
            {
                ViewBag.Message = "Email already exists";
                return View();
            }

            // Password mismatch
            if (model.Password != ConfirmPassword)
            {
                ViewBag.Message = "Passwords do not match";
                return View();
            }

            // Save user
            _context.Users.Add(model);
            _context.SaveChanges();

            return RedirectToAction("Login");
        }

        // LOGIN PAGE
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                ViewBag.Message = "Email is required";
                return View();
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                ViewBag.Message = "Password is required";
                return View();
            }   
            var user = _context.Users.FirstOrDefault(x =>
                x.Email == email &&
                x.Password == password);

            if (user != null)
            {
                // Session
                HttpContext.Session.SetInt32("UserId", user.Id);

                HttpContext.Session.SetString(
                    "UserName",
                    user.Name
                );

                HttpContext.Session.SetString(
                    "UserRole",
                    user.Role
                );

                return RedirectToAction(
                    "Index",
                    "Home"
                );
            }

            ViewBag.Message = "Invalid Email or Password";

            return View();
        }

        // LOGOUT
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Login");
        }
    }
}