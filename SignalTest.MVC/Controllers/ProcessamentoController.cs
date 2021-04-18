using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SignalTest.Application.Services.Interfaces;

namespace SignalTest.MVC.Controllers
{
    [Authorize]
    public class ProcessamentoController : Controller
    {
        private readonly IUserInstanceService _service;

        public ProcessamentoController(IUserInstanceService service)
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