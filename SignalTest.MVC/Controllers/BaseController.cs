using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace SignalTest.MVC.Controllers
{
    public class BaseController : Controller
    {
        public string ObterNomeUsuarioLogado()
        {
            return ObterClaim("Nome");
        }

        public Guid ObterIdUsuarioLogado()
        {
            var idStr = ObterClaim(ClaimTypes.NameIdentifier);

            return Guid.TryParse(idStr, out var id) ? id : Guid.Empty;
        }

        public string ObterClaim(string type)
        {
            return User?.Claims?.FirstOrDefault(c => c.Type == type)?.Value;
        }
    }
}