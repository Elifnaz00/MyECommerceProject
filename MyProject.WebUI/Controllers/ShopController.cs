using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.OpenApi.Writers;
using MyProject.DataAccess.Context;
using MyProject.DTO.Models.BasketItemViewModel;
using MyProject.Entity.Entities;
using MyProject.WebUI.Models.BasketItemModel;
using MyProject.WebUI.Models.ProductModel;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


namespace MyProject.WebUI.Controllers
{
    [AllowAnonymous]
    public class ShopController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<ShopController> _logger;

        public ShopController(IHttpClientFactory httpClientFactory, ILogger<ShopController> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }


        [HttpGet]
        public async Task<IActionResult> ShopProductList()
        {
            var client = _httpClientFactory.CreateClient("ApiService1");

            // Tüm ürünleri al  
            HttpResponseMessage httpResponseMessage = await client.GetAsync("Product/GetProduct");
            httpResponseMessage.EnsureSuccessStatusCode();

            var allProducts = await httpResponseMessage.Content.ReadFromJsonAsync<ProductwithCategoryViewModel>();
                              
            return View(allProducts);
        }
   
        [HttpPost]
        public async Task<IActionResult> ShopProductList(Guid productId)
        {
            var client = _httpClientFactory.CreateClient("ApiService1");
            var content = new StringContent(JsonConvert.SerializeObject(new
                                            {
                                                ProductId = productId,   
                                            }), Encoding.UTF8, "application/json"  );

            var token = HttpContext.Request.Cookies["ApiAccessToken"];
            if (!string.IsNullOrEmpty(token))
            {
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);
            }

           
            var response= await client.PostAsync("BasketItem/AddToBasket", content);
            if(!response.IsSuccessStatusCode)
            {
                return Json(new
                {
                    success = false,
                    message = "Ürün sepete eklenemedi."
                });

            }
            return Json(new
            {
                success = true,
                message = "Ürün sepete eklendi."
            });        
        }



        [HttpGet("GetProductByCategory/{categoryId}")]
        public async Task<IActionResult> GetProductByCategory(Guid? categoryId) {

            var client = _httpClientFactory.CreateClient("ApiService1");
            
            HttpResponseMessage httpResponseMessage = await client.GetAsync($"Product/Productbycategory/{categoryId}");
            httpResponseMessage.EnsureSuccessStatusCode();

            var products = await httpResponseMessage.Content.ReadFromJsonAsync<ProductwithCategoryViewModel>();
                          
            return View("ShopProductList", products);

        }


        [HttpGet("ProductDetails/{id}")]
        public async Task<IActionResult> ProductDetails(Guid? id) 
        {
            if (id == null)
            {
                _logger.LogWarning("Ürün detayları için geçersiz bir ID sağlandı.");
                return BadRequest("Geçersiz ID.");
            }
            

            var client = _httpClientFactory.CreateClient("ApiService1");

            try
            {
                
                var httpResponseMessage = await client.GetAsync($"Product/Productdetail/{id}");

                if (!httpResponseMessage.IsSuccessStatusCode)
                {
                    var errorResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                    _logger.LogError($"API Hatası: {httpResponseMessage.StatusCode}, Yanıt: {errorResponse}");
                    return StatusCode((int)httpResponseMessage.StatusCode, "Ürün detayları alınamadı.");
                }

                var product = await httpResponseMessage.Content.ReadFromJsonAsync<ProductDetailViewModel>();

                if (product == null)
                {
                    _logger.LogError("Deserialization işlemi sırasında ürün bilgisi alınamadı.");
                    return StatusCode(500, "Ürün detayları alınamadı.");
                }

                return View(product);
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "API çağrısı sırasında bir hata oluştu.");
                return StatusCode(500, "API çağrısı sırasında bir hata oluştu.");
            }

        }

        
        [HttpGet("GetFilteredProducts")]
        public async Task<IActionResult> GetFilteredProducts(string? category, string? size, string? color, long? price)
        {

            var client = _httpClientFactory.CreateClient("ApiService1");
           
            var response = await client.GetAsync("Product/GetFiltered?" +
            $"category={category}&size={size}&color={color}&price={price}");
                
            if (!response.IsSuccessStatusCode)
            {
                return BadRequest("Ürünler alınırken bir hata oluştu.");
            }

            var data = await response.Content.ReadFromJsonAsync<dynamic>();
            return Json(data);
        }

    }
}
