using Microsoft.AspNetCore.Mvc;

namespace RentAHouse_Dapper_UI.ViewComponents.HomePage
{
    public class DefaultServicesComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
