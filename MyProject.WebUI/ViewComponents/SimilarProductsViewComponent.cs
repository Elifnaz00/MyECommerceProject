using Microsoft.AspNetCore.Mvc;
using MyProject.DataAccess.Abstract;
using MyProject.WebUI.Models.ProductModel;
using System.Net.Http;

namespace MyProject.WebUI.ViewComponents
{
    [ViewComponent]
    public class SimilarProductsViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SimilarProductsViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid categoryId)
        {
            var client = _httpClientFactory.CreateClient("ApiService1");

            
            HttpResponseMessage httpResponseMessage = await client.GetAsync(client.BaseAddress + $"/Product/Productbycategory/{categoryId}");
            httpResponseMessage.EnsureSuccessStatusCode();

            var products = await httpResponseMessage.Content.ReadFromJsonAsync<IEnumerable<ProductListViewModel>>()
                           ?? new List<ProductListViewModel>();

            var takeproducts = products.Take(8);
           
            return View(takeproducts); 

        }
    }
}
