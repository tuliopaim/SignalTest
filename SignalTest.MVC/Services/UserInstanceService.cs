using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SignalTest.MVC.Domain.Entities;
using SignalTest.MVC.Domain.Interfaces;
using SignalTest.MVC.DTOs;

namespace SignalTest.MVC.Services
{
    public class UserInstanceService : IUserInstanceService
    {
        private readonly IUserInstanceRepository _repository;

        public UserInstanceService(IUserInstanceRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> ObterQuantidadeOnline()
        {
            var data = DateTime.Now.AddMinutes(-5);

            return await _repository.ObterQuantidadeDesde(data);
        }

        public async Task<IEnumerable<UserInstanceDto>> ObterTodosOnline()
        {
            var data = DateTime.Now.AddMinutes(-5);

            var lista = await _repository.ObterTodosOnline(data);

            return lista.Select(ConverTerParaViewModel);
        }

        public async Task<UserInstanceDto> ObterPorId(Guid userId)
        {
            var user = await _repository.ObterPorId(userId);
            return ConverTerParaViewModel(user);
        }

        public async Task<IEnumerable<UserInstanceDto>> ObterTodos()
        {
            var lista = await _repository.ObterTodos();

            return lista.Select(ConverTerParaViewModel);
        }

        public async Task AtualizarVistoPorUltimo(Guid userId)
        {
            var user = await _repository.ObterPorId(userId);

            if (user == null) return;

            user.Atualizar();

            await _repository.Update(user);
        }

        public async Task<UserInstanceDto> Add(string nome)
        {
            var user = new UserInstance(nome);

            await _repository.Add(user);

            return ConverTerParaViewModel(user);
        }

        public async Task Update(UserInstance user)
        {
            await _repository.Update(user);
        }
        
        private static UserInstanceDto ConverTerParaViewModel(UserInstance user)
        {
            if (user is null) return null;

            return new()
            {
                Id = user.Id,
                Nome = user.Nome,
                VistoPorUltimo = user.VistoPorUltimo
            };
        }
        
        public async Task Remove(UserInstance user)
        {
            await _repository.Remove(user);
        }
    }
}