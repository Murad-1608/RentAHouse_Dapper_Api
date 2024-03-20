using Microsoft.AspNetCore.Mvc;

namespace RentAHouse_Dapper_UI.ViewComponents.AdminLayout
{
    public class AdminLayoutNavbarComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
