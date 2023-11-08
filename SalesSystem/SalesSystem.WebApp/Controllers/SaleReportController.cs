using Microsoft.AspNetCore.Mvc;

namespace SalesSystem.WebApp.Controllers
{
    public class SaleReportController : Controller
    {
        public IActionResult SaleReport()
        {
            return View();
        }
    }
}
