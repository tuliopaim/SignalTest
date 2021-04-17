using Microsoft.AspNetCore.Mvc;
using SignalTest.MVC.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using SignalTest.MVC.Domain.Interfaces;

namespace SignalTest.MVC.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IUserInstanceService _service;

        public HomeController(IUserInstanceService service)
        {
            _service = service;
        }

        public IActionResult Index()
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
