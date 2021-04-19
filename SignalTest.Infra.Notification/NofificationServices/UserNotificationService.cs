using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using SignalTest.Domain.DTOs;
using SignalTest.Domain.Interfaces.Notification;
using SignalTest.Infra.Notification.Hubs;
using SignalTest.Infra.Notification.Interfaces;

namespace SignalTest.Infra.Notification.NofificationServices
{
    public class UserNotificationService : IUserNotificationService
    {
        private readonly IHubContext<UserHub, IUserHub> _hub;

        public UserNotificationService(IHubContext<UserHub, IUserHub> hub)
        {
            _hub = hub;
        }

        public async Task NotificarUsuariosOnline(IEnumerable<UserDto> usuarios)
        {
            await _hub.Clients.All.UsuariosOnline(usuarios);
        }

        public async Task NotificarNovoUsuarioOnline(UserDto usuario)
        {
            await _hub.Clients.All.NovoUsuarioOnline(usuario);
        }
    }
}