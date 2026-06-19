using Microsoft.AspNetCore.Mvc;
using HeartDiseasePrediction.Data;
using HeartDiseasePrediction.Models;

namespace HeartDiseasePrediction.Controllers
{
    public class DoctorAccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DoctorAccountController(
            ApplicationDbContext context)
        {
            _context = context;
        }

        // REGISTER PAGE
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(
            Doctor model,
            string ConfirmPassword)
        {
            // Check existing email
            var existingDoctor = _context.Doctors
                .FirstOrDefault(x => x.Email == model.Email);

            if (existingDoctor != null)
            {
                ViewBag.Message = "Email already exists";
                return View();
            }

            // Password match
            if (model.Password != ConfirmPassword)
            {
                ViewBag.Message = "Passwords do not match";
                return View();
            }

            // Save doctor
            _context.Doctors.Add(model);

            _context.SaveChanges();

            return RedirectToAction("Login");
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
            var doctor = _context.Doctors
                .FirstOrDefault(x =>
                    x.Email == email &&
                    x.Password == password);

            if (doctor != null)
            {
                // Sessions
                HttpContext.Session.SetInt32(
                    "DoctorId",
                    doctor.Id
                );

                HttpContext.Session.SetString(
                    "DoctorName",
                    doctor.DoctorName
                );

                return RedirectToAction(
                    "Dashboard",
                    "Doctor"
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