using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SignalTest.MVC.Domain.Entities;
using SignalTest.MVC.Domain.Interfaces;

namespace SignalTest.MVC.Domain.Services
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

        public async Task<IEnumerable<UserInstance>> ObterTodosOnline()
        {
            var data = DateTime.Now.AddMinutes(-5);

            return await _repository.ObterTodosOnline(data);
        }

        public async Task<UserInstance> ObterPorId(Guid userId)
        {
            return await _repository.ObterPorId(userId);
        }

        public async Task<IEnumerable<UserInstance>> ObterTodos()
        {
            return await _repository.ObterTodos();
        }

        public async Task AtualizarVistoPorUltimo(Guid userId)
        {
            var user = await _repository.ObterPorId(userId);

            if (user == null) return;

            user.Atualizar();

            await _repository.Update(user);
        }

        public async Task<UserInstance> Add(string nome)
        {
            var user = new UserInstance(nome);

            await _repository.Add(user);

            return user;
        }

        public async Task Update(UserInstance user)
        {
            await _repository.Update(user);
        }

        public async Task Remove(UserInstance user)
        {
            await _repository.Remove(user);
        }
    }
}