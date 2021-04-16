using System;
using System.Runtime.InteropServices;
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

        public async Task SouNovoAqui()
        {
            var user = await _service.Add();

            await Clients.All.SendAsync("MeuId", user.Id);

            await EnviarInstanciasOnline();
        }

        public async Task EstouAqui(Guid id)
        {
            await _service.AtualizarVistoPorUltimo(id);

            await EnviarInstanciasOnline();
        }

        private async Task EnviarInstanciasOnline()
        {
            var lista = await _service.ObterTodosOnline();

            await Clients.All.SendAsync("InstanciasOnline", lista);
        }
    }
}