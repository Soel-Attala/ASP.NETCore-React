using Microsoft.AspNetCore.Mvc;

namespace SalesSystem.WebApp.Controllers
{
    public class BusinessController : Controller
    {
        public IActionResult Business()
        {
            return View();
        }
    }
}
