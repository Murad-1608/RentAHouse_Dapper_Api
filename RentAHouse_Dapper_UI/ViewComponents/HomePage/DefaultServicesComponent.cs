using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentAHouse_Dapper_UI.Models.ProductModels;
using System.Net.Http;

namespace RentAHouse_Dapper_UI.ViewComponents.HomePage
{
    public class DefaultServicesComponent : BaseViewComponent
    {
        public DefaultServicesComponent(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public async override Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
