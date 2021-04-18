using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SignalTest.Domain.Entities;

namespace SignalTest.Domain.Interfaces.Repository
{
    public interface IUserInstanceRepository
    {
        Task<IEnumerable<User>> ObterTodosOnline(DateTime data);
        Task<User> ObterPorId(Guid id);
        Task<IEnumerable<User>> ObterTodos();
        Task Update(User user);
        Task Remove(User user);
    }
}