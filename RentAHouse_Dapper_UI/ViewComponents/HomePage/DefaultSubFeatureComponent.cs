using Microsoft.AspNetCore.Mvc;

namespace RentAHouse_Dapper_UI.ViewComponents.HomePage
{
    public class DefaultSubFeatureComponent : BaseViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }

}
