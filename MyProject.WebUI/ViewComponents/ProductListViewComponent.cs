using Microsoft.AspNetCore.Mvc;
using MyProject.WebUI.Models.ProductModel;



namespace MyProject.WebUI.ViewComponents
{
    [ViewComponent]
    public class ProductListViewComponent: ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductListViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient("ApiService1");
           
            HttpResponseMessage response = await client.GetAsync(client.BaseAddress + "/Product/GetNewArrivalProducts");

            if (response.IsSuccessStatusCode) {
                


                var entrances = await response.Content.ReadFromJsonAsync<IEnumerable<ProductNewViewModel>>();
                return View(entrances);
            }

            else
                response.EnsureSuccessStatusCode();

            return View();
        }

    }
}
