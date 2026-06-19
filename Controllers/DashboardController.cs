using Microsoft.AspNetCore.Mvc;
using HeartDiseasePrediction.Data;

namespace HeartDiseasePrediction.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var predictions = _context.Predictions.ToList();

            ViewBag.TotalPredictions = predictions.Count;

            ViewBag.HighRisk = predictions
                .Count(p => p.Result.Contains("High"));

            ViewBag.LowRisk = predictions
                .Count(p => p.Result.Contains("Low"));

            return View(predictions);
        }

    }
}