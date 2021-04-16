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

        public async Task<UserInstance> ObterPorId(Guid userId)
        {
            return await _repository.ObterPorId(userId);
        }

        public async Task<IEnumerable<UserInstance>> ObterTodos()
        {
            return await _repository.Get();
        }

        public async Task AtualizarVistoPorUltimo(Guid userId)
        {
            var user = await _repository.ObterPorId(userId);

            if (user == null) return;

            user.Atualizar();

            await _repository.Update(user);
        }

        public async Task Add(UserInstance user)
        {
            await _repository.Add(user);
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