using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyProject.DTO.DTOs.BasketItemDTOs;
using MyProject.DTO.Models.BasketViewModel;
using MyProject.WebUI.Models.ProductModel;
using MyProject.WebUI.Models.ShoppingCartModel;
using Newtonsoft.Json;
using System.Drawing;
using System.Net.Http.Headers;
using System.Text;


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
            

            HttpClient client = _httpClientFactory.CreateClient("ApiService1");
            var token = HttpContext.Request.Cookies["ApiAccessToken"];
            if (!string.IsNullOrEmpty(token))
            {
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);
            }


            HttpResponseMessage httpResponse = await client.GetAsync("Basket/GetBasket");
            var response = await httpResponse.Content.ReadFromJsonAsync<ShoppingCartViewModel>();

            TempData["BasketMessage"] = "Sepetinizde ürün bulunmamaktadır.";

            return response.BasketStatus switch
            {
                Entity.Enums.BasketStatus.NotFound => await HandleNotFoundAsync(),  // boş sepet görünümü
                Entity.Enums.BasketStatus.Empty => View(),  // ürün yok ama sepet var
                Entity.Enums.BasketStatus.HasItems => View(response),  // sepet dolu
                _ => View()  // varsayılan olarak boş sepet görünümü
            };
            async Task<ViewResult> HandleNotFoundAsync()
            {
                await client.PostAsync("Basket/AddBasket", null);
                return View(); // boş sepet görünümü
            }
        }

    }
}