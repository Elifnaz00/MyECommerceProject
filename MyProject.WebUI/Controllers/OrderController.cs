using Microsoft.AspNetCore.Mvc;
using MyProject.WebUI.Models.OrderModel;

namespace MyProject.WebUI.Controllers
{
    public class OrderController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Index(OrderViewModel orderViewModel)
        {
            return View();
        }
    }
}
