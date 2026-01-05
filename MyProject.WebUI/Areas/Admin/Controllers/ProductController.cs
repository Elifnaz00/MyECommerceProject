using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyProject.DTO.DTOs.AdminDTOs.CategoryDto;
using MyProject.DTO.DTOs.AdminDTOs.ProductDto;
using MyProject.DTO.Models;
using MyProject.Entity.Enums;
using MyProject.WebUI.Models.AdminModel.DashboardModel;
using MyProject.WebUI.Models.AdminModel.ProductModel;
using MyProject.WebUI.Models.ProductModel;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;

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
                var getByIdProductVM = await getByIdProductResponse.Content.ReadFromJsonAsync<ProductEditDto>();   
                var mappedProductItem= _mapper.Map<EditProductViewModel>(getByIdProductVM);

                return View(mappedProductItem);
            }

            return View();
            
        }

        
        [HttpPost]
        public async Task<IActionResult> Edit(EditProductViewModel editProductViewModel)
        {
           
            var content = new StringContent(
            JsonConvert.SerializeObject(editProductViewModel),
            Encoding.UTF8,
            "application/json"
);
            var getByIdProductResponse = await _httpClient.PutAsync(_httpClient.BaseAddress + $"/Product/update-product/{editProductViewModel.Id}", content);
            return RedirectToAction("AvailableProducts", "AdminHome");
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var getCategorytResponse = await _httpClient.GetAsync(_httpClient.BaseAddress + $"/Category/get-categories");
            var categoryList = await getCategorytResponse.Content.ReadFromJsonAsync<List<CategoryDto>>();
            var cerateProductVM = new CreateProductViewModel{
                CategoryDtos = categoryList ?? new List<CategoryDto>()
            };
            return View(cerateProductVM);
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateProductViewModel createProductViewModel)
        {

            var content = new StringContent(
            JsonConvert.SerializeObject(createProductViewModel),
            Encoding.UTF8,
            "application/json"
);
            var getByIdProductResponse = await _httpClient.PostAsync(_httpClient.BaseAddress + $"/Product/create-product", content);
            return RedirectToAction("AvailableProducts", "AdminHome");
        }


        [HttpGet]
        public async Task<IActionResult> ProductDetailModal(Guid id)
        {
            var detailProductResponse = await _httpClient.GetAsync(_httpClient.BaseAddress + $"/Product/detail-product/{id}");
            if (detailProductResponse.IsSuccessStatusCode)
            {
                var detailProductVM = await detailProductResponse.Content.ReadFromJsonAsync<ProductDetailDto>();
                var mappedDetailProductItem = _mapper.Map<DetailProductViewModel>(detailProductVM);
                return PartialView("_ProductDetailModalPartial", mappedDetailProductItem);
            }
            return RedirectToAction("AvailableProducts", "AdminHome");


        }
        }

    }
