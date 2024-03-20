using Microsoft.AspNetCore.Mvc;

namespace RentAHouse_Dapper_UI.Controllers
{
    public class MainController : Controller
    {
        protected IHttpClientFactory httpClientFactory;
        public MainController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
    }
}
