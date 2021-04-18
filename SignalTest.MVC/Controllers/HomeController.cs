using Microsoft.AspNetCore.Mvc;
using SignalTest.MVC.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using SignalTest.Application.Services.Interfaces;

namespace SignalTest.MVC.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        private readonly IUserService _service;

        public HomeController(IUserService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View(nameof(Index), ObterNomeUsuarioLogado());
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
