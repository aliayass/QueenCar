using Microsoft.AspNetCore.Mvc;

namespace QueenCar.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _NavbarUILayoutComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
