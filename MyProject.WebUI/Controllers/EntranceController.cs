using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyProject.DataAccess.Context;
using MyProject.Entity.Entities;
using MyProject.WebUI.Models.EntranceModel;
using System.Net.Http.Json;
using System.Reflection.Metadata.Ecma335;

namespace MyProject.WebUI.Controllers
{
    [AllowAnonymous]
    public class EntranceController : Controller
    {

        private readonly IMapper _mapper;
        private readonly IHttpClientFactory _httpClientFactory;
        public EntranceController(IMapper mapper, IHttpClientFactory httpClientFactory)
        {
            _mapper = mapper;   
            _httpClientFactory = httpClientFactory;
        }

       
        public async Task<IActionResult> Index()
        {
            //string url = "https://localhost:7177/api/entrance";
            //HttpClient client = new HttpClient();
            
            var client = _httpClientFactory.CreateClient("ApiService1");
            
            HttpResponseMessage response = await client.GetAsync(client.BaseAddress + "/entrance");
            if (response.IsSuccessStatusCode) {
                
                var entrances = await response.Content.ReadFromJsonAsync<IEnumerable<EntranceListViewModel>>();
                return View(entrances);
            }
            else
                response.EnsureSuccessStatusCode();

            return View();
        }

        public async Task<IActionResult> GetByEntrance(Guid id) 
        {
            var client = _httpClientFactory.CreateClient("ApiService1");
            HttpResponseMessage response = await client.GetAsync(client.BaseAddress + $"/entrance/{id}");
            
            if (response.IsSuccessStatusCode)
            {
                var entranceByListViewModel = await response.Content.ReadFromJsonAsync<EntranceByListViewModel>();

                return View(entranceByListViewModel);
            }
            else response.EnsureSuccessStatusCode();
            return View();
        }

       
        public async Task<IActionResult> CreateEntrance(CreateEntranceViewModel createEntranceViewModel)
        {
            var client = _httpClientFactory.CreateClient("ApiService1");
           

            var entrance= _mapper.Map<Entrance>(createEntranceViewModel);
            /*Entrance entrance = new Entrance()
            {
                Title1 = createEntranceViewModel.Title1,
                Description1 = createEntranceViewModel.Description1,
                Description2 = createEntranceViewModel.Description2,
                Description3 = createEntranceViewModel.Description3,
                CreateDate = DateTime.Now,
                Id = new Guid()
            }; */

            
            HttpResponseMessage response = await client.PostAsJsonAsync(client.BaseAddress + "/entrance", entrance);

            return View();
        }

        
        
        public async Task<IActionResult> EditEntrance(Guid id)
        {
            var client = _httpClientFactory.CreateClient("ApiService1");
            HttpResponseMessage response = await client.GetAsync(client.BaseAddress + $"/entrance/{id}");
            if (response.IsSuccessStatusCode)
            {
                var entranceEditViewModel = await response.Content.ReadFromJsonAsync<EntranceEditViewModel>();
                return View(entranceEditViewModel);
            }
            return RedirectToAction(nameof(Index));



        }

        
      
        public async Task<IActionResult> EditEntrance(EntranceEditViewModel entranceEditViewModel)
        {
            var client = _httpClientFactory.CreateClient("ApiService1");
            await client.PutAsJsonAsync(client.BaseAddress + $"/entrance/{entranceEditViewModel.Id}", entranceEditViewModel);

            return RedirectToAction(nameof(Index));
        }



        public async Task<IActionResult> DeleteEntrance(Guid id)  
        {

             /*
            if (createEntranceViewModel.IsChecked == true) 
            {
                HttpResponseMessage response= await sharedClient.DeleteAsync("https://localhost:7177/api/entrance/3fa85f64-5717-4562-b3fc-2c963f66afa5");
            } */
            var client = _httpClientFactory.CreateClient("ApiService1");
            await client.DeleteAsync(client.BaseAddress + $"/entrance/{id}");
            
            return RedirectToAction(nameof(Index));
        }





    }
}
