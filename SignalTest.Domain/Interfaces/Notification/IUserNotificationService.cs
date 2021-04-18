using System.Collections.Generic;
using System.Threading.Tasks;
using SignalTest.Domain.DTOs;

namespace SignalTest.Domain.Interfaces.Notification
{
    public interface IUserNotificationService
    {
        Task NotificarUsuariosOnline(IEnumerable<UserDto> usuarios);
        Task NotificarNovoUsuarioOnline(UserDto usuario);
    }
}