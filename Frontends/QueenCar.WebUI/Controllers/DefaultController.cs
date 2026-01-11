using Microsoft.AspNetCore.Mvc;

namespace QueenCar.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
