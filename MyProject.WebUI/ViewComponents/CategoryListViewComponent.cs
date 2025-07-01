using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyProject.WebUI.Models.CategoryModel;
using MyProject.WebUI.Models.EntranceModel;

namespace MyProject.WebUI.ViewComponents
{
    [ViewComponent]
    public class CategoryListViewComponent : ViewComponent
    {
       
        private readonly IHttpClientFactory _httpClientFactory;

        public CategoryListViewComponent(IHttpClientFactory httpClientFactory, IMapper mapper)
        {
            _httpClientFactory = httpClientFactory;
        
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient("ApiService1");

            HttpResponseMessage response = await client.GetAsync(client.BaseAddress + "/Category");

            if (response.IsSuccessStatusCode)
            {
                var entrances = await response.Content.ReadFromJsonAsync<IEnumerable<CategoryListViewModel>>();
                return View(entrances);
            }
            else
                response.EnsureSuccessStatusCode();

            return View();
        }
    }
}
