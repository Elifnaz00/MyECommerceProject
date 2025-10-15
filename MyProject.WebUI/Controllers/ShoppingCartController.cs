using System.Text;
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
       
        public ShoppingCartController(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory;
           
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


            return response.BasketStatus switch
            {
                Entity.Enums.BasketStatus.NotFound => await HandleNotFoundAsync(),  // boş sepet görünümü
                Entity.Enums.BasketStatus.Empty => View(response),  // ürün yok ama sepet var
                Entity.Enums.BasketStatus.HasItems => View(response),  // sepet dolu
                _ => View()  // varsayılan olarak boş sepet görünümü
            };
            async Task<ViewResult> HandleNotFoundAsync()
            {
                await client.PostAsync(client.BaseAddress + "/Basket/AddBasket", null);
                return View(); // boş sepet görünümü
            }
        }

    }
}