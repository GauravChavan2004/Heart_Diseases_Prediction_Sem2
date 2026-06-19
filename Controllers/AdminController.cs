using Microsoft.AspNetCore.Mvc;
using HeartDiseasePrediction.Data;
using System.Linq;

namespace HeartDiseasePrediction.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        // DASHBOARD
        public IActionResult Dashboard()
        {
            // CHECK SESSION
            if (HttpContext.Session.GetString("Admin") == null)
            {
                return RedirectToAction(
                    "Login",
                    "AdminAccount"
                );
            }

            ViewBag.TotalUsers = _context.Users.Count();

            ViewBag.TotalDoctors = _context.Doctors.Count();

            // materialize predictions so we can safely run LINQ-to-Objects
            var predictions = _context.Predictions
                .OrderByDescending(x => x.Id)
                .ToList();

            int totalPredictions = predictions.Count;

            int highRisk = predictions.Count(x => !string.IsNullOrEmpty(x.Result) && x.Result.Contains("High"));
            int lowRisk = predictions.Count(x => !string.IsNullOrEmpty(x.Result) && x.Result.Contains("Low"));

            ViewBag.TotalPredictions = totalPredictions;
            ViewBag.HighRisk = highRisk;
            ViewBag.LowRisk = lowRisk;

            // RISK %
            double riskPercentage = 0;
            if (totalPredictions > 0)
            {
                riskPercentage = ((double)highRisk / totalPredictions) * 100;
            }
            ViewBag.RiskPercentage = Math.Round(riskPercentage, 2);

            // MODEL ACCURACY (placeholder - compute if you have real metric)
            ViewBag.ModelAccuracy = 87;

            // GENDER DATA
            ViewBag.MaleCount = predictions.Count(x => x.Sex == "Male");
            ViewBag.FemaleCount = predictions.Count(x => x.Sex == "Female");

            // AVERAGES
            ViewBag.AvgBP = predictions.Any() ? Math.Round(predictions.Average(x => x.RestingBP), 2) : 0;
            ViewBag.AvgCholesterol = predictions.Any() ? Math.Round(predictions.Average(x => x.Cholesterol), 2) : 0;
            ViewBag.AvgHeartRate = predictions.Any() ? Math.Round(predictions.Average(x => x.MaxHR), 2) : 0;

            // Render the shared dashboard view and pass the model (predictions)
            return View("~/Views/Dashboard/Index.cshtml", predictions);
        }

        // USERS
        public IActionResult Users()
        {
            var users = _context.Users.ToList();

            return View(users);
        }

        // DOCTORS
        public IActionResult Doctors()
        {
            var doctors = _context.Doctors.ToList();

            return View(doctors);
        }

        // PREDICTIONS
        public IActionResult Predictions()
        {
            var predictions = _context.Predictions
                .OrderByDescending(x => x.Id)
                .ToList();

            return View(predictions);
        }

        // DELETE USER
        public IActionResult DeleteUser(int id)
        {
            var user = _context.Users.Find(id);

            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }

            return RedirectToAction("Users");
        }

        // DELETE DOCTOR
        public IActionResult DeleteDoctor(int id)
        {
            var doctor = _context.Doctors.Find(id);

            if (doctor != null)
            {
                _context.Doctors.Remove(doctor);
                _context.SaveChanges();
            }

            return RedirectToAction("Doctors");
        }
    }
}