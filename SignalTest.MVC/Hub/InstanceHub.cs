using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using SignalTest.MVC.Domain.Interfaces;

namespace SignalTest.MVC.Hub
{
    public class InstanceHub : Microsoft.AspNetCore.SignalR.Hub
    {
        private readonly IUserInstanceService _service;

        public InstanceHub(IUserInstanceService service)
        {
            _service = service;
        }

        public async Task SouNovoAqui(string nome)
        {
            var user = await _service.Add(nome);

            await Clients.Caller.SendAsync("MeuId", user);

            await AtualizarInstanciasOnlineParaTodos();
        }

        public async Task EstouAqui(Guid id)
        {
            await _service.AtualizarVistoPorUltimo(id);

            await AtualizarInstanciasOnlineParaTodos();
        }

        public async Task AtualizarInstanciasOnline()
        {
            var lista = await _service.ObterTodosOnline();

            await Clients.Caller.SendAsync("InstanciasOnline", lista);
        }

        public async Task AtualizarInstanciasOnlineParaTodos()
        {
            var lista = await _service.ObterTodosOnline();

            await Clients.All.SendAsync("InstanciasOnline", lista);
        }
    }
}