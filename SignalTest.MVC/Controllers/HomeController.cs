using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SignalTest.MVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using SignalTest.MVC.Domain.Interfaces;

namespace SignalTest.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserInstanceService _service;

        public HomeController(IUserInstanceService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
