using Microsoft.AspNetCore.Mvc;

namespace SalesSystem.WebApp.Controllers
{
    public class ProductsController1 : Controller
    {
        public IActionResult Products()
        {
            return View();
        }
    }
}
