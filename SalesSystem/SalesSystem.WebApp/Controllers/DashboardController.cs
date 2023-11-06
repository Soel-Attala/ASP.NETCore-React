using Microsoft.AspNetCore.Mvc;

namespace SalesSystem.WebApp.Controllers
{
    public class DashboardController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
