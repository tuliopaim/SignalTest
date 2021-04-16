using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SignalTest.MVC.Domain.Entities;

namespace SignalTest.MVC.Domain.Interfaces
{
    public interface IUserInstanceService
    {
        Task<UserInstance> ObterPorId(Guid userId);
        Task<IEnumerable<UserInstance>> ObterTodos();
        Task AtualizarVistoPorUltimo(Guid userId);
        Task Add(UserInstance user);
        Task Update(UserInstance user);
        Task Remove(UserInstance user);
    }
}