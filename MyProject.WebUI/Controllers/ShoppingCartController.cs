﻿using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using MyProject.DTO.DTOs.BasketItemDTOs;
using MyProject.DTO.Models.BasketViewModel;

using MyProject.WebUI.Models.ProductModel;

using MyProject.WebUI.Models.ShoppingCartModel;
using Newtonsoft.Json;



namespace MyProject.WebUI.Controllers
{
    [Authorize]
    public class ShoppingCartController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;
        

        public ShoppingCartController(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _httpContextAccessor = httpContextAccessor;
        }


        

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var token = HttpContext?.Session.GetString("token");
            if (string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Index", "Login");
            }

            HttpClient client = _httpClientFactory.CreateClient("ApiService1");

            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);


            HttpResponseMessage httpResponse = await client.GetAsync(client.BaseAddress + "/Basket/GetBasket");
            var response = await httpResponse.Content.ReadFromJsonAsync<ShoppingCartViewModel>();
            if (response.BasketStatus == Entity.Enums.BasketStatus.NotFound)
            {
                var value= await client.PostAsync(client.BaseAddress + "/Basket/AddBasket", null);
                return View();  //// boş sepet görünümü


            }

            if(response.BasketStatus == Entity.Enums.BasketStatus.Empty)
            {
                return View(response);  // ürün yok ama sepet var

            }

            if(response.BasketStatus == Entity.Enums.BasketStatus.HasItems)
            {
                return View(response);
            }
            return View(); 
        }


        [HttpPost]
        public async Task<IActionResult> CartSubmit(ShoppingCartSubmitViewModel shoppingCartSubmitViewModel)
        {
            HttpClient client = _httpClientFactory.CreateClient("ApiService1");
            string requestBody = JsonConvert.SerializeObject(shoppingCartSubmitViewModel);
            using StringContent httpContent = new StringContent(requestBody, Encoding.UTF8, "application/json");
            await client.PostAsync(client.BaseAddress + "/BasketItem/AddBasketToBasketItem", httpContent);
            return View();
        }
    }
}
