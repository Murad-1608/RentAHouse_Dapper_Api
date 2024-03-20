using Microsoft.AspNetCore.Mvc;

namespace RentAHouse_Dapper_UI.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
