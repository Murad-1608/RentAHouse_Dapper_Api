using Microsoft.AspNetCore.Mvc;

namespace RentAHouse_Dapper_UI.ViewComponents
{
    public abstract class BaseViewComponent : ViewComponent
    {
        protected readonly IHttpClientFactory httpClientFactory;

        protected BaseViewComponent(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public abstract Task<IViewComponentResult> InvokeAsync();

    }
}
