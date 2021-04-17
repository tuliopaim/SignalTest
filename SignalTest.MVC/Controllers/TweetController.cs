using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using SignalTest.MVC.Domain.Interfaces;

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
    }
}
