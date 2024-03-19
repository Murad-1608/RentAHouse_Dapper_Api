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
            var client = httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:44316/api/Services/GetAll");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductModel>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
