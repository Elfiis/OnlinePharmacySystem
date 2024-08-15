using Microsoft.AspNetCore.Mvc;

namespace OnlinePharmacySystem.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
