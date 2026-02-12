using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles = "Admin")]
    public class ProductController : BaseAdminController
    {
       
        private readonly IMapper _mapper;

        public ProductController(HttpClient httpClient,
        IHttpContextAccessor contextAccessor, IHttpClientFactory httpClientFactory,
        IMapper mapper) : base(httpClient, contextAccessor, httpClientFactory)
        {
            
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var client = CreateClient();
            var getByIdProductResponse = await client.GetAsync(_httpClient.BaseAddress + $"/Product/get-by-id-product/{id}");
            
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
            var client = CreateClient();
            var content = new StringContent(
            JsonConvert.SerializeObject(editProductViewModel),
            Encoding.UTF8,
            "application/json"
);
            var getByIdProductResponse = await client.PutAsync(_httpClient.BaseAddress + $"/Product/update-product/{editProductViewModel.Id}", content);
            return RedirectToAction("AvailableProducts", "AdminHome");
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var client = CreateClient();
            var getCategorytResponse = await client.GetAsync(_httpClient.BaseAddress + $"/Category/get-categories");
            var categoryList = await getCategorytResponse.Content.ReadFromJsonAsync<List<CategoryDto>>();
            var cerateProductVM = new CreateProductViewModel{
                CategoryDtos = categoryList ?? new List<CategoryDto>()
            };
            return View(cerateProductVM);
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateProductViewModel createProductViewModel)
        {
            var client = CreateClient();
            var content = new StringContent(
            JsonConvert.SerializeObject(createProductViewModel),
            Encoding.UTF8,
            "application/json"
);
            var getByIdProductResponse = await client.PostAsync(_httpClient.BaseAddress + $"/Product/create-product", content);
            return RedirectToAction("AvailableProducts", "AdminHome");
        }


        [HttpGet]
        public async Task<IActionResult> ProductDetailModal(Guid id)
        {
            var client = CreateClient();
            var detailProductResponse = await client.GetAsync(_httpClient.BaseAddress + $"/Product/detail-product/{id}");
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
