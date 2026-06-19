using HeartDiseasePrediction.Data;
using HeartDiseasePrediction.Models;
using Microsoft.AspNetCore.Mvc;

namespace HeartDiseasePrediction.Controllers
{
    public class DoctorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DoctorController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Dashboard()
        {
            // CHECK SESSION
            if (HttpContext.Session.GetInt32("DoctorId") == null)
            {
                return RedirectToAction(
                    "Login",
                    "DoctorAccount"
                );
            }

            var predictions = _context.Predictions
                .OrderByDescending(x => x.Id)
                .ToList();

            return View(predictions);
        }
        // GET METHOD

        public IActionResult AddRecommendation(int id)
        {
            var prediction =
                _context.Predictions.Find(id);

            return View(prediction);
        }

        // POST METHOD

        [HttpPost]
        public IActionResult AddRecommendation(Prediction model)
        {
            var prediction =
                _context.Predictions.Find(model.Id);

            if (prediction != null)
            {
                prediction.DoctorRecommendation =
                    model.DoctorRecommendation;

                prediction.SuggestedMedicine =
                    model.SuggestedMedicine;

                prediction.SuggestedTests =
                    model.SuggestedTests;
                prediction.RecommendedBy =
                HttpContext.Session.GetString("DoctorName");

                prediction.RecommendationDate =
                    DateTime.Now;

                _context.SaveChanges();
            }

            return RedirectToAction("Dashboard");
        }
    }
}