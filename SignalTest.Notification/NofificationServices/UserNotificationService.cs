using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using SignalTest.Domain.Interfaces.Notification;
using SignalTest.Infra.Notification.Hub;
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

        public async Task NotificarUsuariosOnline(string usuario)
        {
            await _hub.Clients.All.UsuarioOnline(usuario);
        }
    }
}