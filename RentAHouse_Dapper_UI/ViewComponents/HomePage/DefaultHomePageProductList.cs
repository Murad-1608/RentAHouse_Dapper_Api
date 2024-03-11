using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentAHouse_Dapper_UI.Models.ProductModels;

namespace RentAHouse_Dapper_UI.ViewComponents.HomePage
{
    public class DefaultHomePageProductList : BaseViewComponent
    {
        public DefaultHomePageProductList(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public override async Task<IViewComponentResult> InvokeAsync()
        {
            var client = httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:44316/api/Products/GetWithCategory");
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
