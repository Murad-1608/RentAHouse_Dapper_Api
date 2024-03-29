﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentAHouse_Dapper_UI.Models.ServiceModels;
using RentAHouse_Dapper_UI.Models.WhoWeAreModels;

namespace RentAHouse_Dapper_UI.ViewComponents.HomePage
{
    public class DefaultWhoWeAreComponent : BaseViewComponent
    {
        public DefaultWhoWeAreComponent(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }
        public override async Task<IViewComponentResult> InvokeAsync()
        {
            var client = httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:44316/api/WhoWeAreDetails");
            var responseForServices = await client.GetAsync("https://localhost:44316/api/Services");
            if (response.IsSuccessStatusCode && responseForServices.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var jsonDataForServices = await responseForServices.Content.ReadAsStringAsync();
                var items = JsonConvert.DeserializeObject<List<ResultWhoWeAreModel>>(jsonData);
                var itemsForServices = JsonConvert.DeserializeObject<List<ResultServiceModel>>(jsonDataForServices);

                ViewBag.Services = itemsForServices;

                var whoWeAre = items!.FirstOrDefault();

                return View(whoWeAre);
            }
            return View();
        }
    }
}
