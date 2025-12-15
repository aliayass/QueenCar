using Microsoft.AspNetCore.Mvc;

namespace QueenCar.WebUI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
