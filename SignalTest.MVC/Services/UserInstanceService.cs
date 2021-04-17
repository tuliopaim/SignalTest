using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using SignalTest.MVC.Domain.Entities;
using SignalTest.MVC.Domain.Interfaces;
using SignalTest.MVC.DTOs;
using SignalTest.MVC.Hub;

namespace SignalTest.MVC.Services
{
    public class UserInstanceService : IUserInstanceService
    {
        private readonly IUserInstanceRepository _repository;
        private readonly IHubContext<InstanceHub> _hub;

        public UserInstanceService(
            IUserInstanceRepository repository,
            IHubContext<InstanceHub> hub)
        {
            _repository = repository;
            _hub = hub;
        }
        
        public async Task EstouAqui(string idString)
        {
            if (!Guid.TryParse(idString, out var id))
                return;

            await AtualizarVistoPorUltimo(id);

            await AtualizarInstanciasOnlineHub();
        }

        public async Task AtualizarInstanciasOnlineHub()
        {
            var lista = await ObterTodosOnline();

            lista ??= new List<UserInstanceDto>();

            await _hub.Clients.All.SendAsync("InstanciasOnline", lista);
        }

        public async Task<IEnumerable<UserInstanceDto>> ObterTodosOnline()
        {
            var data = DateTime.Now.AddMinutes(-5);

            var lista = await _repository.ObterTodosOnline(data);

            return lista.Select(ConverterParaViewModel);
        }

        public async Task<UserInstanceDto> ObterPorId(Guid userId)
        {
            var user = await _repository.ObterPorId(userId);
            return ConverterParaViewModel(user);
        }

        public async Task<IEnumerable<UserInstanceDto>> ObterTodos()
        {
            var lista = await _repository.ObterTodos();

            return lista.Select(ConverterParaViewModel);
        }

        public async Task AtualizarVistoPorUltimo(Guid userId)
        {
            var user = await _repository.ObterPorId(userId);

            if (user == null) return;

            user.Atualizar();

            await _repository.Update(user);
        }
        
        public async Task Update(User user)
        {
            await _repository.Update(user);
        }
        
        private static UserInstanceDto ConverterParaViewModel(User user)
        {
            if (user is null) return null;

            return new()
            {
                Id = user.Id,
                Nome = user.Nome,
                VistoPorUltimo = user.VistoPorUltimo
            };
        }
        
        public async Task Remove(User user)
        {
            await _repository.Remove(user);
        }
    }
}