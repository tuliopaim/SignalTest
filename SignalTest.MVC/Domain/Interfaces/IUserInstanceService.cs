using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SignalTest.MVC.Domain.Entities;
using SignalTest.MVC.DTOs;

namespace SignalTest.MVC.Domain.Interfaces
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