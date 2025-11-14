using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using MyProject.Entity.Entities;
using MyProject.WebUI.Extensions;
using MyProject.WebUI.Models.ContactModel;
using System;

namespace MyProject.WebUI.Controllers
{
    [Authorize(Roles = "Denemelik")]
    public class ContactController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;
        private IValidator<ContactUsViewModel> _validator;

        public ContactController(IHttpClientFactory httpClientFactory, IValidator<ContactUsViewModel> validator)
        {
            _httpClientFactory = httpClientFactory;
            _validator = validator;
        }

        
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }




        [HttpPost]
        public async Task<IActionResult> Index(ContactUsViewModel contactUsViewModel)
        {
            ValidationResult result = await _validator.ValidateAsync(contactUsViewModel);
            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);
                return View("Index", contactUsViewModel);
            }


            HttpClient client= _httpClientFactory.CreateClient("ApiService1");

            await client.PostAsJsonAsync(client.BaseAddress + "/Contact", contactUsViewModel);

            TempData["notice"] = "Mesajınız Başarıyla Gönderildi!";
            return RedirectToAction("Index");
        }




        


    }
}
