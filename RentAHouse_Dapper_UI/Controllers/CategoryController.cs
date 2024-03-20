using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentAHouse_Dapper_UI.Models.CategoryModels;
using RentAHouse_Dapper_UI.Models.TestimonialModels;
using System.Reflection;
using System.Text;

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

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryModel model)
        {
            var client = httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:44316/api/Categories", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("index");
            }
            return View();
        }

        [HttpGet("id")]
        public async Task<IActionResult> Delete(int id)
        {
            var client = httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:44316/api/Categories/{id}");

            return RedirectToAction("index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var client = httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:44316/api/Categories/{id}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateCategoryModel>(json);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateCategoryModel model)
        {
            var client = httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:44316/api/Categories", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("index");
            }
            return View();
        }

    }
}
