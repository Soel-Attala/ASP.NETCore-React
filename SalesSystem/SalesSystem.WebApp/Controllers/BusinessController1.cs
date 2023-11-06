using Microsoft.AspNetCore.Mvc;

namespace SalesSystem.WebApp.Controllers
{
    public class BusinessController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
