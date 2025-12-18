using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyProject.TokenDTOs.DTOs.CategoryDTOs;
using MyProject.WebUI.Models.CategoryModel;
using MyProject.WebUI.Models.EntranceModel;

namespace MyProject.WebUI.ViewComponents
{
    [ViewComponent]
    public class CategoryListViewComponent : ViewComponent
    {
       
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IMapper _mapper;

        public CategoryListViewComponent(IHttpClientFactory httpClientFactory, IMapper mapper)
        {
            _httpClientFactory = httpClientFactory;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient("ApiService1");

            HttpResponseMessage response = await client.GetAsync(client.BaseAddress + "/Category");

            if (response.IsSuccessStatusCode)
            {
                var categoryList = await response.Content.ReadFromJsonAsync<List<CategoryListDTO>>();
                var categoryListVM = _mapper.Map<List<CategoryListViewModel>>(categoryList);
                return View(categoryListVM);
            }
            else
                response.EnsureSuccessStatusCode();

            return View();
        }
    }
}
