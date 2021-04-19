using System.Collections.Generic;
using SignalTest.Domain.DTOs;
using System.Threading.Tasks;

namespace SignalTest.Infra.Notification.Interfaces
{
    public interface IUserHub
    {
        Task UsuariosOnline(IEnumerable<UserDto> usuarios);
        Task NovoUsuarioOnline(UserDto usuario);
    }
}