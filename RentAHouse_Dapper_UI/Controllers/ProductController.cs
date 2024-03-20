using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using RentAHouse_Dapper_UI.Models.CategoryModels;
using RentAHouse_Dapper_UI.Models.ProductModels;
using System.Text;

namespace RentAHouse_Dapper_UI.Controllers
{
    public class ProductController : MainController
    {
        public ProductController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public async Task<IActionResult> Index()
        {
            var client = httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:44316/api/Products/GetWithCategory");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductModel>>(json);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var client = httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:44316/api/Categories");

            var json = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCategoryModel>>(json);
            List<SelectListItem> categories = (from x in values.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.Name,
                                                   Value = x.Id.ToString()
                                               }).ToList();

            ViewBag.Categories = categories;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductModel model)
        {
            var client = httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:44316/api/Products", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("index");
            }
            return View();
        }
    }
}
