using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SignalTest.Application.Services.Interfaces;

namespace SignalTest.MVC.Controllers
{
    [Authorize]
    public class ProcessamentoController : BaseController
    {
        private readonly IProcessamentoService _service;

        public ProcessamentoController(
            IProcessamentoService service)
        {
            _service = service;
        }

        // GET
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Processar()
        {
            try
            {
                await _service.Processar(ObterIdUsuarioLogado());
                
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest();
            }
        }
    }
}