using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SignalTest.MVC.Domain.Entities;

namespace SignalTest.MVC.Domain.Interfaces
{
    public interface IUserInstanceRepository
    {
        Task<int> ObterQuantidadeDesde(DateTime data);
        Task<IEnumerable<User>> ObterTodosOnline(DateTime data);
        Task<User> ObterPorId(Guid id);
        Task<IEnumerable<User>> ObterTodos();
        Task Update(User user);
        Task Remove(User user);
    }
}