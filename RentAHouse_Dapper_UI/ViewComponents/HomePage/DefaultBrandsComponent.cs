﻿using Microsoft.AspNetCore.Mvc;

namespace RentAHouse_Dapper_UI.ViewComponents.HomePage
{
    public class DefaultBrandsComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
