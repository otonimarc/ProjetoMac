﻿using Microsoft.AspNetCore.Mvc;
using ProjetoMac.Models;
using System.Diagnostics;

namespace ProjetoMac.Controllers
{
    public class HomeController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Demo()
        {
            TempData["Nome"] = "Marcoratti";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}