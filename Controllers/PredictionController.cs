using Microsoft.AspNetCore.Mvc;
using HeartDiseasePrediction.Models;
using HeartDiseasePrediction.Data;
using Newtonsoft.Json;
using System.Text;
using Rotativa.AspNetCore;

namespace HeartDiseasePrediction.Controllers
{
    public class PredictionController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly ApplicationDbContext _context;

        public PredictionController(ApplicationDbContext context)
        {
            _httpClient = new HttpClient();
            _context = context;
        }

        public IActionResult Predict()
        {
            return View();
        }

       

        [HttpPost]
        public async Task<IActionResult> Predict(Prediction model)
        {
            var mlData = new
            {
                Age = model.Age,
                Sex = model.Sex,
                ChestPainType = model.ChestPainType,
                RestingBP = model.RestingBP,
                Cholesterol = model.Cholesterol,
                FastingBS = model.FastingBS,
                RestingECG = model.RestingECG,
                MaxHR = model.MaxHR,
                ExerciseAngina = model.ExerciseAngina,
                Oldpeak = model.Oldpeak,
                ST_Slope = model.ST_Slope
            };

            var jsonData =
                JsonConvert.SerializeObject(mlData);

            var content = new StringContent(
                jsonData,
                Encoding.UTF8,
                "application/json"
            );

            var response = await _httpClient.PostAsync(
                "http://127.0.0.1:5000/predict",
                content
            );

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();

                dynamic data = JsonConvert.DeserializeObject(result);

                model.Result = data.prediction;

                // CHECK LOGIN SESSION

                if (HttpContext.Session.GetInt32("UserId") == null)
                {
                    return RedirectToAction(
                        "Login",
                        "Account"
                    );
                }

                // STORE LOGGED-IN USER ID

                model.UserId =
                    HttpContext.Session.GetInt32("UserId") ?? 0;
                model.PatientName =
                    model.PatientName;
                // SAVE PREDICTION

                _context.Predictions.Add(model);
                await _context.SaveChangesAsync();

                ViewBag.Result = model.Result;
            }
            else
            {
                ViewBag.Result = "Prediction Failed";
            }

            return View(model);
        }

        public IActionResult History()
        {
            var userId =
            HttpContext.Session.GetInt32("UserId");

            var predictions = _context.Predictions
                .Where(p => p.UserId == userId)
                .OrderByDescending(p => p.Id)
                .ToList();

            return View(predictions);
        }
        public IActionResult GeneratePdf(int id)
        {
            var prediction = _context.Predictions.FirstOrDefault(p => p.Id == id);

            return new ViewAsPdf("PdfReport", prediction)
            {
                FileName = "HeartDiseaseReport.pdf"
            };
        }
    }
}