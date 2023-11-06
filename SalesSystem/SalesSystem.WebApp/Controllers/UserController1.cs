using Microsoft.AspNetCore.Mvc;

namespace SalesSystem.WebApp.Controllers
{
    public class UserController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
