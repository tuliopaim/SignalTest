using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace SignalTest.MVC.Controllers
{
    [Authorize]
    public class TweetController : BaseController
    {
        public TweetController()
        {
            
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Tweetar(string mensagem)
        {
            return Ok();
        }
    }
}
