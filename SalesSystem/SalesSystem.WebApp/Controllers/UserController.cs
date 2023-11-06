using Microsoft.AspNetCore.Mvc;

namespace SalesSystem.WebApp.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Users()
        {
            return View();
        }
    }
}
