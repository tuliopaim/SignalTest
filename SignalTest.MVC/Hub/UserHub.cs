using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using SignalTest.MVC.Domain.Interfaces;

namespace SignalTest.MVC.Hub
{
    public class UserHub : Microsoft.AspNetCore.SignalR.Hub
    {
        private readonly IUserInstanceService _service;

        public UserHub(IUserInstanceService service)
        {
            _service = service;
        }
        
        public async Task EstouAqui()
        {
            await _service.EstouAqui(Context.UserIdentifier);
        }

        public async Task AtualizarInstanciasOnline()
        {
            var lista = await _service.ObterTodosOnline();

            await Clients.Caller.SendAsync("UsuariosOnline", lista);
        }

        public async Task AtualizarInstanciasOnlineParaTodos()
        {
            await _service.NotificarUsuariosOnlineHub();
        }
    }
}