using Microsoft.AspNetCore.Mvc;

namespace MyProject.WebUI.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
