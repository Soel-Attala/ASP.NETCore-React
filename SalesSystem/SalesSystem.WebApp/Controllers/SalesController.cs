﻿using Microsoft.AspNetCore.Mvc;

namespace SalesSystem.WebApp.Controllers
{
    public class SalesController : Controller
    {
        public IActionResult NewSale()
        {
            return View();
        }

        public IActionResult SaleHistory()
        {
            return View();
        }
    }
}