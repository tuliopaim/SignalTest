using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SignalTest.Application.DTOs;
using SignalTest.Domain.Entities;

namespace SignalTest.Application.Services.Interfaces
{
    public interface IUserInstanceService
    {
        Task NotificarLogin(string email);
        Task EstouAqui(string idString);
        Task NotificarUsuariosOnlineHub();
        Task<IEnumerable<UserInstanceDto>> ObterTodosOnline();
        Task<UserInstanceDto> ObterPorId(Guid userId);
        Task<IEnumerable<UserInstanceDto>> ObterTodos();
        Task AtualizarVistoPorUltimo(Guid userId);
        Task Update(User user);
        Task Remove(User user);
    }
}