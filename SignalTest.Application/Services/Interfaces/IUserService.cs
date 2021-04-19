using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SignalTest.Domain.DTOs;
using SignalTest.Domain.Entities;

namespace SignalTest.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task NotificarLogin(string email);
        Task EstouAqui(Guid idString);
        Task NotificarTodosOsUsuariosOnline();
        Task<IEnumerable<UserDto>> ObterTodosOnline();
        Task<UserDto> ObterPorId(Guid userId);
        Task<IEnumerable<UserDto>> ObterTodos();
        Task AtualizarVistoPorUltimo(Guid userId);
        Task Update(User user);
        Task Remove(User user);
    }
}