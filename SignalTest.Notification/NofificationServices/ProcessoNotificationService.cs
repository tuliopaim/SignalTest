using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using SignalTest.Notification.Hub;
using SignalTest.Notification.Interfaces;

namespace SignalTest.Notification.NofificationServices
{
    public class ProcessoNotificationService : IProcessoNotificationService
    {
        private readonly IHubContext<ProcessoHub, IProcessoHub> _hub;

        public ProcessoNotificationService(IHubContext<ProcessoHub, IProcessoHub> hub)
        {
            _hub = hub;
        }

        public async Task NotificarProcessamento(Guid userId, string itemProcessado, decimal percentual)
        {
            await _hub.Clients.User(userId.ToString()).NotificarProcessamento(userId, itemProcessado, percentual);
        }
    }
}