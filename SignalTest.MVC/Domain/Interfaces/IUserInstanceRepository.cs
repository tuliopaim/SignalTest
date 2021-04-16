using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SignalTest.MVC.Domain.Entities;

namespace SignalTest.MVC.Domain.Interfaces
{
    public interface IUserInstanceRepository
    {
        Task<int> ObterQuantidadeDesde(DateTime data);
        Task<IEnumerable<UserInstance>> ObterTodosOnline(DateTime data);
        Task<UserInstance> ObterPorId(Guid id);
        Task<IEnumerable<UserInstance>> ObterTodos();
        Task Add(UserInstance user);
        Task Update(UserInstance user);
        Task Remove(UserInstance user);
    }
}