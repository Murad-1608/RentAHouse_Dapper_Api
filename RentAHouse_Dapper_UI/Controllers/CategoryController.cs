using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentAHouse_Dapper_UI.Models.CategoryModels;
using RentAHouse_Dapper_UI.Models.TestimonialModels;

namespace RentAHouse_Dapper_UI.Controllers
{
    public class CategoryController : MainController
    {
        public CategoryController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public async Task<IActionResult> Index()
        {
            var client = httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:44316/api/Categories");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryModel>>(json);
                return View(values);
            }
            return View();
        }
    }
}
