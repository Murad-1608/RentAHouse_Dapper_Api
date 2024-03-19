using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentAHouse_Dapper_UI.Models.TestimonialModels;

namespace RentAHouse_Dapper_UI.ViewComponents.HomePage
{
    public class DefaultOurClientsComponent : BaseViewComponent
    {
        public DefaultOurClientsComponent(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public override async Task<IViewComponentResult> InvokeAsync()
        {
            var client = httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:44316/api/Testimonials");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultTestimonialModel>>(json);
                return View(values);
            }
            return View();
        }
    }
}
