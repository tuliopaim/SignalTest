using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SignalTest.Application.InputModels;
using SignalTest.Application.Services.Interfaces;

namespace SignalTest.MVC.Controllers
{
    [Authorize]
    public class TweetController : BaseController
    {
        private readonly ITweetService _service;

        public TweetController(ITweetService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var tweets = await _service.ObterTodos();
            
            return View(nameof(Index), tweets);
        }

        [HttpPost]
        public async Task<IActionResult> NovoTweet(string mensagem)
        {
            try
            {
                await _service.NovoTweet(mensagem, ObterIdUsuarioLogado());

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
