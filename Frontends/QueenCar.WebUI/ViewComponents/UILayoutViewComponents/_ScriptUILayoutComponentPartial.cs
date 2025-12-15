using Microsoft.AspNetCore.Mvc;

namespace QueenCar.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _ScriptUILayoutComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
