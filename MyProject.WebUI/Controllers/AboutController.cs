using System.Net.Http;
using System.Net.Http.Headers;
using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyProject.WebUI.Models.AboutModel;
using MyProject.WebUI.Models.EntranceModel;
using MyProject.WebUI.Models.ProductModel;


namespace MyProject.WebUI.Controllers
{
  
    public class AboutController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AboutController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


       
        public async Task<IActionResult> Index()
        {
           
            var client = _httpClientFactory.CreateClient("ApiService1");

            HttpResponseMessage httpResponseMessage = await client.GetAsync(client.BaseAddress + "/About");
            if (httpResponseMessage.IsSuccessStatusCode)
            {

                var aboutValue = await httpResponseMessage.Content.ReadFromJsonAsync<IEnumerable<AboutListViewModel>>();
                return View(aboutValue);
            }
            else
                httpResponseMessage.EnsureSuccessStatusCode();

            return View();

        }
    }
}
