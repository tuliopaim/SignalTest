using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SignalTest.MVC.Domain.Entities;

namespace SignalTest.MVC.Domain.Interfaces
{
    public interface IUserInstanceService
    {
        Task<IEnumerable<UserInstance>> ObterTodosOnline();
        Task<int> ObterQuantidadeOnline();
        Task<UserInstance> ObterPorId(Guid userId);
        Task<IEnumerable<UserInstance>> ObterTodos();
        Task AtualizarVistoPorUltimo(Guid userId);
        Task<UserInstance> Add();
        Task Update(UserInstance user);
        Task Remove(UserInstance user);
    }
}