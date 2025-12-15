using Microsoft.AspNetCore.Mvc;

namespace QueenCar.WebUI.ViewComponents.AboutViewComponents
{
    public class _BecomeADriverComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
