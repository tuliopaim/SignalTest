using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SignalTest.MVC.Domain.Entities;
using SignalTest.MVC.DTOs;

namespace SignalTest.MVC.Domain.Interfaces
{
    public interface IUserInstanceService
    {
        Task<IEnumerable<UserInstanceDto>> ObterTodosOnline();
        Task<int> ObterQuantidadeOnline();
        Task<UserInstanceDto> ObterPorId(Guid userId);
        Task<IEnumerable<UserInstanceDto>> ObterTodos();
        Task AtualizarVistoPorUltimo(Guid userId);
        Task<UserInstanceDto> Add(string nome);
        Task Update(UserInstance user);
        Task Remove(UserInstance user);
    }
}