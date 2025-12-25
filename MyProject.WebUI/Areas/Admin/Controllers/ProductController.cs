using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyProject.DTO.Models;
using MyProject.Entity.Enums;
using MyProject.WebUI.Models.AdminModel.DashboardModel;
using MyProject.WebUI.Models.AdminModel.ProductModel;
using System.Net.Http;

namespace MyProject.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {

        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;

        public ProductController(IHttpClientFactory httpClientFactory, IMapper mapper)
        {
            _httpClient = _httpClient = httpClientFactory.CreateClient("admin");
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var getByIdProductResponse = await _httpClient.GetAsync(_httpClient.BaseAddress + $"/Product/get-by-id-product/{id}");
            
            if (getByIdProductResponse.IsSuccessStatusCode)
            {
                var getByIdProductVM = await getByIdProductResponse.Content.ReadFromJsonAsync<EditProductViewModel>();
                var colorListVM= Enum.GetValues(typeof(Renkler)).Cast<Renkler>().Select(d => new ColorSelectListItemVM
                {
                    Text = d.ToString(),
                    Value= ((int)d).ToString()  
                }).ToList();

                var SizeListVM = Enum.GetValues(typeof(Bedenler)).Cast<Bedenler>().Select(d => new SizeSelectListItemVM
                {
                    Text = d.ToString(),
                    Value = ((int)d).ToString()
                }).ToList();

                var mappedProductItem= _mapper.Map<EditProductViewModel>(getByIdProductVM);

                return View(mappedProductItem);
            }

            return View();
            
        }

        
        [HttpPost]
        public IActionResult Edit(Guid id, EditProductViewModel editProductViewModel)
        {
            return View();
        }
        
    }
}
