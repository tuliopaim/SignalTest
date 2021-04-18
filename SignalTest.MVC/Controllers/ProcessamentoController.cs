using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SignalTest.Application.Services.Interfaces;

namespace SignalTest.MVC.Controllers
{
    [Authorize]
    public class ProcessamentoController : Controller
    {
        private readonly IUserService _service;

        public ProcessamentoController(IUserService service)
        {
            _service = service;
        }

        // GET
        public IActionResult Index()
        {
            var id = Guid.NewGuid();

            return View(id);
        }
    }
}