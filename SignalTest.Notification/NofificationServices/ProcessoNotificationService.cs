using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using SignalTest.Domain.Interfaces.Notification;
using SignalTest.Infra.Notification.Hub;
using SignalTest.Infra.Notification.Interfaces;

namespace SignalTest.Infra.Notification.NofificationServices
{
    public class ProcessoNotificationService : IProcessoNotificationService
    {
        private readonly IHubContext<ProcessamentoHub, IProcessamentoHub> _hub;

        public ProcessoNotificationService(IHubContext<ProcessamentoHub, IProcessamentoHub> hub)
        {
            _hub = hub;
        }

        public async Task NotificarProcessamento(Guid userId, string itemProcessado, decimal percentual)
        {
            await _hub.Clients.User(userId.ToString()).NotificarProcessamento(userId, itemProcessado, percentual);
        }
    }
}