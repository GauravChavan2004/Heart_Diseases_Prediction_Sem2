using Microsoft.AspNetCore.Mvc;

namespace HeartDiseasePrediction.Controllers
{
    public class UserController : Controller
    {
        public IActionResult UserDashboard()
        {
            // Check Session
            if (HttpContext.Session.GetInt32("UserId") == null)
            {
                return RedirectToAction(
                    "Login",
                    "Account"
                );
            }

            return View();
        }
    }
}