using System;
using Microsoft.AspNetCore.Mvc;
using SignalTest.MVC.Models;
using System.Diagnostics;
using System.Threading.Tasks;
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

        public async Task<IActionResult> Index()
        {
            var usuariosOnline = await _service.ObterTodosOnline();

            return View(nameof(Index), new HomeModel
            {
                UsuarioLogado = ObterNomeUsuarioLogado(),
                Usuarios = usuariosOnline,
            });
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<IActionResult> EstouAqui()
        {
            try
            {
                await _service.EstouAqui(ObterIdUsuarioLogado());

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
