using Microsoft.AspNetCore.Mvc;
using HeartDiseasePrediction.Data;

namespace HeartDiseasePrediction.Controllers
{
    public class AdminAccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminAccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        // LOGIN PAGE
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(
            string email,
            string password)
        {
            var admin = _context.Admins.FirstOrDefault(x =>
                x.Email == email &&
                x.Password == password);

            if (admin != null)
            {
                HttpContext.Session.SetString(
                    "Admin",
                    admin.Email
                );

                return RedirectToAction(
                    "Dashboard",
                    "Admin"
                );
            }

            ViewBag.Message = "Invalid Credentials";

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