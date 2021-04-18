using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using SignalTest.Notification.Hub;
using SignalTest.Notification.Interfaces;

namespace SignalTest.Notification.NofificationServices
{
    public class UserNotificationService : IUserNotificationService
    {
        private readonly IHubContext<UserHub, IUserHub> _hub;

        public UserNotificationService(IHubContext<UserHub, IUserHub> hub)
        {
            _hub = hub;
        }

        public async Task NotificarUsuarioOnline(string usuario)
        {
            await _hub.Clients.All.UsuarioOnline(usuario);
        }
    }
}