using Microsoft.AspNetCore.Mvc;

namespace QueenCar.WebUI.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
